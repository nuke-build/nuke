// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverSettings
    {
        [NonSerialized]
        internal Action _testAction;

        public Action TestAction => _testAction;
    }
}
