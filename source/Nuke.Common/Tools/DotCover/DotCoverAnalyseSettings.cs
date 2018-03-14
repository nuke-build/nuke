// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;

namespace Nuke.Common.Tools.DotCover
{
    public partial class DotCoverAnalyseSettings
    {
        [NonSerialized]
        internal Action TestActionInternal;

        public Action TestAction => TestActionInternal;

    }
}
