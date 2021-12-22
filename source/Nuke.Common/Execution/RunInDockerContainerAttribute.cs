// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RunInDockerContainerAttribute : Attribute
    {
        public string Image { get; }
        public string[] Args { get; }
        public bool PullImage { get; set; }
        public PlatformFamily Platform { get; }

        //todo: consider supporting credentials for the docker feed
        //todo: consider supporting additional env vars
        //todo: consider supporting a "dont pass any env vars" mode

        public RunInDockerContainerAttribute(string image, PlatformFamily platform = PlatformFamily.Linux, bool pullImage = true, string[] args = null)
        {
            Image = image;
            Platform = platform;
            PullImage = pullImage;
            Args = args ?? Array.Empty<string>();
        }
    }
}
