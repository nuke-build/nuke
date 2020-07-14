using System;

namespace Nuke.Common.CI
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AzurePipelinesVariableAttribute : CIVariableAttribute
    {
        public AzurePipelinesVariableAttribute()
            : base()
        { }

        public AzurePipelinesVariableAttribute(string name)
            : base(name)
        { }
    }
}
