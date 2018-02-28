// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.Git;
using Nuke.Common.Gitter;
using Nuke.Common.Tools.CoverallsNet;
using Nuke.Common.Tools.DocFx;
using Nuke.Common.Tools.DotCover;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.DupFinder;
using Nuke.Common.Tools.Git;
using Nuke.Common.Tools.GitLink;
using Nuke.Common.Tools.GitReleaseManager;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.Npm;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.Nunit;
using Nuke.Common.Tools.Octopus;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Paket;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Tools.SignTool;
using Nuke.Common.Tools.TestCloud;
using Nuke.Common.Tools.VsTest;
using Nuke.Common.Tools.WebConfigTransformRunner;
using Nuke.Common.Tools.Xunit;
using Nuke.Core.Execution;

[assembly: IconClass(typeof(ChangelogTasks), "books")]
[assembly: IconClass(typeof(CoverallsNetTasks), "pie-chart4")]
[assembly: IconClass(typeof(DocFxTasks), "books")]
[assembly: IconClass(typeof(DotCoverTasks), "shield2")]
[assembly: IconClass(typeof(DotNetTasks), "fire")]
[assembly: IconClass(typeof(DupFinderTasks), "code")]
[assembly: IconClass(typeof(GitTasks), "git")]
[assembly: IconClass(typeof(GitLinkTasks), "link")]
[assembly: IconClass(typeof(GitReleaseManagerTasks), "books")]
[assembly: IconClass(typeof(GitRepository), "git")]
[assembly: IconClass(typeof(GitRepositoryAttribute), "git")]
[assembly: IconClass(typeof(GitterTasks), "bubbles")]
[assembly: IconClass(typeof(GitVersionTasks), "podium")]
[assembly: IconClass(typeof(GitVersionAttribute), "git")]
[assembly: IconClass(typeof(InspectCodeTasks), "code")]
[assembly: IconClass(typeof(MSBuildTasks), "sword")]
[assembly: IconClass(typeof(NpmTasks), "box")]
[assembly: IconClass(typeof(NuGetTasks), "box")]
[assembly: IconClass(typeof(NunitTasks), "bug2")]
[assembly: IconClass(typeof(OctopusTasks), "cloud-upload")]
[assembly: IconClass(typeof(OpenCoverTasks), "shield2")]
[assembly: IconClass(typeof(PaketTasks), "box")]
[assembly: IconClass(typeof(ReportGeneratorTasks), "pie-chart4")]
[assembly: IconClass(typeof(SignToolTasks), "key")]
[assembly: IconClass(typeof(TestCloudTasks), "bug2")]
[assembly: IconClass(typeof(VsTestTasks), "bug2")]
[assembly: IconClass(typeof(WebConfigTransformRunnerTasks), "file-empty2")]
[assembly: IconClass(typeof(XunitTasks), "bug2")]
