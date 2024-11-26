// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public interface IRequireTool;

public interface IRequirePathTool : IRequireTool;

public interface IRequireNuGetPackage : IRequireTool, IRequireToolWithVersion;

public interface IRequireNpmPackage : IRequireTool, IRequireToolWithVersion;

public interface IRequireAptGetPackage : IRequireTool;
