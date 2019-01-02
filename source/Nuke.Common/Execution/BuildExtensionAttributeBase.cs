// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class BuildExtensionAttributeBase : Attribute
    {
        public virtual void PreUserCode(NukeBuild instance)
        {
        }

        public virtual void PreInitialization(NukeBuild instance)
        {
        }
    }
}
