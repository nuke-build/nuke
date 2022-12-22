// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tests.Attributes;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Terraform;
using Xunit;
using Xunit.Abstractions;

namespace Nuke.Common.Tests;

[TestCaseOrderer("Nuke.Common.Tests.Utility.PriorityOrderer", "Nuke.Common.Tests")]
public class TerraformTest : IClassFixture<TerraformResource>
{
    private readonly ITestOutputHelper _helper;
    private readonly TerraformResource _resource;
    private string TempDirectory => _resource.WorkingDirectory;

    public TerraformTest(ITestOutputHelper helper, TerraformResource resource)
    {
        _helper = helper;
        _resource = resource;
    }

    [Fact]
    [TestPriority(1)]
    public void InitTest()
    {
        var output = TerraformTasks.TerraformInit(new TerraformInitSettings()
            .SetProcessWorkingDirectory(TempDirectory)
            .SetUpgrade(true));

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }

    [Fact]
    [TestPriority(2)]
    public void PlanTest()
    {
        var output = TerraformTasks.TerraformPlan(new TerraformPlanSettings()
            .SetProcessWorkingDirectory(TempDirectory)
            .SetPlanOutput("test.tfplan"));

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }

    [Fact]
    [TestPriority(3)]
    public void ValidateTest()
    {
        var output = TerraformTasks.TerraformValidate(new TerraformValidateSettings()
            .SetProcessWorkingDirectory(TempDirectory)
            .EnableJson());

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }

    [Fact]
    [TestPriority(4)]
    public void ApplyTest()
    {
        var output = TerraformTasks.TerraformApply(new TerraformApplySettings()
            .SetProcessWorkingDirectory(TempDirectory)
            .SetPlanFile("test.tfplan")
            .SetState("terraform.tfstate")
            .EnableJson());

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }

    [Fact]
    [TestPriority(5)]
    public void GraphTest()
    {
        var output = TerraformTasks.TerraformGraph(new TerraformGraphSettings()
            .SetProcessWorkingDirectory(TempDirectory));

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }
    
    [Fact]
    [TestPriority(6)]
    public void RefreshTest()
    {
        var output = TerraformTasks.TerraformRefresh(new TerraformRefreshSettings()
            .SetProcessWorkingDirectory(TempDirectory));

        foreach (var output1 in output)
        {
            _helper.WriteLine(output1.Text);
        }
    }
}
