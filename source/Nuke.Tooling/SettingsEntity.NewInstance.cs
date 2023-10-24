// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling;

[PublicAPI]
public static partial class SettingsEntityExtensions
{
    public static T NewInstance<T>(this T settingsEntity)
        where T : ISettingsEntity
    {
        var newInstance = (T)CloneUsingReflection(settingsEntity);
        if (newInstance is ToolSettings toolSettings)
        {
            toolSettings.ProcessArgumentConfigurator = ((ToolSettings)(object)settingsEntity).ProcessArgumentConfigurator;
            toolSettings.ProcessLogger = ((ToolSettings)(object)settingsEntity).ProcessLogger;
            toolSettings.ProcessExitHandler = ((ToolSettings)(object)settingsEntity).ProcessExitHandler;
        }

        return newInstance;
    }

    internal static object CloneUsingReflection(object original)
    {
        if (original == null)
        {
            return null;
        }

        // we have to use the runtime type of the object, not the declared type
        var type = original.GetType();

        // known-blittable types
        if (type.IsPrimitive || type.IsEnum || type == typeof(string))
        {
            return original;
        }

        if (type.IsArray)
        {
            if (type.GetArrayRank() != 1)
            {
                throw new NotSupportedException("Multidimensional arrays not supported");
            }

            var originalArray = (Array)original;
            var arrayElementType = type.GetElementType()!;
            var clone = Array.CreateInstance(arrayElementType, originalArray.Length);
            for (var i = 0; i < originalArray.Length; i++)
            {
                clone.SetValue(CloneUsingReflection(originalArray.GetValue(i)), i);
            }

            return clone;
        }
        else
        {
            // first check if it's a Delegate as we can't clone those
            var baseType = type.BaseType;
            while (baseType?.BaseType != typeof(object) && baseType?.BaseType != null)
            {
                baseType = baseType.BaseType;
            }

            if (baseType != null && baseType == typeof(Delegate))
            {
                return null;
            }

            // now clone using GetSafeUninitializedObject
            var clone = FormatterServices.GetSafeUninitializedObject(type);
            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                // don't need to iterate over Properties as Fields will include the backing stores for any properties
                if (field.GetCustomAttribute(typeof(NonSerializedAttribute)) != null)
                {
                    continue; // skip NonSerialized fields
                }

                var value = field.GetValue(original);
                field.SetValue(clone, CloneUsingReflection(value));
            }

            return clone;
        }
    }
}
