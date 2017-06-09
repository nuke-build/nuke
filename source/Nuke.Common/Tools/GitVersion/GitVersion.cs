// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    [PublicAPI]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class GitVersion : ISettingsEntity
    {
        public virtual int Major { get; set; }
        public virtual int Minor { get; set; }
        public virtual int Patch { get; set; }
        public virtual string PreReleaseTag { get; set; }
        public virtual string PreReleaseTagWithDash { get; set; }
        public virtual string PreReleaseLabel { get; set; }
        public virtual string PreReleaseNumber { get; set; }
        public virtual string BuildMetaData { get; set; }
        public virtual string BuildMetaDataPadded { get; set; }
        public virtual string FullBuildMetaData { get; set; }
        public virtual string MajorMinorPatch { get; set; }
        public virtual string SemVer { get; set; }
        public virtual string LegacySemVer { get; set; }
        public virtual string LegacySemVerPadded { get; set; }
        public virtual string AssemblySemVer { get; set; }
        public virtual string FullSemVer { get; set; }
        public virtual string InformationalVersion { get; set; }
        public virtual string BranchName { get; set; }
        public virtual string Sha { get; set; }
        public virtual string NuGetVersionV2 { get; set; }
        public virtual string NuGetVersion { get; set; }
        public virtual string NuGetPreReleaseTagV2 { get; set; }
        public virtual string NuGetPreReleaseTag { get; set; }
        public virtual string CommitsSinceVersionSource { get; set; }
        public virtual string CommitsSinceVersionSourcePadded { get; set; }
        public virtual string CommitDate { get; set; }
    }
}
