using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using NConsole;
using Newtonsoft.Json;
using NSwag.Commands;
using NSwag.Commands.SwaggerGeneration;
using Nuke.CodeGeneration;
using Nuke.CodeGeneration.Model;
using Nuke.Common.Git;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;
using Nuke.Core.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Core.IO.FileSystemTasks;
using static Nuke.Core.IO.PathConstruction;

class Build : NukeBuild
{
    public static int Main () => Execute<Build>(x => x.Pack);

    const string Source = "https://www.myget.org/F/nuke-plugins/api/v2/package";

    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;
    [Parameter] readonly string MyGetApiKey;

    Target Clean => _ => _
            .Executes(() =>
            {
                DeleteDirectories(GlobDirectories(SourceDirectory, "**/bin", "**/obj"));
                EnsureCleanDirectory(OutputDirectory);
            });

    Target Restore => _ => _
            .DependsOn(Clean)
            .Executes(() =>
            {
                DotNetRestore(s => DefaultDotNetRestore);
            });

    AbsolutePath MetaDataDirectory => SourceDirectory / "Nuke.NSwag" / "metadata";
    string GenerationDirectory => SourceDirectory / "Nuke.NSwag";

    Target Generate => _ => _
        .Executes(() =>
        {
            var assembly = AppDomain.CurrentDomain.Load("Nswag.Commands");
            var commandClasses = assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0);
            var enumTypes = new HashSet<Type>();
            var tool = new Tool
            {
                Name = "NSwag",
                Help = "The project combines the functionality of Swashbuckle (Swagger generation) and AutoRest (client generation) in one toolchain."
                        + " This way a lot of incompatibilites can be avoided and features which are not well described by the Swagger specification"
                        + " or JSON Schema are better supported (e.g. <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Inheritance\">inheritance</a>,"
                        + " <a href=\"https://github.com/NJsonSchema/NJsonSchema/wiki/Enums\">enum</a> and reference handling). "
                        + "The NSwag project heavily uses <a href=\"http://njsonschema.org/\">NJsonSchema for .NET</a> for JSON Schema handling and"
                        + " C#/TypeScript class/interface generation.",
                CustomExecutable = true,
                References = new List<string>(),
                License = new[]
            {
                "Copyright Sebastian Karasek 2017.",
                "Distributed under the MIT License.",
                "https://github.com/arodus/nuke-nswag/blob/master/LICENSE"
            },
                OfficialUrl = "https://github.com/RSuter/NSwag",
                Tasks = new List<Task>(),
                Enumerations = new List<Enumeration>()
            };

            commandClasses.ForEach(commandType =>
            {
                var referenceUrl = "https://raw.githubusercontent.com/RSuter/NSwag/master/src/NSwag.Commands"
                                   + commandType.Namespace.Split('.').Skip(1)
                                       .Aggregate("", (current, next) => $"{current}/{next}")
                                   + $"/{commandType.Name}.cs";
                tool.References.Add(referenceUrl);
                var commandAttribute = commandType.GetCustomAttribute<CommandAttribute>(false);

                var postfix = commandAttribute.Name
                    .Replace("-", "")
                    .Replace("schema", "Schema")
                    .Replace("tsc", "Tsc")
                    .Replace("json", "Json")
                    .Replace("client", "Client")
                    .Replace("aspnetcore", "AspNetCore")
                    .Replace("swagger", "Swagger")
                    .Replace("version", "Version")
                    .Replace("list", "List")
                    .Replace("types", "Types")
                    .Replace("controllers", "Controllers")
                    .Replace("webapi", "WebApi")
                    .Replace("to", "To")
                    .Replace("cs", "Cs");
                postfix = char.ToUpper(postfix[0]) + postfix.Substring(1);
                var isPascalCase = Regex.Match(postfix, "^[A-Z][a-z0-9]+(?:[A-Z][a-z0-9]+)*$").Success;
                ControlFlow.Assert(isPascalCase, $"{postfix} is not in pascal case.");

                var task = new Task
                {
                    Postfix = postfix,
                    Help = commandAttribute.Description,
                };
                var settingsClass = new SettingsClass
                {
                    Task = task,
                    Tool = tool,
                    BaseClass = "NSwagSettings",
                    Properties = new List<Property>()
                };


                var argumentProperties = commandType.GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetCustomAttributes(typeof(ArgumentAttribute), false).Length > 0);

                argumentProperties.ForEach(argumentProperty =>
                {
                    var argumentAttribute = argumentProperty.GetCustomAttribute<ArgumentAttribute>(false);



                    var property = new Property
                    {
                        Name = (argumentAttribute.Name ?? argumentProperty.Name).Replace("Namespace", "TargetNamespace"),
                        Help = argumentAttribute.Description,
                        Type = argumentProperty.PropertyType.Name.ToString().Replace("String", "string").Replace("Object", "string").Replace("Boolean","bool").Replace("Decimal","string"),
                        Format = argumentAttribute.Name == null ? "{value}" : $"/{char.ToLower(argumentAttribute.Name[0])}{argumentAttribute.Name.Substring(1)}:\\\"{{value}}\\\"",
                        
                    };
                    if (argumentProperty.PropertyType.IsArray)
                    {
                        property.Separator = ',';
                    }
                    if (argumentProperty.PropertyType.IsEnum)
                    {
                        enumTypes.Add(argumentProperty.PropertyType);
                    }
                    settingsClass.Properties.Add(property);
                });

                task.SettingsClass = settingsClass;
                tool.Tasks.Add(task);
            });
            enumTypes.ForEach(enumType =>
            {
                var enumeration = new Enumeration
                {
                    Name = enumType.Name,
                    Values = new List<string>()
                };
                foreach (var value in Enum.GetValues(enumType))
                {
                    enumeration.Values.Add(value.ToString());
                }
                tool.Enumerations.Add(enumeration);
            });

            if (!Directory.Exists(MetaDataDirectory)) Directory.CreateDirectory(MetaDataDirectory);
            File.WriteAllText(MetaDataDirectory / "NSwag.json", JsonConvert.SerializeObject(tool, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            }));
            CodeGenerator.GenerateCode(MetaDataDirectory,GenerationDirectory,false,"Nuke.NSwag");
        });
        
    Target Compile => _ => _
            .DependsOn(Restore, Generate)
            .Executes(() =>
            {
                DotNetBuild(s => DefaultDotNetBuild);
            });

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            DotNetPack(s => DefaultDotNetPack);
        });

    Target Push => _ => _
        .DependsOn(Pack)
        .Requires(() => MyGetApiKey != null, () => GitRepository.Branch == "master" || GitRepository.Branch == "develop")
        .OnlyWhen(() => GitRepository.Branch == "master")
        .Executes(() =>
        {
            GlobFiles(OutputDirectory,"*.nupkg").NotEmpty()
                .Where(f => !f.EndsWith("symbols.nupkg"))
                .ForEach(p => DotNetNuGetPush(c => c
                .SetSource(Source)
                .SetApiKey(MyGetApiKey)
                .SetTargetPath(p)));
        });
}
