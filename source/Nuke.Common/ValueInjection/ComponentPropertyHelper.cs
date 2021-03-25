// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Nuke.Common.ValueInjection
{
    /// <summary>
    /// Adds ability for Nuke Components to add stateful instance members, and obtain values from parameters and value injectors
    /// </summary>
    /// 
    /// <example>
    /// <code>
    /// interface IMyNukeComponent : INukeBuild
    /// {
    ///     [GitVersion] GitVersion Versioning => this.Get(); // Value injected readonly member
    ///     [Parameter] string MyParameter1 => this.Get(); // Parameter 
    ///     [Parameter] string MyParameter2 => this.Get("value"); // Parameter with default value
    /// 
    ///     // equivalent of a field on concrete Build class that can be used to pass state across targets
    ///     string StatefulMember 
    ///     { 
    ///         get => this.Get(); 
    ///         set => this.Set(value); 
    ///     } 
    ///  }
    /// </code>
    /// </example>
    public static class ComponentPropertyHelper
    {
        static readonly ConditionalWeakTable<object, Dictionary<PropertyInfo, object>> InstanceProperties = new();

        public static void Set<T>(this INukeBuild instance, T val)
        {
            var property = GetProperty(2);
            instance.DoSet(property, val);
        }

        private static void DoSet<T>(this INukeBuild instance, PropertyInfo property, T val)
        {
            var properties = InstanceProperties.GetOrCreateValue(instance);

            if (EqualityComparer<T>.Default.Equals(val, default(T)))
                properties!.Remove(property);
            else
                properties![property] = val;
        }
        
        public static T Get<T>(this INukeBuild instance, T defaultValue = default) => instance.DoGet(defaultValue);

        public static dynamic Get(this INukeBuild instance) => instance.DoGet(null);

        private static dynamic DoGet(this INukeBuild instance, object defaultValue = null)
        {
            var property = GetProperty(3);
            if (InstanceProperties.TryGetValue(instance, out var properties) && 
                properties.TryGetValue(property, out var val))
                return val;
            var attribute = property.GetCustomAttribute<ValueInjectionAttributeBase>();
            if (attribute != null)
            {
                val = attribute.TryGetValue(property, instance: instance);
                if (val != null)
                {
                    instance.DoSet(property, val);
                    return val;
                }
            }

            val = property.PropertyType.IsValueType ? Activator.CreateInstance(property.PropertyType) : defaultValue;
            instance.DoSet(property, val);
            return val;
        }
        
        /// <summary>
        /// Retrieves property based on the assumption that the call was made from a property getter or setter at <param name="depth"/> stack frame offset 
        /// </summary>
        static PropertyInfo GetProperty(int depth)
        {
            var method = new StackTrace().GetFrame(depth).GetMethod();
            var match = Regex.Match(method.Name, "^(get|set)_(?<name>.+)");
            if (!match.Success)
                throw new InvalidOperationException("Must be called from a property getter/setter");
            var propertyName = match.Groups["name"].Value;
            var property = method.DeclaringType.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            return property;
        }
    }

}
