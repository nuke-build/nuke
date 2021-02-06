using System;

namespace Nuke.Common.Tools.CorFlags
{
    partial class CorFlagsSettings
    {
        private string GetILOnly()
        {
            return ToPlusMinus(ILOnly);
        }

        private string GetRequires32Bit()
        {
            return ToPlusMinus(Requires32Bit);
        }

        private string GetPrefers32Bit()
        {
            return ToPlusMinus(Prefers32Bit);
        }

        private string ToPlusMinus(bool? value)
        {
            return value switch
            {
                true => "+",
                false => "-",
                null => null
            };
        }
    }
}
