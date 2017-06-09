using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    public class Tool
    {
        [JsonIgnore]
        public string File { get; set; }

        public Reference Reference { get; set; }
        
        /// <summary>
        /// The brief help text, best taken from the project website.
        /// </summary>
        /// <remarks>
        /// This help text is copied to all involved top-level members.
        /// </remarks>
        public string Help { get; set; }
        
        /// <summary>
        /// The url to the tool's offical website.
        /// </summary>
        /// <remarks>
        /// This official url is copied to all involved top-level members.
        /// </remarks>
        public string OfficialUrl { get; set; }
        
        /// <summary>
        /// The alias.
        /// </summary>
        public Alias Alias { get; set; }

        /// <summary>
        /// The settings class.
        /// </summary>
        public SettingsClass SettingsClass { get; set; }

        /// <summary>
        /// The list of data classes.
        /// </summary>
        public List<DataClass> DataClasses { get; set; } = new List<DataClass>();
        /// <summary>
        /// The list of enumerations.
        /// </summary>
        public List<Enumeration> Enumerations { get; set; } = new List<Enumeration>();

        public override string ToString ()
        {
            return File;
        }
    }
}
