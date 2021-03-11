// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nuke.Common.ProjectModel;
using VerifyXunit;
using Xunit;

namespace Nuke.SourceGenerators.Tests
{
    [UsesVerify]
    public class SolutionProjectsAsPropertiesGeneratorTest
    {
        [Fact]
        public Task TestGenerateProjectMembers()
        {
            var inputCompilation = CreateCompilation(@"
using Nuke.Common;
using Nuke.Common.ProjectModel;

partial class Build : NukeBuild
{
    [Solution(GenerateProjects = true)]
    readonly Solution Solution;
}");

            var generator = new SolutionProjectsAsPropertiesGenerator();
            var driver = (GeneratorDriver) CSharpGeneratorDriver.Create(generator);
            var result = driver.RunGeneratorsAndUpdateCompilation(inputCompilation, out _, out _).GetRunResult();

            if (!result.Diagnostics.IsEmpty)
                throw new Exception(string.Join(Environment.NewLine, result.Diagnostics.Select(x => x.GetMessage())));
            return Verifier.Verify(result.GeneratedTrees.Single().GetRoot().ToFullString());
        }

        private static Compilation CreateCompilation(string source)
        {
            return CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                new[]
                {
                    MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
                    MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "netstandard.dll")),
                    MetadataReference.CreateFromFile(Path.Combine(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System.Runtime.dll")),
                    MetadataReference.CreateFromFile(typeof(SolutionAttribute).Assembly.Location)
                },
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
        }
    }
}
