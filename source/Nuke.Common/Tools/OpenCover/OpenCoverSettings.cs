// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverSettings
    {
        [NonSerialized]
        internal Action TestActionInternal;

        public Action TestAction => TestActionInternal;
    }
}
