// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;

[GenerateFoo]
partial class Build
{
    [CICD] GitHubActionsWorkflow Continuous => _ => _
        .Name(nameof(Continuous)) // optional
    // .On(GitHubActionsEvent.Issues, "created", "edited") // params
    // .On(GitHubActionsEvent.Issues, GitHubActionsEvent.PullRequest) // params
    // .OnPush(_ => _
    //     .Branches("foo", "bar")
    //     .IgnoreBranches("zoo")
    //     .Paths("foo", "bar")
    //     .Tags("foo", "bar")
    //     .IgnoreTags("=> =>"))
    // .OnWorkflowDispatch(_ => _
    //     .Input(x => MastodonAccessToken))
    // .ImportSecrets(
    //     x => MastodonAccessToken,
    //     (IHazTwitterCredentials x) => x.ConsumerKey)
    // .ImportGitHubToken()
    // .Action("actions/checkout@v3", (
    //     Token: "",
    //     Base64FormattingOptions: ""))
    // .Cache((ITest x) => x.Test, GitHubActionsCaching.DotNet)
    // .Invoke(Announce, _ => _)
    // .Invoke<ITest>();
    ;
}

public class CICDAttribute : Attribute
{
}

[CICD]
public delegate GitHubActionsConfiguration GitHubActionsWorkflow(GitHubActionsConfiguration configuration);

public abstract class CICDConfiguration
{
    public INukeBuild Build { get; internal set; }
    public abstract IEnumerable<(RelativePath, string)> FileContents { get; }
}

public class GitHubActionsConfiguration : CICDConfiguration
{
    readonly JObject _object = new();

    public GitHubActionsConfiguration(MemberInfo member)
    {
        Name(member.Name);
    }

    public GitHubActionsConfiguration Name(string name)
    {
        _object["name"] = name;
        return this;
    }

    // public GitHubActionsWorkflow Checkout(Func<GitHubActionsCheckoutAction, GitHubActionsCheckoutAction> func)
    // {
    //     Checkout(_ => _
    //         .Ref("")
    //         .Token(""));
    //     return this;
    // }

    public override IEnumerable<(RelativePath, string)> FileContents
    {
        get
        {
            var file = (RelativePath) ".github" / "workflows" / _object["name"].NotNull().ToString() + ".yml";
            var content = _object.ToString();


            var expConverter = new ExpandoObjectConverter();
            dynamic deserializedObject = JsonConvert.DeserializeObject<ExpandoObject>(content, expConverter);

            var serializer = new YamlDotNet.Serialization.Serializer();
            string yaml = serializer.Serialize(deserializedObject);
            yield return (file, content);
        }
    }
}

public record GitHubActionsCheckoutAction
{
    public GitHubActionsCheckoutAction Ref(string value)
    {
        return this;
    }
    public GitHubActionsCheckoutAction Token(string value)
    {
        return this;
    }
}

public class GenerateFoo : BuildExtensionAttributeBase, IOnBuildCreated
{
    public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
    {
        var properties = Build.GetType().GetProperties(ReflectionUtility.Instance)
            .Where(x => x.HasCustomAttribute<CICDAttribute>());

        foreach (var property in properties)
        {
            var delegateType = property.GetMemberType();
            Assert.True(delegateType.IsDelegateType() && delegateType.HasCustomAttribute<CICDAttribute>());

            var invokeMethod = delegateType.GetMethod("Invoke").NotNull();
            var configurationType = invokeMethod.GetParameters().Single().ParameterType;
            var configuration = configurationType.CreateInstance<CICDConfiguration>(property);
            configuration.Build = Build;

            var contents = configuration.FileContents.ToList();
        }
    }
}
