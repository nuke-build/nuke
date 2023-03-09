// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public const BindingFlags All = Static | Instance | BindingFlags.FlattenHierarchy;

        public const BindingFlags Instance = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        public const BindingFlags Static = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

        [CanBeNull]
        public static object GetDefaultValue(this Type type)
        {
            return type.IsNullableType() ? null : Activator.CreateInstance(type);
        }

        public static bool IsNullableType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) != null ||
                   type == typeof(string) ||
                   type.IsClass ||
                   type.IsArray;
        }

        public static Type GetNullableType(this Type type)
        {
            return type.IsNullableType() ? type : typeof(Nullable<>).MakeGenericType(type);
        }

        public static bool IsCollectionLike(this Type type)
        {
            return type != typeof(string) &&
                   new[] { type }.Concat(type.GetInterfaces())
                       .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        public static T[] GetEnumValues<T>(this Type type)
        {
            return type.GetEnumValues().Cast<T>().ToArray();
        }

        public static bool HasCustomAttribute<T>(this MemberInfo member)
            where T : Attribute
        {
            return member.GetCustomAttribute<T>() != null;
        }

        public static bool HasCustomAttribute<T>(this ParameterInfo parameter)
            where T : Attribute
        {
            return parameter.GetCustomAttribute<T>() != null;
        }

        public static Type GetMemberType(this MemberInfo member)
        {
            return member switch
            {
                FieldInfo fieldInfo => fieldInfo.FieldType,
                PropertyInfo propertyInfo => propertyInfo.PropertyType,
                MethodInfo methodInfo => methodInfo.ReturnType,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static Type GetScalarType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) is { } underlyingType
                ? underlyingType
                : type.IsArray
                    ? type.GetElementType()
                    : type.IsCollectionLike()
                        ? type.GetGenericArguments().Single()
                        : type;
        }

        public static bool IsPublic(this MemberInfo member)
        {
            return member switch
            {
                Type type => type.IsPublic,
                ConstructorInfo constructor => constructor.IsPublic,
                FieldInfo field => field.IsPublic,
                MethodInfo method => method.IsPublic,
                PropertyInfo property => property.GetMethod.IsPublic,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsFamily(this MemberInfo member)
        {
            return member switch
            {
                ConstructorInfo constructor => constructor.IsFamily,
                FieldInfo field => field.IsFamily,
                MethodInfo method => method.IsFamily,
                PropertyInfo property => property.GetMethod.IsFamily,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsAssembly(this MemberInfo member)
        {
            return member switch
            {
                ConstructorInfo constructor => constructor.IsAssembly,
                FieldInfo field => field.IsAssembly,
                MethodInfo method => method.IsAssembly,
                PropertyInfo property => property.GetMethod.IsAssembly,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsStatic(this MemberInfo member)
        {
            return member switch
            {
                ConstructorInfo constructor => constructor.IsStatic,
                FieldInfo field => field.IsStatic,
                MethodInfo method => method.IsStatic,
                PropertyInfo property => property.GetMethod.IsStatic,
                _ => throw new NotSupportedException(member.ToString())
            };
        }

        public static bool IsExtensionParameter(this ParameterInfo parameter)
        {
            return parameter.Member is MethodInfo method &&
                   method.HasCustomAttribute<ExtensionAttribute>() &&
                   method.GetParameters().First() == parameter;
        }

        public static bool IsExplicit(this MemberInfo member)
        {
            return member.Name.Contains(".");
        }

        public static string GetPossibleExplicitName(this MemberInfo member)
        {
            return $"{member.DeclaringType.NotNull().FullName.NotNull().Replace("+", ".")}.{member.Name}";
        }

        public static MemberInfo GetImplementedOrInterfaceMember(this MemberInfo member, Type classType)
        {
            Assert.True(classType.IsClass);
            return member.DeclaringType != classType
                ? classType.GetMember(member.Name).SingleOrDefault() ??
                  classType.GetMember(member.GetPossibleExplicitName(), Instance).SingleOrDefault() ??
                  member
                : member;
        }

        public static IEnumerable<MemberInfo> GetAllMembers(
            this Type buildType,
            Func<MemberInfo, bool> filter,
            BindingFlags bindingFlags,
            bool allowAmbiguity,
            bool filterQuasiOverridden = false)
        {
            var interfaceMembersByName = buildType.GetInterfaces()
                .SelectMany(x => x.GetMembers(bindingFlags))
                .Where(filter)
                .Where(x => buildType.GetMember(x.Name).SingleOrDefault() == null).ToLookup(x => x.GetDisplayShortName());
            var classMembers = buildType
                .GetMembers(bindingFlags)
                .Where(filter)
                .Where(x => !x.IsExplicit()).ToDictionary(x => x.Name);
            var removeMembers = new List<MemberInfo>();

            foreach (var interfaceMembers in interfaceMembersByName)
            {
                var memberName = interfaceMembers.Key;
                var memberType = interfaceMembers.First().MemberType;
                var classMember = classMembers.GetValueOrDefault(memberName);

                if (filterQuasiOverridden && classMember == null && interfaceMembers.Count() > 1)
                {
                    var orderedProperties = interfaceMembers
                        .TSort(x => interfaceMembers.Where(y => y.DeclaringType.NotNull().IsAssignableFrom(x.DeclaringType))).ToList();

                    var mostBaseType = orderedProperties.First().DeclaringType.NotNull();
                    var derivedTypes = orderedProperties.Skip(1).Select(x => x.DeclaringType);
                    if (derivedTypes.All(x => mostBaseType.IsAssignableFrom(x)))
                    {
                        removeMembers.AddRange(orderedProperties.Take(orderedProperties.Count - 1));
                        continue;
                    }
                }

                // if (filterQuasiOverridden && classMember != null && classMember.IsPublic())
                // {
                //     removeMembers.AddRange(interfaceMembers);
                //     continue;
                // }

                Assert.True(allowAmbiguity || interfaceMembers.Count() == 1 || classMember != null,
                    new[] { $"{memberType} '{memberName}' must be implemented explicitly because it is inherited from multiple interfaces:" }
                        .Concat(interfaceMembers.Select(x => $" - {x.DeclaringType.NotNull().Name}"))
                        .JoinNewLine());

                Assert.True(allowAmbiguity || classMember == null || classMember.IsPublic(),
                    new[] { $"{memberType} '{memberName}' must be marked public to override inherited member from:" }
                        .Concat(interfaceMembers.Select(x => $" - {x.DeclaringType.NotNull().Name}"))
                        .JoinNewLine());
            }

            return classMembers.Values
                .Concat(interfaceMembersByName.SelectMany(x => x).Select(x => x.GetImplementedOrInterfaceMember(buildType)))
                .Except(removeMembers)
                .Where(filter).ToList();
        }
    }
}
