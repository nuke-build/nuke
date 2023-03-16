//HintName: StronglyTypedSolutionGenerator.cs
using Nuke.Common.ProjectModel;

internal class Solution : Nuke.Common.ProjectModel.Solution
{
    private Nuke.Common.ProjectModel.Solution SolutionFolder => this;
    public Project _build => SolutionFolder.GetProject("_build");
    public Project Nuke_Common => SolutionFolder.GetProject("Nuke.Common");
    public Project Nuke_Common_Tests => SolutionFolder.GetProject("Nuke.Common.Tests");
    public Project Nuke_Tooling_Generator => SolutionFolder.GetProject("Nuke.Tooling.Generator");
    public Project Nuke_GlobalTool => SolutionFolder.GetProject("Nuke.GlobalTool");
    public Project Nuke_GlobalTool_Tests => SolutionFolder.GetProject("Nuke.GlobalTool.Tests");
    public Project Nuke_MSBuildTasks => SolutionFolder.GetProject("Nuke.MSBuildTasks");
    public Project Nuke_Components => SolutionFolder.GetProject("Nuke.Components");
    public Project Nuke_SourceGenerators => SolutionFolder.GetProject("Nuke.SourceGenerators");
    public Project Nuke_SourceGenerators_Tests => SolutionFolder.GetProject("Nuke.SourceGenerators.Tests");
    public Project Spectre_Console => SolutionFolder.GetProject("Spectre.Console");
    public Project Nuke_Utilities => SolutionFolder.GetProject("Nuke.Utilities");
    public Project Nuke_Utilities_Tests => SolutionFolder.GetProject("Nuke.Utilities.Tests");
    public Project Nuke_Utilities_IO_Globbing => SolutionFolder.GetProject("Nuke.Utilities.IO.Globbing");
    public Project Nuke_Utilities_Text_Json => SolutionFolder.GetProject("Nuke.Utilities.Text.Json");
    public Project Nuke_Utilities_Net => SolutionFolder.GetProject("Nuke.Utilities.Net");
    public Project Nuke_Tooling => SolutionFolder.GetProject("Nuke.Tooling");
    public Project Nuke_Tooling_Tests => SolutionFolder.GetProject("Nuke.Tooling.Tests");
    public Project Nuke_SolutionModel => SolutionFolder.GetProject("Nuke.SolutionModel");
    public Project Nuke_SolutionModel_Tests => SolutionFolder.GetProject("Nuke.SolutionModel.Tests");
    public Project Nuke_ProjectModel => SolutionFolder.GetProject("Nuke.ProjectModel");
    public Project Nuke_ProjectModel_Tests => SolutionFolder.GetProject("Nuke.ProjectModel.Tests");
    public Project Nuke_Build_Shared => SolutionFolder.GetProject("Nuke.Build.Shared");
    public Project Nuke_Build => SolutionFolder.GetProject("Nuke.Build");
    public Project Nuke_Build_Tests => SolutionFolder.GetProject("Nuke.Build.Tests");
    public Project Nuke_Utilities_Text_Yaml => SolutionFolder.GetProject("Nuke.Utilities.Text.Yaml");
    public Project Nuke_Utilities_IO_Compression => SolutionFolder.GetProject("Nuke.Utilities.IO.Compression");
    public _misc misc => new(SolutionFolder.GetSolutionFolder("misc"));
    internal class _misc
    {
        private SolutionFolder SolutionFolder { get; }

        public _misc(SolutionFolder solutionFolder) => SolutionFolder = solutionFolder;
    }
}