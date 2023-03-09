// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.MSBuildLocator
{
    public static class Program
    {
        private const string MSBuildComponent = "Microsoft.Component.MSBuild";
        private const string NetCoreComponent = "Microsoft.Net.Core.Component.SDK";

        [STAThread]
        public static void Main()
        {
            var assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Trace.Assert(assemblyDirectory != null, "assemblyDirectory != null");
            var vswherePath = Path.Combine(assemblyDirectory, "vswhere.exe");
            Trace.Assert(File.Exists(vswherePath), $"File.Exists({vswherePath})");
            var msbuildLocator = new MSBuildLocator(vswherePath);
            var msbuildPath = msbuildLocator.Resolve();
            Trace.Assert(msbuildPath != null, "msbuildPath != null");
            Console.WriteLine(msbuildPath);
        }

        private class MSBuildLocator
        {
            private readonly string _vswherePath;

            public MSBuildLocator(string vswherePath)
            {
                _vswherePath = vswherePath;
            }

            [CanBeNull]
            public string Resolve()
            {
                return IsUnixOperatingSystem()
                    ? new[]
                      {
                          "/usr/bin/msbuild",
                          "/usr/local/bin/msbuild",
                          "/Library/Frameworks/Mono.framework/Versions/Current/Commands/msbuild"
                      }.FirstOrDefault(File.Exists)
                    : TryGetMSBuildPath(products: "*", requires: new[] { MSBuildComponent, NetCoreComponent }, legacy: false) ??
                      TryGetMSBuildPath(products: "*", requires: new[] { MSBuildComponent }, legacy: false) ??
                      TryGetMSBuildPath(products: null, requires: null, legacy: true);
            }

            private bool IsUnixOperatingSystem()
            {
                var platform = (int) Environment.OSVersion.Platform;
                return platform > 5 || platform == 4;
            }

            [CanBeNull]
            private string TryGetMSBuildPath(
                [CanBeNull] string products,
                [CanBeNull] IReadOnlyCollection<string> requires,
                bool legacy)
            {
                var installation = GetVSWhereInstallation(products, requires, legacy);
                if (installation == null)
                    return null;

                var msbuildMajorVersion = installation.Version.Split('.')[0];
                var msbuildVersionDirectoryName = int.TryParse(msbuildMajorVersion, out var major) && major < 16
                    ? $"{installation.Version.Split('.')[0]}.0"
                    : "Current";

                var msbuildPath = Path.Combine(
                    installation.Path,
                    "MSBuild",
                    msbuildVersionDirectoryName,
                    "Bin",
                    Environment.Is64BitOperatingSystem ? "amd64" : ".",
                    "MSBuild.exe");
                Trace.Assert(File.Exists(msbuildPath), $"File.Exists({msbuildPath})");
                return msbuildPath;
            }

            [CanBeNull]
            private VSWhereInstallation GetVSWhereInstallation(
                [CanBeNull] string products,
                [CanBeNull] IReadOnlyCollection<string> requires,
                bool legacy)
            {
                var arguments = new StringBuilder("-latest -format text");
                if (products != null)
                    arguments.Append($" -products {products}");
                if (requires != null)
                    arguments.Append($" -requires {string.Join(" ", requires)}");
                if (legacy)
                    arguments.Append(" -legacy");

                var output = GetProcessOutput(arguments.ToString());
                var lines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                var lookup = lines
                    .Select(x => x.Split(new[] { ':' }, count: 2))
                    .Where(x => x.Length == 2)
                    .Select(x => new KeyValuePair<string, string>(x[0], x[1].TrimStart()))
                    .ToLookup(x => x.Key, x => x.Value);

                bool TryGetSingleValue(string identifier, out string value)
                {
                    value = lookup[identifier].SingleOrDefault();
                    return value != null;
                }

                return TryGetSingleValue("installationPath", out var installationPath) &&
                       TryGetSingleValue("installationVersion", out var installationVersion)
                    ? new VSWhereInstallation(installationPath, installationVersion)
                    : null;
            }

            private string GetProcessOutput(string arguments)
            {
                var info = new ProcessStartInfo(_vswherePath, arguments)
                           {
                               RedirectStandardOutput = true,
                               RedirectStandardError = true,
                               CreateNoWindow = true,
                               UseShellExecute = false
                           };
                var process = new Process { StartInfo = info };
                process.Start();

                process.ErrorDataReceived += (_, e) => Console.Error.WriteLine(e.Data);
                process.WaitForExit();
                Trace.Assert(process.ExitCode == 0, "process.ExitCode == 0");

                return process.StandardOutput.ReadToEnd();
            }

            private class VSWhereInstallation
            {
                public VSWhereInstallation(string path, string version)
                {
                    Path = path;
                    Version = version;
                }

                public string Path { get; }
                public string Version { get; }
            }
        }
    }
}
