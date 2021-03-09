// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Text;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Xunit;

namespace Nuke.SourceGenerators.Tests
{
    public class SolutionProjectsAsPropertiesGeneratorTest
    {

        [Fact]
        public async Task TestGenerateProjectMembers()
        {
            // Given
            var sourceCode = @"
using Nuke.Common;
using Nuke.Common.ProjectModel;

partial class Build : NukeBuild
{
    [Solution(GenerateProjects = true)]
    readonly Solution Solution;
}";
            var outputAssembly = Path.Combine(EnvironmentInfo.WorkingDirectory, $"Test_{nameof(TestGenerateProjectMembers)}.dll");

            // When
            var result = await WhenTheSourceCodeIsCompiled(sourceCode, outputAssembly);

            // Then
            result.Success.Should().BeTrue();
            var ctx = new AssemblyLoadContext(nameof(TestGenerateProjectMembers), isCollectible: true);
            var loadedAssembly = ctx.LoadFromAssemblyPath(outputAssembly);
            loadedAssembly.GetType("Build")
                .Should().NotBeNull()
                .And.Subject.GetMember("NukeCommon").Should().HaveCount(1);
        }

        private async Task<EmitResult> WhenTheSourceCodeIsCompiled(string sourceCode, string outputAssembly, [CallerMemberName] string compilationAssemblyName = "TestCompilation")
        {
            var host = MefHostServices.Create(MefHostServices.DefaultAssemblies);
            var projectInfo = ProjectInfo.Create(
                ProjectId.CreateNewId(),
                VersionStamp.Create(),
                compilationAssemblyName,
                compilationAssemblyName,
                LanguageNames.CSharp
                )
                .WithCompilationOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).WithNullableContextOptions(NullableContextOptions.Enable))
                .WithParseOptions(new CSharpParseOptions(LanguageVersion.Preview))
                .WithMetadataReferences(new[]
                {
                    MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                    MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "netstandard.dll")),
                    MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")),
                    MetadataReference.CreateFromFile(typeof(SolutionAttribute).Assembly.Location)
                })
                .WithAnalyzerReferences(new[]{
                    new AnalyzerFileReference(typeof(SolutionProjectsAsPropertiesGenerator).Assembly.Location, new DataBuilderGeneratorAnalyzerLoader())
                    });

            var compilation = await new AdhocWorkspace(host)
                .CurrentSolution
                .AddProject(projectInfo)
                .AddDocument(DocumentId.CreateNewId(projectInfo.Id, compilationAssemblyName + ".cs"), compilationAssemblyName + ".cs", SourceText.From(sourceCode, Encoding.UTF8))
                .GetProject(projectInfo.Id)!
                .GetCompilationAsync();

            var result = compilation!.Emit(outputAssembly);
            return result;
        }

        private class DataBuilderGeneratorAnalyzerLoader : IAnalyzerAssemblyLoader
        {
            public void AddDependencyLocation(string fullPath)
            {
            }

            public Assembly LoadFromPath(string fullPath)
            {
                return typeof(SolutionProjectsAsPropertiesGenerator).Assembly;
            }
        }
    }
}
