// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.DocFx;
using Nuke.Common.Tools.DotCover;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.DupFinder;
using Nuke.Common.Tools.GitLink2;
using Nuke.Common.Tools.GitLink3;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.Nunit3;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Paket;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Tools.Xunit2;
using Nuke.Core.Execution;

[assembly: IconClass(typeof(DefaultSettings), "equalizer")]
[assembly: IconClass(typeof(DocFxTasks), "book")]
[assembly: IconClass(typeof(DotCoverTasks), "shield2")]
[assembly: IconClass(typeof(DotNetTasks), "fire")]
[assembly: IconClass(typeof(DupFinderTasks), "code")]
[assembly: IconClass(typeof(GitLink2Tasks), "link")]
[assembly: IconClass(typeof(GitLink3Tasks), "link")]
[assembly: IconClass(typeof(GitRepository), "git")]
[assembly: IconClass(typeof(GitVersionTasks), "podium")]
[assembly: IconClass(typeof(InspectCodeTasks), "code")]
[assembly: IconClass(typeof(MSBuildTasks), "download2")]
[assembly: IconClass(typeof(NuGetTasks), "box")]
[assembly: IconClass(typeof(Nunit3Tasks), "bug2")]
[assembly: IconClass(typeof(OpenCoverTasks), "shield2")]
[assembly: IconClass(typeof(PaketTasks), "box")]
[assembly: IconClass(typeof(ReportGeneratorTasks), "flag3")]
[assembly: IconClass(typeof(SerializationTasks), "barcode")]
[assembly: IconClass(typeof(TextTasks), "file-text3")]
[assembly: IconClass(typeof(XmlTasks), "file-empty2")]
[assembly: IconClass(typeof(Xunit2Tasks), "bug2")]

#if !NETCORE
[assembly: IconClass(typeof(FtpTasks), "sphere2")]
[assembly: IconClass(typeof(HttpTasks), "sphere2")]
#endif
