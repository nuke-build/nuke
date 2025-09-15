// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.OctoVersion;

partial class OctoVersionTasks
{
    protected override object GetResult<T>(ToolOptions options, IReadOnlyCollection<Output> output)
    {
        if (options is OctoVersionGetVersionSettings getVersion)
        {
            Assert.FileExists(getVersion.OutputJsonFile);
            try
            {
                var file = (AbsolutePath) getVersion.OutputJsonFile;
                return file.ReadJson<OctoVersionInfo>(new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() });
            }
            catch (Exception exception)
            {
                throw new Exception($"Cannot parse {nameof(OctoVersion)} output from {getVersion.OutputJsonFile.SingleQuote()}.", exception);
            }
        }

        return null;
    }
}

[PublicAPI]
public record OctoVersionInfo(
    int? Major,
    int? Minor,
    int? Patch,
    string PreReleaseTag,
    string PreReleaseTagWithDash,
    string BuildMetaData,
    string BuildMetadataWithPlus,
    string MajorMinorPatch,
    string NuGetCompatiblePreReleaseWithDash,
    string FullSemVer,
    string InformationalVersion,
    string NuGetVersion);
