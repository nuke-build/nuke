// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Tooling;
using Serilog.Events;

namespace Nuke.Common.Tools.Npm;

[LogLevelPattern(LogEventLevel.Warning, "^(npmWARN|npm WARN)")]
[LogLevelPattern(LogEventLevel.Debug, "^(npm notice)")]
partial class NpmTasks;
