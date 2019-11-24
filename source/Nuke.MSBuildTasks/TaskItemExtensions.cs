// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.Build.Framework;

namespace Nuke.MSBuildTasks
{
    public static class TaskItemExtensions
    {
        public static string GetMetadataOrNull(this ITaskItem taskItem, string metdataName)
        {
            return taskItem.MetadataNames.Cast<string>().Contains(metdataName)
                ? taskItem.GetMetadata(metdataName)
                : null;
        }
    }
}
