// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.SourceGenerators
{
    [Generator]
    public class StronglyTypedSolutionGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var compilation = context.Compilation;
            var allTypes = compilation.Assembly.GlobalNamespace.GetAllTypes();
            var membersWithAttributes = allTypes.SelectMany(x => x.GetMembers())
                .Where(x => x is IPropertySymbol || x is IFieldSymbol)
                .Select(x => (Member: x, AttributeData: x.GetAttributeData("global::Nuke.Common.ProjectModel.SolutionAttribute")))
                .Where(x => x.AttributeData != null).ToList();
            if (membersWithAttributes.Count == 0)
                return;

            var rootDirectory = GetRootDirectoryFrom(compilation);
            var compilationUnit = CompilationUnit()
                .AddUsings(UsingDirective(IdentifierName("Nuke.Common.ProjectModel")));

            foreach (var (member, attributeData) in membersWithAttributes)
            {
                var attributeArguments = attributeData.NamedArguments;
                if (attributeArguments.SingleOrDefault(x => x.Key == "GenerateProjects").Value.Value as bool? != true)
                    continue;

                var solutionFile = GetSolutionFileFromParametersFile(rootDirectory, member.Name);
                var solution = SolutionSerializer.DeserializeFromFile<Solution>(solutionFile);

                var classDeclaration = GetSolutionFolderDeclaration(member.Name, solution.SolutionFolders, solution.Projects, isSolution: true);
                compilationUnit = compilationUnit
                    .AddMembers(member.ContainingType.ContainingNamespace.Equals(compilation.GlobalNamespace, SymbolEqualityComparer.Default)
                        ? NamespaceDeclaration(IdentifierName(member.ContainingType.ContainingNamespace.GetFullName()))
                            .AddMembers(classDeclaration)
                        : classDeclaration);
            }

            var source = compilationUnit.NormalizeWhitespace().ToFullString();
            context.AddSource(nameof(StronglyTypedSolutionGenerator), source);
        }

        [CanBeNull]
        private ClassDeclarationSyntax GetSolutionFolderDeclaration(
            string name,
            IReadOnlyCollection<SolutionFolder> solutionFolders,
            IReadOnlyCollection<Project> projects,
            bool isSolution = false)
        {
            string GetMemberName(string name) => name
                .ReplaceRegex(@"(^[\W^\d]|[\W])", _ => "_")
                .TrimToOne("_");

            string GetSolutionFolderTypeName(string name)
                => $"_{GetMemberName(name)}";

            MemberDeclarationSyntax GetSolutionFolderPropertyDeclaration()
                => isSolution
                    ? ParseMemberDeclaration($"private {typeof(Solution).FullName} SolutionFolder => this;")
                    : ParseMemberDeclaration("private SolutionFolder SolutionFolder { get; }");

            MemberDeclarationSyntax GetSolutionFolderConstructorDeclaration()
                => ParseMemberDeclaration($"public {GetSolutionFolderTypeName(name)}(SolutionFolder solutionFolder) => SolutionFolder = solutionFolder;");

            MemberDeclarationSyntax GetProjectPropertyDeclaration(string name)
                => ParseMemberDeclaration($@"public Project {GetMemberName(name)} => SolutionFolder.GetProject(""{name}"");");

            MemberDeclarationSyntax GetSolutionFolderProperty(string name)
                => ParseMemberDeclaration(
                    $@"public {GetSolutionFolderTypeName(name)} {GetMemberName(name)} => new(SolutionFolder.GetSolutionFolder(""{name}""));");

            return ClassDeclaration(isSolution ? name : GetSolutionFolderTypeName(name)) // TODO: check for multiple solution fields
                .AddModifiers(Token(SyntaxKind.InternalKeyword))
                .When(isSolution, _ => _
                    .AddBaseListTypes(SimpleBaseType(ParseTypeName(typeof(Solution).FullName.NotNull()))))
                .AddMembers(GetSolutionFolderPropertyDeclaration())
                .When(!isSolution, _ => _
                    .AddMembers(GetSolutionFolderConstructorDeclaration()))
                .AddMembers(projects.Select(project => GetProjectPropertyDeclaration(project.Name)).ToArray())
                .AddMembers(solutionFolders.Select(x => GetSolutionFolderProperty(x.Name)).ToArray())
                .AddMembers(solutionFolders.Select(x => GetSolutionFolderDeclaration(x.Name, x.SolutionFolders, x.Projects))
                    .ToArray<MemberDeclarationSyntax>());
        }

        private static string GetSolutionFileFromParametersFile(AbsolutePath rootDirectory, string memberName)
        {
            var parametersFile = Constants.GetDefaultParametersFile(rootDirectory);
            ControlFlow.Assert(File.Exists(parametersFile), $"File.Exists({parametersFile})");
            var jobject = JObject.Parse(File.ReadAllText(parametersFile));
            var solutionRelativePath = jobject[memberName].NotNull($"Property '{memberName}' does not exist in '{parametersFile}'.").Value<string>();
            return Path.Combine(rootDirectory, solutionRelativePath);
        }

        private static AbsolutePath GetRootDirectoryFrom(Compilation compilation)
        {
            var syntaxPath = compilation.SyntaxTrees.First().FilePath;
            var startDirectory = Path.GetDirectoryName(File.Exists(syntaxPath)
                ? syntaxPath
                // For testing only
                : Directory.GetCurrentDirectory());
            return Constants.TryGetRootDirectoryFrom(startDirectory).NotNull();
        }
    }
}
