using System;

namespace Nuke.Common.CI
{
    public abstract class CIVariableAttribute : Attribute
    {
        public string Name { get; set; }

        public CIVariableAttribute(string name)
        {
            Name = name;
        }
    }
}
