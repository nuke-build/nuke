﻿// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Nuke.Core.OutputSinks;
using Nuke.Core.Utilities;

namespace Nuke.Core.Execution
{
    internal static class BuildExecutor
    {
        public static int Execute<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            try
            {
                var executionList = Setup(defaultTargetExpression);
                return new ExecutionListRunner().Run(executionList);
            }
            catch (Exception exception)
            {
                OutputSink.Error(exception.Message, exception.StackTrace);
                return -exception.Message.GetHashCode();
            }
        }

        private static IReadOnlyCollection<TargetDefinition> Setup<T> (Expression<Func<T, Target>> defaultTargetExpression)
            where T : NukeBuild
        {
            var build = (T) FormatterServices.GetUninitializedObject(typeof(T));
            NukeBuild.Instance = build;

            var constructors = typeof(T).GetConstructors();
            ControlFlow.Assert(constructors.Length == 1 && constructors.Single().GetParameters().Length == 0,
                $"Type '{typeof(T).Name}' must declare a single parameterless constructor.");
            constructors.Single().Invoke(build, new object[0]);

            PrintLogo();

            InjectionService.InjectValues(build);
            OutputSink.Instance = OutputSink.GetOutputSink(build.Host);
            
            Logger.Log();
            //{
            //    Console.WriteLine($"Target: {build.Target.Join(", ")}");
            //    Console.WriteLine($"Verbosity: {build.Verbosity}");
            //    Console.WriteLine($"LogLevel: {build.LogLevel}");
            //    Console.WriteLine($"NoDependencies: {build.NoDependencies}");
            //    Console.WriteLine($"Configuration: {build.Configuration}");
            //}

            var defaultTargetFactory = defaultTargetExpression.Compile().Invoke(build);
            
            if (build.Help != null)
            {
                if (build.Help.Length == 0 || build.Help.Any(x => "targets".StartsWithOrdinalIgnoreCase(x)))
                    Logger.Log(GetTargetsText(build, defaultTargetFactory));
                if (build.Help.Length == 0 || build.Help.Any(x => "parameters".StartsWithOrdinalIgnoreCase(x)))
                    Logger.Log(GetParametersText(build, defaultTargetFactory));
            }

            if (build.Graph)
                ShowGraph(build, defaultTargetFactory);

            if (build.Help != null || build.Graph)
                Environment.Exit(exitCode: 0);

            var executionList = TargetDefinitionLoader.GetExecutionList(build, defaultTargetFactory);
            RequirementService.ValidateRequirements(executionList, build);
            return executionList;
        }

        private static void PrintLogo()
        {
            Logger.Log(FigletTransform.GetText("NUKE"));
            Logger.Log(typeof(BuildExecutor).GetTypeInfo().Assembly.GetInformationText());
            Logger.Log();
        }

        public static string GetTargetsText<T> (T build, Target defaultTargetFactory)
            where T : NukeBuild
        {
            var builder = new StringBuilder();

            var targetDefinitions = build.GetTargetDefinitions(defaultTargetFactory);
            var longestTargetName = targetDefinitions.Select(x => x.Name.Length).OrderByDescending(x => x).First();
            var padRightTargets = Math.Max(longestTargetName, val2: 20);
            builder.AppendLine("Targets (with their direct dependencies):");
            builder.AppendLine();
            foreach (var target in targetDefinitions)
            {
                var dependencies = target.TargetDefinitionDependencies.Count > 0
                    ? $" -> {target.TargetDefinitionDependencies.Select(x => x.Name).JoinComma()}"
                    : string.Empty;
                var targetEntry = target.Name + (target.IsDefault ? " (default)" : string.Empty);
                builder.AppendLine($"  {targetEntry.PadRight(padRightTargets)}{dependencies}");
                if (!string.IsNullOrWhiteSpace(target.Description))
                    builder.AppendLine($"    {target.Description}");
            }

            return builder.ToString();
        }

        public static string GetParametersText<T> (T build, Target defaultTargetFactory)
            where T : NukeBuild
        {
            var defaultTarget = build.GetTargetDefinitions(defaultTargetFactory).Single(x => x.IsDefault);
            var builder = new StringBuilder();

            var parameters = build.GetParameterMembers().OrderBy(x => x.Name).ToList();
            var padRightParameter = Math.Max(parameters.Max(x => x.Name.Length), val2: 17);

            void PrintParameter (MemberInfo parameter)
            {
                var attribute = parameter.GetCustomAttribute<ParameterAttribute>();
                var description = SplitLines(
                    attribute.Description?.Replace("{default_target}", defaultTarget.Name)
                    ?? "<no description>");
                builder.AppendLine($"  -{(attribute.Name ?? parameter.Name).PadRight(padRightParameter)}  {description.First()}");
                foreach (var line in description.Skip(count: 1))
                    builder.AppendLine($"{new string(c: ' ', count: padRightParameter + 5)}{line}");
            }

            builder.AppendLine("Parameters:");

            var customParameters = parameters.Where(x => x.DeclaringType != typeof(NukeBuild)).ToList();
            if (customParameters.Count > 0)
                builder.AppendLine();
            foreach (var parameter in customParameters)
                PrintParameter(parameter);
            
            builder.AppendLine();

            var inheritedParameters = parameters.Where(x => x.DeclaringType == typeof(NukeBuild));
            foreach (var parameter in inheritedParameters)
                PrintParameter(parameter);

            return builder.ToString();
        }

        private static List<string> SplitLines(string text)
        {
            var words = new Queue<string>(text.Split(' ').ToList());
            var lines = new List<string> { string.Empty };
            foreach (var word in words)
            {
                if (lines.Last().Length + word.Length > 100)
                    lines.Add(string.Empty);

                lines[lines.Count - 1] = $"{lines.Last()} {word}";
            }
            return lines;
        }

        private static void ShowGraph<T> (T build, Target defaultTargetFactory)
            where T : NukeBuild
        {
            string GetStringFromStream (Stream stream)
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }

            var assembly = typeof(BuildExecutor).GetTypeInfo().Assembly;
            var resourceName = typeof(BuildExecutor).Namespace + ".graph.html";
            var resourceStream = assembly.GetManifestResourceStream(resourceName).NotNull("resourceStream != null");

            var graph = new StringBuilder();
            var targetDefinitions = build.GetTargetDefinitions(defaultTargetFactory);
            foreach (var target in targetDefinitions)
            {
                var dependendBy = targetDefinitions.Where(x => x.TargetDefinitionDependencies.Contains(target)).ToList();
                if (dependendBy.Count == 0)
                    graph.AppendLine(target.Name);
                else
                    dependendBy.ForEach(x => graph.AppendLine($"{target.Name} --> {x.Name}"));
            }

            var path = Path.Combine(build.TemporaryDirectory, "graph.html");
            var contents = GetStringFromStream(resourceStream).Replace("__GRAPH__", graph.ToString());
            File.WriteAllText(path, contents);

            // Workaround for https://github.com/dotnet/corefx/issues/10361
            Process.Start(new ProcessStartInfo
                          {
                              FileName = path,
                              UseShellExecute = true
                          });
        }
    }
}
