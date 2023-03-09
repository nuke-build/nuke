// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using ICSharpCode.SharpZipLib.Zip;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using NuGet.Packaging;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Serilog;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class HandleSingleFileExecutionAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        private const string ScriptUrl = "https://dot.net/v1/dotnet-install.sh";

        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (!IsSingleFileExecution)
                return;

            InstallDotNetRuntime();
            ExtractPackageFiles();
        }

        private static void ExtractPackageFiles()
        {
            var executingAssembly = Assembly.GetEntryAssembly().NotNull();
            var packageResourceNames = executingAssembly.GetManifestResourceNames().Where(x => x.EndsWithOrdinalIgnoreCase("nupkg")).ToList();
            if (!packageResourceNames.Any())
                return;

            var globalPackagesDirectory = Constants.GlobalNukeDirectory / "packages";
            Log.Information("Extracting packages to {PackagesDirectory}", globalPackagesDirectory);

            foreach (var packageResourceName in packageResourceNames)
            {
                Log.Verbose("Extracting {Package}", packageResourceName);

                var packageResourceStream = executingAssembly.GetManifestResourceStream(packageResourceName).NotNull();
                var packageArchiveReader = new PackageArchiveReader(packageResourceStream);
                var nuspecReader = packageArchiveReader.NuspecReader;
                var packageFile = globalPackagesDirectory / nuspecReader.GetId() / nuspecReader.GetVersion().ToString() / packageResourceName;

                packageResourceStream.Seek(offset: 0, SeekOrigin.Begin);
                packageResourceStream.CopyToFile(packageFile);

                using var fileStream = File.OpenRead(packageFile);
                using var zipFile = new ZipFile(fileStream);

                var entries = zipFile.Cast<ZipEntry>().Where(x => !x.IsDirectory);
                foreach (var entry in entries)
                {
                    var file = packageFile.Parent / entry.Name;
                    Directory.CreateDirectory(file.Parent);

                    using var entryStream = zipFile.GetInputStream(entry);
                    using var outputStream = File.Open(file, FileMode.Create);
                    entryStream.CopyTo(outputStream);
                }
            }
        }

        private void InstallDotNetRuntime()
        {
            HttpTasks.HttpDownloadFile(ScriptUrl, ScriptFile);

            var version = GetDotNetRuntimeVersion();
            var installLocation = Constants.GlobalNukeDirectory / "dotnet-runtime" / (version ?? "current");
            var dotnetExecutable = installLocation / (EnvironmentInfo.IsWin ? "dotnet.exe" : "dotnet");

            if (version == null || !dotnetExecutable.Exists())
            {
                if (EnvironmentInfo.IsLinux)
                {
                    ProcessTasks.StartShell($"chmod +x {ScriptFile.ToString().DoubleQuoteIfNeeded()}", logOutput: false)
                        .AssertZeroExitCode();
                }

                ProcessTasks.StartShell(
                        EnvironmentInfo.IsWin
                            ? $"powershell {ScriptFile.ToString().DoubleQuoteIfNeeded()} -InstallDir {installLocation} -NoPath -Runtime dotnet "
                              + (version != null ? $"-Version {version}" : "-Channel Current")
                            : $"{ScriptFile.ToString().DoubleQuoteIfNeeded()} --install-dir {installLocation} --no-path --runtime dotnet "
                              + (version != null ? $"--version {version}" : "--channel Current"),
                        logOutput: false)
                    .AssertZeroExitCode();
            }

            EnvironmentInfo.SetVariable("DOTNET_EXE", dotnetExecutable);
            EnvironmentInfo.SetVariable("DOTNET_SYSTEM_GLOBALIZATION_INVARIANT", value: true);
        }

        private bool IsSingleFileExecution => Assembly.GetEntryAssembly().NotNull().Location == string.Empty;

        private string ScriptFileName => EnvironmentInfo.IsWin ? "dotnet-install.ps1" : "dotnet-install.sh";
        private AbsolutePath ScriptFile => Constants.GlobalNukeDirectory / ScriptFileName;

        [CanBeNull]
        private string GetDotNetRuntimeVersion()
        {
            var globalJsonFile = Build.RootDirectory / "global.json";
            var jobject = globalJsonFile.Existing()?.ReadJson() ?? new JObject();
            return jobject["sdk"]?["version"]?.Value<string>().Substring(startIndex: 0, length: 5);
        }
    }
}
