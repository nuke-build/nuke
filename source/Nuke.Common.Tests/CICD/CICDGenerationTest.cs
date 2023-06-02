// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using VerifyXunit;
using Xunit;
using YamlDotNet.Serialization;

namespace Nuke.Common.Tests.CICD;

[UsesVerify]
public class CICDGenerationTest
{
    [Fact]
    public async Task Test()
    {
        var configuration = new GitHubActionsConfiguration()
            .Name("continuous");

        var (file, content) = configuration.FileContents.First();
        await Verifier.Verify($"""
            # {file}

            {content}
            """);
    }
}

public abstract class CICDConfigurationBase
{
    public INukeBuild Build { get; internal set; }
    public abstract IEnumerable<(RelativePath, string)> FileContents { get; }
}

public abstract class YamlCICDConfigurationBase : CICDConfigurationBase
{
    protected JObject JObject { get; } = new();
    protected abstract RelativePath File { get; }
    public override IEnumerable<(RelativePath, string)> FileContents
    {
        get
        {
            var expandoObjectConverter = new ExpandoObjectConverter();
            var deserializedObject = JsonConvert.DeserializeObject<ExpandoObject>(JObject.ToString(), expandoObjectConverter);
            var yaml = new Serializer().Serialize(deserializedObject);

            return new[] { (File, yaml) };
        }
    }
}


public class GitHubActionsConfiguration : YamlCICDConfigurationBase
{
    public GitHubActionsConfiguration(MemberInfo member = null)
    {
        Name(member?.Name);
    }

    public GitHubActionsConfiguration Name(string name)
    {
        JObject["name"] = name;
        return this;
    }

    protected override RelativePath File => (RelativePath)".github" / "workflows" / JObject["name"].NotNull().ToString() + ".yml";
}
