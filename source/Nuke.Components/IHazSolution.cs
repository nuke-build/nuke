using System;
using System.Linq;
using Nuke.Common.ProjectModel;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    public interface IHazSolution
    {
        [Solution]
        Solution Solution => TryGetValue(() => Solution);
    }
}
