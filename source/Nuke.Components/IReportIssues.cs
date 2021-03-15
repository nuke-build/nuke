// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.ReSharper;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.Tools.ReSharper.ReSharperTasks;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IReportIssues : IRestore, IHazReports
    {
        AbsolutePath InspectCodeReportFile => ReportDirectory / "inspect-code.xml";

        Target ReportIssues => _ => _
            .DependsOn(Restore)
            .TryDependentFor<IPublish>()
            .TryAfter<ITest>()
            .Executes(() =>
            {
                ReSharperInspectCode(_ => _
                    .Apply(InspectCodeSettingsBase)
                    .Apply(InspectCodeSettings)
                    .CombineWith(InspectCodePlugins, (_, v) => _
                        .AddPlugin(v.PackageId, v.Version)));

                TeamCity.Instance?.ImportData(TeamCityImportType.ReSharperInspectCode, InspectCodeReportFile);

                InspectCodeCheckResults();
            });

        IEnumerable<(string PackageId, string Version)> InspectCodePlugins => new (string PackageId, string Version)[0];

        sealed Configure<ReSharperInspectCodeSettings> InspectCodeSettingsBase => _ => _
            .SetTargetPath(Solution)
            .SetOutput(InspectCodeReportFile)
            .SetSeverity(ReSharperSeverity.WARNING)
            .When(RootDirectory.Contains(DotNetPath), _ => _
                .SetDotNetCore(DotNetPath));

        Configure<ReSharperInspectCodeSettings> InspectCodeSettings => _ => _;

        bool InspectCodeFailOnError => true;
        bool InspectCodeFailOnWarning => true;
        bool InspectCodeReportIssueSummary => true;
        bool InspectCodeReportWarnings => true;
        IEnumerable<string> InspectCodeFailOnIssues => new string[0];
        IEnumerable<string> InspectCodeFailOnCategories => new string[0];

        void InspectCodeCheckResults()
        {
            var issueTypes = XmlTasks.XmlPeekElements(InspectCodeReportFile, "//Report/IssueTypes/IssueType")
                .Select(x => (
                    Id: x.GetAttributeValue("Id"),
                    CategoryId: x.GetAttributeValue("CategoryId"),
                    Severity: x.GetAttributeValue("Severity")))
                .ToDictionary(x => x.Id, x => x);

            var issues = XmlTasks.XmlPeekElements(InspectCodeReportFile, "//Report/Issues/Project/Issue")
                .Select(x => (
                    TypeId: x.GetAttributeValue("TypeId"),
                    Message: x.GetAttributeValue("Message"),
                    File: x.GetAttributeValue("File"),
                    Line: x.GetAttributeValue("Line")))
                .Select(x => (
                    x.TypeId,
                    x.Message,
                    x.File,
                    x.Line,
                    issueTypes[x.TypeId].Severity,
                    issueTypes[x.TypeId].CategoryId))
                .Where(x => x.Severity == nameof(ReSharperSeverity.ERROR) ||
                            x.Severity == nameof(ReSharperSeverity.WARNING))
                .OrderBy(x => x.File).ToList();

            foreach (var issue in issues)
            {
                if (issue.Severity == nameof(ReSharperSeverity.WARNING) &&
                    !InspectCodeReportWarnings &&
                    !InspectCodeFailOnIssues.Contains(issue.TypeId) &&
                    !InspectCodeFailOnCategories.Contains(issue.CategoryId))
                    continue;

                var message = InspectCodeIssueMessage(issue.TypeId, issue.File, issue.Line, issue.Message);
                Logger.Normal(message);
            }

            if (InspectCodeReportIssueSummary)
            {
                Logger.Normal();
                InspectCodeWriteIssueSummary(issues);
            }

            Logger.Normal();
            ReportIssueCount(issues);
        }

        void InspectCodeWriteIssueSummary(List<(string TypeId, string Message, string File, string Line, string Severity, string CategoryId)> issues)
        {
            var indentation = issues.Count.ToString().Length + 2;
            foreach (var issuesByCategory in issues.GroupBy(x => x.CategoryId).OrderBy(x => x.Key))
            {
                Logger.Info($"{issuesByCategory.Key} ({issuesByCategory.Count()})");
                foreach (var issuesByType in issuesByCategory.GroupBy(x => x.TypeId).OrderByDescending(x => x.Count()))
                {
                    var message = $"{issuesByType.Count().ToString().PadLeft(indentation)} {issuesByType.Key}";
                    // if (issueTypes[issuesByType.Key].Severity == nameof(ReSharperSeverity.ERROR) && InspectCodeFailOnError ||
                    //     issueTypes[issuesByType.Key].Severity == nameof(ReSharperSeverity.WARNING) &&
                    //     (InspectCodeFailOnError)
                    Logger.Normal(message);
                }
            }
        }

        sealed void ReportIssueCount(
            List<(string TypeId, string Message, string File, string Line, string Severity, string CategoryId)> issues)
        {
            var errorCount = issues.Count(x => x.Severity == nameof(ReSharperSeverity.ERROR));
            var warningCount = issues.Count(x => x.Severity == nameof(ReSharperSeverity.WARNING));

            var summaryMessage = $"Found {errorCount} errors and {warningCount} warnings in {Solution}.";

            if (InspectCodeFailOnError && errorCount > 0 ||
                InspectCodeFailOnWarning && warningCount > 0 ||
                issues.Any(x => InspectCodeFailOnIssues.Contains(x.TypeId)) ||
                issues.Any(x => InspectCodeFailOnCategories.Contains(x.CategoryId)))
                ControlFlow.Fail(summaryMessage);
            else if (errorCount > 0 || warningCount > 0)
                Logger.Warn(summaryMessage);

            ReportSummary(_ => _
                .When(errorCount > 0, _ => _
                    .AddPair("Errors", errorCount.ToString()))
                .When(warningCount > 0, _ => _
                    .AddPair("Warnings", warningCount.ToString())));
        }

        string InspectCodeIssueMessage(string typeId, string file, string line, string message)
        {
            return $"[{file}:{line}] {typeId}: {message}";
        }
    }
}
