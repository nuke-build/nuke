// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Output
{
    public class BitriseOutputSink : ConsoleOutputSink
    {
        public new static IOutputSink Instance { get; } = BuildServers.Bitrise.Instance != null ? new BitriseOutputSink() : null;

        public BitriseOutputSink ()
        {
            SetFont("Nuke.Core.Output.Fonts.ansi-shadow.flf");
        }
    }
}
