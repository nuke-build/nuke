// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using Mono.Cecil;
using Nuke.Common;

namespace Nuke.NSwag.Generator.Utilities
{
    internal static class PropertyDefinitionExtensions
    {
        private const string c_argumentAttributeTypeFullName = "NConsole.ArgumentAttribute";

        public static CustomAttribute GetArgumentAttribute(this PropertyDefinition propertyDefinition)
        {
            ControlFlow.Assert(propertyDefinition.HasArgumentAttribute(), "typeDefinition.HasArgumentAttribute()");
            return propertyDefinition.CustomAttributes.Single(x => x.AttributeType.FullName == c_argumentAttributeTypeFullName);
        }

        public static bool HasArgumentAttribute(this PropertyDefinition propertyDefinition)
        {
            return propertyDefinition.HasCustomAttributes
                   && propertyDefinition.CustomAttributes.Any(x => x.AttributeType.FullName == c_argumentAttributeTypeFullName);
        }

        public static string GetTypeName(this PropertyDefinition propertyDefinition, CustomAttribute argumentAttribute)
        {
            if (argumentAttribute.AttributeType.FullName != c_argumentAttributeTypeFullName)
                throw new ArgumentException($"Attribute must be be of type {c_argumentAttributeTypeFullName}", nameof(argumentAttribute));

            string primitiveToLower(TypeReference type)
            {
                switch (type.Name)
                {
                    case "Boolean":
                        return "bool?";
                    case "String":
                    case "Object":
                        return "string";
                    case "Decimal":
                        return "decimal?";
                    default: return type.Name;
                }
            }

            if (propertyDefinition.PropertyType.IsArray) return $"List<{primitiveToLower(propertyDefinition.PropertyType.GetElementType())}>";

            if (propertyDefinition.Name == "Variables") return "Dictionary<string,object>";

            return primitiveToLower(propertyDefinition.PropertyType);
        }
    }
}