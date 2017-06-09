using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.ToolGenerator.Model
{
    public class Alias
    {
        // TODO: summary
        public bool SkipAttributes { get; set; }
        // TODO: summary
        [CanBeNull]
        public string IconClass { get; set; }

        /// <summary>
        /// The name of the entry class. For instance <i>XunitTasks</i> which could be used for multiple entry <see cref="Alias"/>es, like <i>Xunit1</i> and <i>Xunit2</i>.
        /// </summary>
        /// <remarks>
        /// The postfix <i>Tasks</i> is automatically appended.
        /// </remarks>
        public string TaskName { get; set; }
        
        // TODO: summary
        public string MethodPostfix { get; set; }

        /// <summary>
        /// If set to <v>true</v>, will generate a call to <c>AssertProcess</c> which needs to be implemented in a partial class definition.
        /// Otherwise, just asserts the exit code to be zero.
        /// </summary>
        public bool CustomAssertion { get; set; }
     
        /// <summary>
        /// The related settings class.
        /// </summary>
        public string SettingsClass { get; set; }
        /// <summary>
        /// A list dominant properties of the <see cref="SettingsClass"/> that are exposed over dedicated overloads. 
        /// </summary>
        /// <remarks>
        /// Most important properties comes first.
        /// </remarks>
        public List<string> OverloadArguments { get; set; } = new List<string>();
    }
}