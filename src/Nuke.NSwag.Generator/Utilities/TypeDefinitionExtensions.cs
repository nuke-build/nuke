// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Nuke.Common;

namespace Nuke.NSwag.Generator.Utilities
{
    internal static class TypeDefinitionExtensions
    {
        private const string c_consoleCommandInterfaceFullName = "NConsole.IConsoleCommand";
        private const string c_commandAttributeTypeFullName = "NConsole.CommandAttribute";

        public static string GetPropertySetName (this TypeDefinition typeDefinition)
        {
            var indexOfGenericSeperator = typeDefinition.Name.IndexOf(value: '`');
            var name = indexOfGenericSeperator < 0
                    ? typeDefinition.Name
                    : typeDefinition.Name.Substring(startIndex: 0, length: indexOfGenericSeperator);
            name =  name.Replace("Base", string.Empty);
            return char.ToLower(name[index: 0]) + name.Substring(startIndex: 1);
        }

        public static bool IsCommandBaseClass (this TypeDefinition typeDefinition)
        {
            if (!typeDefinition.IsAbstract || typeDefinition.IsInterface) return false;
            if (typeDefinition.Interfaces.Any(y => y.InterfaceType.FullName == c_consoleCommandInterfaceFullName)) return true;
            return typeDefinition.BaseType != null && IsCommandBaseClass(typeDefinition.BaseType.Resolve());
        }

        public static List<string> GetCommonPropertySets (this TypeDefinition typeDefinition)
        {
            var commonPropertySets = new List<string>();
            if (typeDefinition.IsCommandBaseClass()) commonPropertySets.Add(typeDefinition.GetPropertySetName());
            if (typeDefinition.BaseType != null) commonPropertySets.AddRange(GetCommonPropertySets(typeDefinition.BaseType.Resolve()));
            return commonPropertySets;
        }

        public static CustomAttribute GetCommandAttribute (this TypeDefinition typeDefinition)
        {
            ControlFlow.Assert(typeDefinition.HasCommandAttribute(), "typeDefinition.HasCommandAttribute()");
            return typeDefinition.CustomAttributes.Single(x => x.AttributeType.FullName == c_commandAttributeTypeFullName);
        }

        public static bool HasCommandAttribute (this TypeDefinition typeDefinition)
        {
            return typeDefinition.HasCustomAttributes
                   && typeDefinition.CustomAttributes.Any(x => x.AttributeType.FullName == c_commandAttributeTypeFullName);
        }
    }
}
