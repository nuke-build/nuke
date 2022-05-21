// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common;

[PublicAPI]
[ExcludeFromCodeCoverage]
[Serializable]
public class ExecuteInDockerSettings : ISettingsEntity
{
    //todo: mattr: consider supporting credentials for the docker feed
    //todo: mattr: consider supporting additional env vars
    //todo: mattr: consider supporting a "dont pass any env vars" mode
    //todo: mattr: consider if there's a solid use case for "args""
    //todo: mattr: consider if we need entrypoint? 

    /// <summary>
    /// The image to launch the container from. Note this container must support executing dotnet.
    /// </summary>
    public virtual string Image { get; internal set; }
    /// <summary>
    /// Whether to execute a `docker pull` before running the container. 
    /// </summary>
    public virtual bool PullImage { get; internal set; }
    /// <summary>
    /// The docker platform to use for the image, for example, `linux/amd64`, `linux/arm64`, `windows/amd64`, etc.  
    /// </summary>
    public virtual string DockerPlatform { get; internal set; } = "linux/x64";
    /// <summary>
    /// The .NET Runtime Identifier (<see ref="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID</see>) to use to publish the Nuke project.
    /// For example, `linux-x64`, `linux-arm64`, `win-x64` etc.
    /// </summary>
    public virtual string DotNetPublishRuntime { get; internal set; } = "linux-x64";
    /// <summary>
    /// Extra arguments to pass to the `docker run` command.
    /// </summary>
    public virtual string[] Args { get; internal set; } = Array.Empty<string>();
        
    [Pure]
    public ExecuteInDockerSettings SetImage(string image) 
    {
        var settings = this.NewInstance();
        settings.Image = image;
        return settings;
    }
    
    [Pure]
    public ExecuteInDockerSettings SetPullImage(bool pullImage) 
    {
        var settings = this.NewInstance();
        settings.PullImage = pullImage;
        return settings;
    }
    
    [Pure]
    public ExecuteInDockerSettings SetDockerPlatform(string platform) 
    {
        var settings = this.NewInstance();
        settings.DockerPlatform= platform;
        return settings;
    }
    
    [Pure]
    public ExecuteInDockerSettings SetDotNetPublishRuntime(string rid) 
    {
        var settings = this.NewInstance();
        settings.DotNetPublishRuntime = rid;
        return settings;
    }
    
    [Pure]
    public ExecuteInDockerSettings SetArgs(params string[] args) 
    {
        var settings = this.NewInstance();
        settings.Args = args;
        return settings;
    }
}
