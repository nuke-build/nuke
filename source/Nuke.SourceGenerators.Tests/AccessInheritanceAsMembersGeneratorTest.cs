// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using VerifyXunit;
using Xunit;

namespace Nuke.SourceGenerators.Tests;

[UsesVerify]
public class AccessInheritanceAsMembersGeneratorTest
{
    [Fact]
    public Task Test()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 partial class Build : NukeBuild, IDisposable, IBuildServer
                                                 {
                                                     [Solution(GenerateProjects = true)]
                                                     readonly Solution Solution;
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation);
        return Verifier.Verify(result);
    }
    
    [Fact]
    public Task TestPublic()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 public partial class Build : NukeBuild, IDisposable, IBuildServer
                                                 {
                                                     [Solution(GenerateProjects = true)]
                                                     readonly Solution Solution;
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation);
        return Verifier.Verify(result);
    }
    
    [Fact]
    public void TestNonPartial()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 class Build : NukeBuild, IDisposable, IBuildServer
                                                 {
                                                     [Solution(GenerateProjects = true)]
                                                     readonly Solution Solution;
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation).GetRunResult();
        result.GeneratedTrees.Should().BeEmpty();
    }
    
    [Fact]
    public void TestAbstract()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 abstract partial class Build : NukeBuild, IDisposable, IBuildServer
                                                 {
                                                     [Solution(GenerateProjects = true)]
                                                     readonly Solution Solution;
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation).GetRunResult();
        result.GeneratedTrees.Should().BeEmpty();
    }
    
    [Fact]
    public void TestNotTypeClass()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 interface IBuild : INukeBuild, IBuildServer
                                                 {
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation).GetRunResult();
        result.GeneratedTrees.Should().BeEmpty();
    }
    
    [Fact]
    public void TestNotImplementingInterface()
    {
        var inputCompilation = CreateCompilation("""
                                                 using Nuke.Common;
                                                 using Nuke.Common.ProjectModel;
                                                 using Nuke.Common.CI;
                                                 partial class Build : IDisposable, IBuildServer
                                                 {
                                                     [Solution(GenerateProjects = true)]
                                                     readonly Solution Solution;
                                                 }
                                                 """);

        var generator = new AccessInheritanceAsMembersGenerator();
        var driver = CSharpGeneratorDriver.Create(generator);
        var result = driver.RunGenerators(inputCompilation).GetRunResult();
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
