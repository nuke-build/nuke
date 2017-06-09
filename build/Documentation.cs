// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Core;
using Nuke.Core.BuildServers;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using static Nuke.Core.Logger;

public static class Documentation
{
    public static void WriteCustomToc (string tocFile, IEnumerable<string> assemblyFiles)
    {
        var types = assemblyFiles
                .Distinct(Path.GetFileName)
                .Where(x => !x.Contains("Tests"))
                .ForEachLazy(x => Info($"Loading {x}..."))
                .SelectMany(x => Assembly.LoadFrom(x).GetTypes())
                .Select(x => new { Kind = GetKind(x), Type = x })
                .Where(x => x.Kind != Kind.None)
                .ForEachLazy(x => Trace($"  - Found {x.Kind}: {x.Type}"))
                .ToLookup(x => x.Kind, x => x.Type);

        File.WriteAllText(tocFile,
            new StringBuilder()
                    .WriteBlock("Entry", types[Kind.Entry])
                    .WriteBlock("Servers", types[Kind.Server])
                    .WriteBlock("Common", types[Kind.Common])
                    .WriteBlock("Addins", types[Kind.Addin])
                    .ToString());
    }

    enum Kind
    {
        None,
        Entry,
        Server,
        Common,
        Addin
    }

    static Kind GetKind (Type type)
    {
        if (IsEntryType(type))
            return Kind.Entry;
        if (type.IsServerType())
            return Kind.Server;
        if (type.HasIconClassAttributes())
            return Kind.Common;

        return Kind.None;
    }


    static StringBuilder WriteBlock (this StringBuilder builder, string text, IEnumerable<Type> types)
        => builder
                .AppendLine($"- separator: {text}")
                .ForEach(types.OrderBy(x => x.Name), x => builder.WriteType(x));

    static StringBuilder ForEach<T> (
        this StringBuilder builder,
        IEnumerable<T> enumerable,
        Action<T> builderAction)
    {
        foreach (var item in enumerable)
            builderAction(item);
        return builder;
    }

    static StringBuilder WriteType (this StringBuilder builder, Type type)
        => builder
                .AppendLine($"- uid: {type.FullName}")
                .AppendLine($"  name: {type.GetName()}")
                .AppendLine($"  icon: {type.GetIconClassText()}");


    static bool IsEntryType (this Type type)
        => type.DescendantsAndSelf(x => x.BaseType).Any(x => x.Name == "Build")
           || new[]
              {
                  typeof(ControlFlow).Name,
                  typeof(EnvironmentInfo).Name,
                  typeof(Logger).Name,
                  typeof(ProcessTasks).Name,
                  typeof(DefaultSettings).Name
              }.Contains(type.Name);

    static bool IsServerType (this Type type)
        => type.GetAttribute<BuildServerAttribute>() != null;

    static bool HasIconClassAttributes (this Type type)
        => type.GetAttribute<IconClassAttribute>() != null;

    static string GetName (this Type type)
        => type.Name.EndsWith("Tasks") ? type.Name.Substring(startIndex: 0, length: type.Name.Length - "Tasks".Length) : type.Name;

    static string GetIconClassText (this Type type)
    {
        var iconClass = type.GetAttribute<IconClassAttribute>()?.ConstructorArguments[index: 1].Value.ToString();
        if (iconClass != null)
            return iconClass;
        if (type.IsEntryType())
            return "star-full";
        if (type.IsServerType())
            return "server";

        return "power-cord2";
    }

    [CanBeNull]
    static CustomAttributeData GetAttribute<T> (this Type type)
        => type.GetCustomAttributesData().SingleOrDefault(x => x.AttributeType.Name == typeof(T).Name)
           ?? type.Assembly.GetCustomAttributesData()
                   .Where(x => x.AttributeType.Name == typeof(T).Name)
                   .SingleOrDefault(x => ((Type) x.ConstructorArguments.First().Value).Name == type.Name);
}
