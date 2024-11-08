// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Serilog.Events;

namespace Nuke.Common.Tools.Docker;

[LogLevelPattern(LogEventLevel.Warning, "^WARNING!")]
partial class DockerTasks;
