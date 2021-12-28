// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool;

public partial class Program
{
    [UsedImplicitly]
    public static int RegisterCompleter(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
    {
        var shellArg = args.FirstOrDefault();

        IEnumerable<string> SupportedShells()
        {
            foreach (var value in Enum.GetValues(typeof(CompletionUtility.CompletionSupportedShells)))
            {
                yield return value.ToString();
            }
        }

        var shellValid =
            CompletionUtility.CompletionSupportedShells.TryParse(shellArg, ignoreCase: true, out CompletionUtility.CompletionSupportedShells shell);

        if (!shellValid)
        {
            Assert.Fail(@$"
Usage: nuke {CommandPrefix}RegisterCompleter <shell>

    shell: {SupportedShells().JoinCommaSpace()}
");
            return -1;
        }

        Console.Write(CompletionUtility.RegisterCompleter(shell));
        return 0;
    }
}
