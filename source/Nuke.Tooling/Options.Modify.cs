// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;

namespace Nuke.Common.Tooling;

public static partial class OptionsExtensions
{
    public static T Modify<T>(this T options, Action<IOptions> modification = null)
        where T : IOptions
    {
        var json = JsonConvert.SerializeObject(options);
        var copy = JsonConvert.DeserializeObject<T>(json);

        // TODO OPTIONS: HACK
        if (options is ToolOptions originalOptions && copy is ToolOptions copiedOptions)
        {
            copiedOptions.ProcessLogger = originalOptions.ProcessLogger;
            copiedOptions.ProcessExitHandler = originalOptions.ProcessExitHandler;
        }

        modification?.Invoke(copy);

        return copy;
    }

    // TODO: only exists for SetProcessExitHandler
    public static T Modify2<T>(this T options, Action<T> modification = null)
        where T : class, IOptions
    {
        return options.Modify(o => modification?.Invoke(o as T));
    }
}
