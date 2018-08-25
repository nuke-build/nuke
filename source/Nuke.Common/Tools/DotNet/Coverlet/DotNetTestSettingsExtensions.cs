// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet.Coverlet
{
    // Coverlet can generate coverage results in multiple formats
    public enum OutputType
    {
        json,        // default
        lcov,
        opencover,
        cobertura
    }

    public enum ThresholdType
    {
        line,        // default
        branch,
        method
    }
    
    public static class DotNetTestSettingsExtensions
    {
        /// <summary>
        /// <seealso cref="https://github.com/tonerdo/coverlet"/>
        /// Enabling code coverage is as simple as setting the CollectCoverage property to true
        /// </summary>
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings EnableCoverletCoverage(this DotNetTestSettings toolSettings)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add("/p:CollectCoverage=true"));
        }
        
        /// <summary>
        /// Coverlet can generate coverage results in multiple formats, which is specified using the CoverletOutputFormat property.
        /// For example, the following command emits coverage results in the opencover format:
        ///     /p:CoverletOutputFormat=opencover
        /// </summary>
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <param name="types">Desired types.</param>
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings SetCoverletOutputFormat(this DotNetTestSettings toolSettings, params OutputType[] types)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:CoverletOutputFormat={string.Join(",", types)}"));
        }
        
        /// <summary>
        /// Coverlet allows you to specify a coverage threshold below which it fails the build.
        /// This allows you to enforce a minimum coverage percent on all changes to your project.
        /// </summary>
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <param name="thresholdValue">Threshold.</param>
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings SetCoverletThreshold(this DotNetTestSettings toolSettings, int thresholdValue = 80)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:Threshold={thresholdValue}"));
        }
        
        /// <summary>
        /// DEFAULT: coverage.json
        /// The output of the coverage result can be specified using the CoverletOutput property.
        /// To specify a directory where all results will be written to (especially if using multiple formats), end the value with a /.
        /// </summary> 
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <param name="coverletOutput">Folder or file.</param>
        /// <example>
        /// './result.json'
        /// './results/'
        /// </example> 
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings SetCoverletOutput(this DotNetTestSettings toolSettings, string coverletOutput)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:CoverletOutput={coverletOutput}"));
        }
        
        /// <summary>
        /// DEFAULT: line
        ///  You can specify what type of coverage to apply the threshold value to using the ThresholdType property. For example to apply the threshold check to only line coverage:
        ///
        ///    dotnet test /p:CollectCoverage=true /p:Threshold=80 /p:ThresholdType=line
        ///
        /// You can specify multiple values for ThresholdType by separating them with commas. Valid values include line, branch and method.
        /// </summary>
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <param name="thresholdTypes">Threshold Types.</param>
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings SetCoverletThresholdType(this DotNetTestSettings toolSettings, params ThresholdType[] thresholdTypes)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:ThresholdType={string.Join(",", thresholdTypes)}"));
        }
        
        /// <summary>
        /// You can also ignore specific source files from code coverage using the ExcludeByFile property
        /// Use single or multiple paths (separate by comma)
        /// Use absolute or relative paths (relative to the project directory)
        /// Use file path or directory path with globbing (e.g dir1/*.cs)
        /// </summary>
        /// <param name="toolSettings">DotNetTestSettings instance.</param>
        /// <param name="excludeByFile">File patterns to exclude.</param>
        /// <returns>DotNetTestSettings instance.</returns>
        public static DotNetTestSettings SetCoverletExcludeByFile(this DotNetTestSettings toolSettings, string excludeByFile)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:ExcludeByFile={excludeByFile}"));
        }
        
        public static DotNetTestSettings SetCoverletExclude(this DotNetTestSettings toolSettings, string excludePatterns)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:Exclude={excludePatterns}"));
        }
        
        public static DotNetTestSettings SetCoverletInclude(this DotNetTestSettings toolSettings, string includePatterns)
        {
            return toolSettings.SetArgumentConfigurator(args => args.Add($"/p:Include={includePatterns}"));
        }
    }
}
