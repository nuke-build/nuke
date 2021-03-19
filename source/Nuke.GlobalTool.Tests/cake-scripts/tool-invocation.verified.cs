using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.SignTool;
using Nuke.Common.Utilities.Collections;
using Nuke.Common;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.IO;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.SignTool;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.IO;
using Nuke.Common.IO;
using Nuke.Common;
using static Nuke.Common.ControlFlow;
using static Nuke.Common.Logger;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.MSBuild.MSBuildTasks;
using static Nuke.Common.Tools.SignTool.SignToolTasks;
using static Nuke.Common.Tools.NuGet.NuGetTasks;
using static Nuke.Common.IO.TextTasks;
using static Nuke.Common.IO.XmlTasks;
using static Nuke.Common.EnvironmentInfo;

class Build : NukeBuild
{
    private void Convert()
    {
        DotNetBuild(_ => _
            .SetProjectFile(RootDirectory / "source")
            .SetConfiguration(configuration)
            .SetProcessArgumentConfigurator(args => args.Add($"/p:Version={nugetVersion}")));
        DotNetTest(_ => _
            .SetProjectFile(testProjectFile)
            .SetConfiguration(configuration)
            .SetNoBuild(true));
        DotNetPack(_ => _
            .SetProjectFile(octopusClientFolder)
            .SetProcessArgumentConfigurator(args =>
        {
            args.Add($"/p:Version={nugetVersion}");
            args.Add("/p:NuspecFile=file.nuspec");
            return args;
        })
            .SetConfiguration(configuration)
            .SetOutputDirectory(artifactsDir)
            .SetNoBuild(true)
            .SetIncludeSymbols(false)
            .SetVerbosity(DotNetVerbosity.Normal));
        SignTool(_ => _
            .SetFiles(files)
            .SetProcessToolPath(RootDirectory / "certificates" / "signtool.exe")
            .SetTimeStampUri(new Uri("http://rfc3161timestamp.globalsign.com/advanced"))
            .SetTimeStampDigestAlgorithm(SignToolDigestAlgorithm.Sha256)
            .SetCertPath(signingCertificatePath)
            .SetPassword(signingCertificatePassword));
    }
}