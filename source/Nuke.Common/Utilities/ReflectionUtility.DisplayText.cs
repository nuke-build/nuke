// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public static string GetDisplayName(this Type type)
        {
            return type.DescendantsAndSelf(x => x.DeclaringType).Reverse().Select(x => x.GetDisplayShortName()).Join(".");
        }

        public static string GetDisplayShortName(this Type type)
        {
            return type.GetDisplayShortName(tupleNames: null);
        }

        public static string GetDisplayShortName(this MemberInfo member)
        {
            return member.Name.Split('.').Last();
        }

        internal static string GetDisplayShortName(this Type type, IList<string> tupleNames)
        {
            var aliases = new Dictionary<Type, string>
                          {
                              { typeof(byte), "byte" },
                              { typeof(sbyte), "sbyte" },
                              { typeof(short), "short" },
                              { typeof(ushort), "ushort" },
                              { typeof(int), "int" },
                              { typeof(uint), "uint" },
                              { typeof(long), "long" },
                              { typeof(ulong), "ulong" },
                              { typeof(float), "float" },
                              { typeof(double), "double" },
                              { typeof(decimal), "decimal" },
                              { typeof(object), "object" },
                              { typeof(bool), "bool" },
                              { typeof(char), "char" },
                              { typeof(string), "string" },
                              { typeof(void), "void" }
                          };

            if (aliases.TryGetValue(type, out var alias))
                return alias;

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                return $"{underlyingType.GetDisplayShortName(tupleNames)}?";

            if (type.IsGenericType)
            {
                string PopName()
                {
                    try
                    {
                        var name = tupleNames.First();
                        return name != null ? $"{name} " : string.Empty;
                    }
                    finally
                    {
                        tupleNames.RemoveAt(0);
                    }
                }

                var typeName = type.Name.Substring(startIndex: 0, type.Name.IndexOf('`'));
                return typeName != nameof(ValueTuple) || tupleNames == null
                    ? $"{typeName}<{type.GetGenericArguments().Select(x => x.GetDisplayShortName(tupleNames)).JoinComma()}>"
                    : $"({type.GetGenericArguments().Select(x => $"{PopName()}{x.GetDisplayShortName(tupleNames)}").JoinComma()})";
            }

            if (type.IsArray)
                return $"{type.GetElementType().GetDisplayShortName(tupleNames)}[{new string(c: ',', type.GetArrayRank() - 1)}]";

            return type.Name;
        }

        public static string GetDisplayText(this ParameterInfo parameter)
        {
            var tupleNames = parameter.GetCustomAttribute<TupleElementNamesAttribute>()?.TransformNames.ToList();
            var parameterType = !(parameter.IsOut || parameter.ParameterType.IsByRef)
                ? parameter.ParameterType.GetDisplayShortName(tupleNames)
                : parameter.ParameterType.GetElementType().GetDisplayShortName(tupleNames);

            var modifier = parameter.IsExtensionParameter()
                ? "this "
                : parameter.IsOut
                    ? "out "
                    : parameter.IsIn
                        ? "in "
                        : parameter.ParameterType.IsByRef
                            ? "ref "
                            : string.Empty;
            var defaultValue = parameter.HasDefaultValue ? $" = {parameter.DefaultValue ?? "null"}" : string.Empty;

            return $"{modifier}{parameterType} {parameter.Name}{defaultValue}";
        }

        public static string GetDisplayText(this MemberInfo member)
        {
            if (member is Type type)
                return type.GetDisplayShortName();

            var parameterList = member is MethodBase methodBase
                ? $"({methodBase.GetParameters().Select(x => x.GetDisplayText()).JoinComma()})"
                : string.Empty;

            var tupleNamesAttribute = member is MethodInfo method
                ? method.ReturnTypeCustomAttributes
                    .GetCustomAttributes(typeof(TupleElementNamesAttribute), inherit: true)
                    .Cast<TupleElementNamesAttribute>()
                    .FirstOrDefault()
                : member.GetCustomAttribute<TupleElementNamesAttribute>();
            var memberType = !(member is ConstructorInfo)
                ? $" : {member.GetMemberType().GetDisplayShortName(tupleNamesAttribute?.TransformNames.ToList())}"
                : string.Empty;

            return $"{member.Name}{parameterList}{memberType}";
        }
    }
}
