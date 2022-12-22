// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;

namespace Nuke.Common.Tests;

public class TerraformResource : IDisposable
{
    public string WorkingDirectory { get; }

    public TerraformResource()
    {
        WorkingDirectory = SetupTerraform();
    }

    private static string SetupTerraform()
    {
        var workingDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(workingDirectory);

        File.WriteAllText(Path.Combine(workingDirectory, "main.tf"),
            @"
terraform {
}

resource ""null_resource"" ""test"" {
  provisioner ""local-exec"" {
    command = ""echo Success""
  }
}
");
        return workingDirectory;
    }

    public void Dispose()
    {
        if (string.IsNullOrEmpty(WorkingDirectory))
        {
            return;
        }

        if (Directory.Exists(WorkingDirectory))
        {
            Directory.Delete(WorkingDirectory, recursive: true);
        }
    }
}
