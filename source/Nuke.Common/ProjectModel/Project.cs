// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Build.Evaluation;
using Nuke.Core;
using Nuke.Core.Utilities;
using MSBuildProject = Microsoft.Build.Evaluation.Project;

namespace Nuke.Common.ProjectModel
{
    [PublicAPI]
    [DebuggerDisplay("{" + nameof(Path) + "}")]
    public class Project
    {
        private readonly Lazy<MSBuildProject> _msbuildProject;
        private readonly Lazy<IReadOnlyDictionary<string, string>> _properties;
        private readonly Lazy<ILookup<string, string>> _items;

        internal Project (
            Guid id,
            string name,
            string path,
            Guid typeId,
            [CanBeNull] Project parent,
            [CanBeNull] string configuration,
            [CanBeNull] string targetFramework)
        {
            Id = id;
            Name = name;
            Path = path;
            TypeId = typeId;
            Parent = parent;

            _msbuildProject = new Lazy<MSBuildProject>(() => GetMSBuildProject(configuration, targetFramework), isThreadSafe: false);
            _properties = new Lazy<IReadOnlyDictionary<string, string>>(() =>
                _msbuildProject.Value.Properties.ToDictionary(x => x.Name, x => x.EvaluatedValue));
            _items = new Lazy<ILookup<string, string>>(() =>
                _msbuildProject.Value.Items.ToLookup(x => x.ItemType, x => x.EvaluatedInclude));
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Path { get; }
        public Guid TypeId { get; }

        [CanBeNull]
        public Project Parent { get; }

        public IReadOnlyDictionary<string, string> Properties => _properties.Value;
        public ILookup<string, string> Items => _items.Value;

        public static implicit operator string (Project project)
        {
            return project.Path;
        }

        public bool Is(ProjectType projectType)
        {
            return projectType.Guids.Any(x => x.Equals(TypeId));
        }

        public MSBuildProject GetMSBuildProject (string configuration = null, string targetFramework = null)
        {
            var projectCollection = new ProjectCollection();
            var project = new MSBuildProject(
                Path,
                GetProperties(configuration, targetFramework),
                projectCollection.DefaultToolsVersion,
                projectCollection);

            var targetFrameworks = project.AllEvaluatedItems
                    .Where(x => x.ItemType == "_TargetFrameworks")
                    .Select(x => x.EvaluatedInclude)
                    .OrderBy(x => x).ToList();

            if (targetFramework == null && targetFrameworks.Count > 1)
            {
                projectCollection.UnloadProject(project);

                targetFramework = targetFrameworks.First();
                Logger.Warn($"Project '{Path}' has multiple target frameworks ({targetFrameworks.Join(", ")}).");
                Logger.Warn($"Evaluating using '{targetFramework}'...");
                project = new MSBuildProject(
                    Path,
                    GetProperties(configuration, targetFramework),
                    projectCollection.DefaultToolsVersion,
                    projectCollection);
            }

            return project;
        }

        private static Dictionary<string, string> GetProperties ([CanBeNull] string configuration, [CanBeNull] string targetFramework)
        {
            var properties = new Dictionary<string, string>();
            if (configuration != null)
                properties.Add("Configuration", configuration);
            if (targetFramework != null)
                properties.Add("TargetFramework", targetFramework);
            return properties;
        }
    }
}
