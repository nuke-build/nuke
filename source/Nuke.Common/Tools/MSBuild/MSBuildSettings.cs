// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities;

namespace Nuke.Common.Tools.MSBuild
{
    partial class MSBuildSettings
    {
        //private string GetTargetPlatform ()
        //{
        //    if (TargetPlatform == MSBuild.TargetPlatform.MSIL)
        //        return TargetPath == null || TargetPath.EndsWith(".sln", StringComparison.OrdinalIgnoreCase)
        //            ? "Any CPU".DoubleQuote()
        //            : "AnyCPU";

        //    return TargetPlatform.ToString();
        //}

        [CanBeNull]
        private string GetToolsVersion ()
        {
            switch (ToolsVersion)
            {
                case null: return null;
                case MSBuildToolsVersion._15_0: return "15.0";
                case MSBuildToolsVersion._14_0: return "14.0";
                case MSBuildToolsVersion._12_0: return "12.0";
                default: throw new NotSupportedException();
            }
        }
    }
}
