using System;

namespace Nuke.Common.CI
{
    public abstract class CIVariableAttribute : Attribute
    {
        public string Name { get; set; }

        protected CIVariableAttribute()
        { }

        protected CIVariableAttribute(string name)
        {
            Name = name;
        }
    }
}
