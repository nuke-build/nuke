// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Runtime.CompilerServices;
using NullGuard;

[assembly: InternalsVisibleTo("Nuke.Common.Tests")]
[assembly: InternalsVisibleTo("Nuke.GlobalTool")]
[assembly: InternalsVisibleTo("Nuke.GlobalTool.Tests")]

[assembly: NullGuard(ValidationFlags.All)]
