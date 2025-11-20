// Copyright 2025 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using JetBrains.Annotations;
using Microsoft.VisualStudio.SolutionPersistence.Model;
using Microsoft.VisualStudio.SolutionPersistence.Serializer;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel;

[PublicAPI]
public interface IProjectContainer
{
    IProjectContainer Parent { get; }
    IReadOnlyCollection<Project> Projects { get; }
    IReadOnlyCollection<SolutionFolder> SolutionFolders { get; }
}

[PublicAPI]
public static class ProjectContainerExtensions
{
    [CanBeNull]
    public static SolutionFolder GetSolutionFolder(this IProjectContainer container, string name)
    {
        return container.SolutionFolders.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
    }

    /// <summary>
    /// Gets a project by its name.
    /// </summary>
    [CanBeNull]
    public static Project GetProject(this IProjectContainer container, string name)
    {
        return container.Projects.SingleOrDefault(x => name.Equals(x.Name, StringComparison.Ordinal));
    }
}

[PublicAPI]
public class Solution(SolutionModel model, AbsolutePath path = null) : IProjectContainer, IAbsolutePathHolder
{
	private ConcurrentDictionary<object, object> wrappers { get; } = new();

    internal T GetOrCreate<T>(object model)
    {
        lock (wrappers)
        {
            return (T)wrappers.GetOrAdd(model, x => x switch
            {
                SolutionProjectModel project => new Project(project, this),
                SolutionFolderModel folder => new SolutionFolder(folder, this),
                _ => throw new ArgumentOutOfRangeException(nameof(x), x, null)
            });
        }
    }

    public SolutionModel GetModel() => model;

    [CanBeNull] public AbsolutePath Path { get; set; } = path;
    [CanBeNull] public string Name => Path?.NameWithoutExtension;
    [CanBeNull] public string FileName => Path?.Name;
    [CanBeNull] public AbsolutePath Directory => Path?.Parent;

    public IReadOnlyCollection<Project> AllProjects => model.SolutionProjects.Select(GetOrCreate<Project>).ToList();
    public IReadOnlyCollection<SolutionFolder> AllSolutionFolders => model.SolutionFolders.Select(GetOrCreate<SolutionFolder>).ToList();

    IProjectContainer IProjectContainer.Parent => null;
    public IReadOnlyCollection<Project> Projects => AllProjects.Where(x => x.Parent == this).ToList();
    public IReadOnlyCollection<SolutionFolder> SolutionFolders => AllSolutionFolders.Where(x => x.Parent == this).ToList();

    public static implicit operator string(Solution solution) => solution.Path;
    public static implicit operator AbsolutePath(Solution solution) => solution.Path;

    public IEnumerable<Project> GetAllProjects(string wildcardPattern)
    {
        wildcardPattern = $"^{wildcardPattern}$";
        var regex = new Regex(wildcardPattern
            .Replace(".", "\\.")
            .Replace("*", ".*"));
        return AllProjects.Where(x => regex.IsMatch(x.Name));
    }

    public void Save(AbsolutePath path = null)
    {
        Path = (path ?? Path).NotNull();
        var serializer = SolutionSerializers.GetSerializerByMoniker(Path).NotNull();
        AsyncHelper.RunSync(() => serializer.SaveAsync(Path, model, CancellationToken.None));
    }
}

[PublicAPI]
public class SolutionItem(SolutionItemModel model, Solution solution)
{
    public string Name => model.ActualDisplayName;

    public Solution Solution => solution;
    public IProjectContainer Parent => (IProjectContainer)model.Parent?.Apply(solution.GetOrCreate<SolutionFolder>) ?? solution;

    public override string ToString() => model.ActualDisplayName;
}

[PublicAPI]
public class SolutionFolder(SolutionFolderModel model, Solution solution) : SolutionItem(model, solution), IProjectContainer
{
    public SolutionFolderModel GetModel() => model;

    public IReadOnlyCollection<Project> Projects => Solution.AllProjects.Where(x => x.Parent == this).ToList();
    public IReadOnlyCollection<SolutionFolder> SolutionFolders => Solution.AllSolutionFolders.Where(x => x.Parent == this).ToList();
}

[PublicAPI]
public class Project(SolutionProjectModel model, Solution solution) : SolutionItem(model, solution), IAbsolutePathHolder
{
    public SolutionProjectModel GetModel() => model;

    public string RelativePath => model.FilePath;
    [CanBeNull] public AbsolutePath Path => Solution.Directory.NotNull() / model.FilePath;
    [CanBeNull] public string FileName => System.IO.Path.GetFileName(RelativePath);
    [CanBeNull] public AbsolutePath Directory => Path?.Parent;

    public static implicit operator string(Project project) => project.Path;
    public static implicit operator AbsolutePath(Project project) => project.Path;
}
