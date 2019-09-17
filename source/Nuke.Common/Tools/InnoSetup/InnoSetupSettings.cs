// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

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
