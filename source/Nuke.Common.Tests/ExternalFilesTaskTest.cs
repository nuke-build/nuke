// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Threading.Tasks;
using Nuke.Common.BuildTasks;

namespace Nuke.Common.Tests
{
    public class ExternalFilesTaskTest
    {
        public async Task Test()
        {
            await ExternalFilesTask.DownloadExternalFile(
                "/Users/matt/code/nuke/repositories/nuke-build/compression/build/Build2.cs.ext",
                timeout: 1000,
                (file, message) => throw new Exception(message),
                (file, message) => throw new Exception(message));
        }
    }
}
