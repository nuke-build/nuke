// Copyright Matthias Koch 2017.
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

        private string GetPackageExecutable ()
        {
            throw new NotImplementedException();
        }
    }
}
