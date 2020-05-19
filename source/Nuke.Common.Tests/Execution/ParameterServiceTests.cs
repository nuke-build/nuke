// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using System.Reflection;
using FluentAssertions;
using Nuke.Common.Execution;
using Nuke.Common.Tools.AzureKeyVault.Attributes;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class ParameterServiceTests
    {
        [Fact]
        public void CanGetParameterDescription_ForParameter()
        {
            var memberInfo = typeof(FunkyClass)
                .GetTypeInfo()
                .DeclaredMembers
                .Single(m => m.Name == "StringParameter");
            var description = ParameterService.GetParameterDescription(memberInfo);
            description.Should().Be("String parameter description");
        }

        [Fact]
        public void DoesNotThrowOnGetDescription_ForKeyVaultSecret()
        {
            var memberInfo = typeof(FunkyClass)
                .GetTypeInfo()
                .DeclaredMembers
                .Single(m => m.Name == "KeyVaultSecretParameter");
            var description = ParameterService.GetParameterDescription(memberInfo);
            description.Should().BeNull();
        }

        public class FunkyClass
        {
            [Parameter(description: "String parameter description")] string StringParameter;
            [KeyVaultSecret] string KeyVaultSecretParameter;
        }
    }
}
