// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;

namespace Nuke.NSwag.Generator
{
    public interface ISpecificationParser : IDisposable
    {
        void Populate (Tool tool);
    }

    public abstract class SpecificationParser : ISpecificationParser
    {
        public abstract void Dispose ();
        protected abstract List<string> ParseReferences ();
        protected abstract List<Task> ParseTasks ();

        protected virtual List<Enumeration> ParseEnumerations ()
        {
            return new List<Enumeration>();
        }

        protected virtual List<Property> ParseCommonTaskProperties ()
        {
            return new List<Property>();
        }

        protected virtual Dictionary<string, List<Property>> ParseCommonTaskPropertySets ()
        {
            return new Dictionary<string, List<Property>>();
        }

        protected virtual List<DataClass> ParseDataClasses ()
        {
            return new List<DataClass>();
        }

        public void Populate (Tool tool)
        {
            tool.References = ParseReferences();
            tool.Tasks = ParseTasks();
            tool.CommonTaskProperties = ParseCommonTaskProperties();
            tool.CommonTaskPropertySets = ParseCommonTaskPropertySets();
            tool.DataClasses = ParseDataClasses();
            tool.Enumerations = ParseEnumerations();
        }
    }
}