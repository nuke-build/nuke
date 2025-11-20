// Copyright 2025 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Threading;
using JetBrains.Annotations;
using Microsoft.VisualStudio.SolutionPersistence.Serializer;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel;

public static class SolutionModelExtensions
{
    public static Solution ReadSolution([NotNull] this AbsolutePath path)
    {
        return path.ReadSolution<Solution>();
    }

    public static Solution ReadSolution<T>([NotNull] this AbsolutePath path)
        where T : Solution
    {
        var serializer = SolutionSerializers.GetSerializerByMoniker(path).NotNull();
        var model = AsyncHelper.RunSync(() => serializer.OpenAsync(path, CancellationToken.None));
        return typeof(T).CreateInstance<T>(model, path);
    }
}
