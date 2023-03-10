// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using VerifyXunit;
using Xunit;

namespace Nuke.SourceGenerators.Tests
{
    [UsesVerify]
    public class StronglyTypedSolutionGeneratorTest
    {
        [Fact]
        public Task Test()
        {
            var inputCompilation = CreateCompilation("""
                using Nuke.Common;
                using Nuke.Common.ProjectModel;
                partial class Build : NukeBuild
                {
                    [Solution(GenerateProjects = true)]
                    readonly Solution Solution;
                }
                """);

            var generator = new StronglyTypedSolutionGenerator();
            var driver = CSharpGeneratorDriver.Create(generator);
            var result = driver.RunGenerators(inputCompilation);
            return Verifier.Verify(result);
        }

        [Fact]
        public void TestDisabled()
        {
            var inputCompilation = CreateCompilation("""
                
                using Nuke.Common;
                using Nuke.Common.ProjectModel;
                
                partial class Build : NukeBuild
                {
                    [Solution(GenerateProjects = false)]
                    readonly Solution Solution;
                }
                """);

            var generator = new StronglyTypedSolutionGenerator();
            var driver = CSharpGeneratorDriver.Create(generator);
            var result = driver.RunGenerators(inputCompilation).GetRunResult();

            if (!result.Diagnostics.IsEmpty)
                throw new Exception(string.Join(Environment.NewLine, result.Diagnostics.Select(x => x.GetMessage())));
            result.GeneratedTrees.Should().BeEmpty();
        }

        [Fact]
        public void TestUnspecified()
        {
            var inputCompilation = CreateCompilation("""
                
                using Nuke.Common;
                using Nuke.Common.ProjectModel;
                
                partial class Build : NukeBuild
                {
                    [Solution]
                    readonly Solution Solution;
                }
                """);

            var generator = new StronglyTypedSolutionGenerator();
            var driver = CSharpGeneratorDriver.Create(generator);
            var result = driver.RunGenerators(inputCompilation).GetRunResult();

            if (!result.Diagnostics.IsEmpty)
                throw new Exception(string.Join(Environment.NewLine, result.Diagnostics.Select(x => x.GetMessage())));
            result.GeneratedTrees.Should().BeEmpty();
        }

        private static Compilation CreateCompilation(string source)
        {
            return CSharpCompilation.Create("compilation",
                new[] { CSharpSyntaxTree.ParseText(source) },
                Basic.Reference.Assemblies.NetStandard20.References.All
                    .Concat(new[] { typeof(NukeBuild), typeof(SolutionAttribute) }
                        .Select(x => MetadataReference.CreateFromFile(x.Assembly.Location))),
                new CSharpCompilationOptions(OutputKind.ConsoleApplication));
        }
    }
}
