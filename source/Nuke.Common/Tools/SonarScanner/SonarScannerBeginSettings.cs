// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Diagnostics.Contracts;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.SonarScanner;

public partial class SonarScannerBeginSettings
{
    /// <summary>
    ///   Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.
    /// </summary>
    public virtual bool? Verbose { get; internal set; }

    /// <summary>
    ///   <p><em>Enables <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
    ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
    /// </summary>
    [Pure]
    public SonarScannerBeginSettings EnableVerbose()
    {
        Verbose = true;
        return this;
    }

    /// <summary>
    ///   <p><em>Disables <see cref="SonarScannerBeginSettings.Verbose"/></em></p>
    ///   <p>Sets the logging verbosity to detailed. Add this argument before sending logs for troubleshooting.</p>
    /// </summary>
    [Pure]
    public SonarScannerBeginSettings DisableVerbose()
    {
        Verbose = false;
        return this;
    }

    public override IArguments GetProcessArguments()
    {
        AssertValid();

        var arguments = new Arguments();
        arguments = ConfigureProcessArguments(arguments);
        arguments = ProcessArgumentConfigurator(arguments);

        arguments.Add("/d:sonar.verbose={value}", Verbose.ToString().ToLower());

        return arguments;
    }
}
