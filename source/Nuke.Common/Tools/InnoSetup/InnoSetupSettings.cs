// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.InnoSetup
{
    public partial class InnoSetupSettings
    {
        private static string GetInnoSetupBool(bool? value)
        {
            return value switch
            {
                null => null,
                true => "+",
                false => "-"
            };
        }

        private string GetOutput()
        {
            return GetInnoSetupBool(Output);
        }
    }
}
