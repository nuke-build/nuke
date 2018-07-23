﻿ // Copyright Matthias Koch, Sebastian Karasek 2018.
 // Distributed under the MIT License.
 // https://github.com/nuke-build/nuke/blob/master/LICENSE

 using System;
 using System.Collections.Generic;
 using System.Linq;
 using Nuke.Common.IO;
 using Nuke.Common.Tooling;
 using Nuke.Common.Utilities;

 namespace Nuke.Common.Tools.VSWhere
 {
     partial class VSWhereTasks
     {
         public const string VcComponent = "Microsoft.VisualStudio.Component.VC.Tools.x86.x64";
         public const string MsBuildComponent = "Microsoft.Component.MSBuild";
         public const string NetCoreComponent = "Microsoft.Net.Core.Component.SDK";

         private static List<VSWhereResult> GetResult(IProcess process, VSWhereSettings toolSettings)
         {
             if (!(toolSettings.UTF8 ?? false) || toolSettings.Format != VSWhereFormat.json || toolSettings.Property != null)
                 return null;

             var output = process.Output.EnsureOnlyStd().Select(x => x.Text).JoinNewLine();
             return SerializationTasks.JsonDeserialize<VSWhereResult[]>(output).ToList();

         }
     }
 }
