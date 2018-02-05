// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.IO;
using Nuke.Core.Tooling;

[assembly: IconClass(typeof(ControlFlow), "footprint")]
[assembly: IconClass(typeof(EnvironmentInfo), "chip")]
[assembly: IconClass(typeof(FileSystemTasks), "folder-open")]
[assembly: IconClass(typeof(Logger), "quill4")]
[assembly: IconClass(typeof(NukeBuild), "heart3")]
[assembly: IconClass(typeof(ParameterAttribute), "syringe2")]
[assembly: IconClass(typeof(PathConstruction), "price-tag2")]
[assembly: IconClass(typeof(ProcessTasks), "terminal")]
[assembly: IconClass(typeof(SerializationTasks), "transmission2")]
[assembly: IconClass(typeof(TextTasks), "file-text3")]
[assembly: IconClass(typeof(XmlTasks), "file-empty2")]

#if !NETCORE
[assembly: IconClass(typeof(FtpTasks), "sphere2")]
[assembly: IconClass(typeof(HttpTasks), "sphere2")]
#endif
