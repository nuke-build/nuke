// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Nuke.Core.BuildServers;
using Xunit;

namespace Nuke.Core.Tests
{
    public class BuildServerTest
    {
        [BuildServerFact(typeof(TeamCity))]
        public void TestTeamCityRestClient ()
        {
            TeamCity.Instance.RestClient
                    .GetBuildQueue().Result
                    .Builds.Length.Should().BeGreaterThan(expected: 0);
        }

        [BuildServerTheory(typeof(Bitrise))]
        [MemberData(nameof(Properties), typeof(Bitrise))]
        public void TestBitrise (PropertyInfo property)
        {
            AssertProperty(Bitrise.Instance.NotNull(), property);
            Assert.True(NukeBuild.IsServerBuild);
            Assert.False(NukeBuild.IsLocalBuild);
        }

        [BuildServerTheory(typeof(TeamCity))]
        [MemberData(nameof(Properties), typeof(TeamCity))]
        public void TestTeamCity (PropertyInfo property)
        {
            AssertProperty(TeamCity.Instance.NotNull(), property);
            Assert.True(NukeBuild.IsServerBuild);
            Assert.False(NukeBuild.IsLocalBuild);
        }

        [BuildServerTheory(typeof(TeamServices))]
        [MemberData(nameof(Properties), typeof(TeamServices))]
        public void TestTeamServices (PropertyInfo property)
        {
            AssertProperty(TeamServices.Instance.NotNull(), property);
            Assert.True(NukeBuild.IsServerBuild);
            Assert.False(NukeBuild.IsLocalBuild);
        }

        [BuildServerTheory(typeof(Jenkins))]
        [MemberData(nameof(Properties), typeof(Jenkins))]
        public void TestJenkins (PropertyInfo property)
        {
            AssertProperty(Jenkins.Instance.NotNull(), property);
        }

        public static IEnumerable<object[]> Properties (Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(x => new object[] { x }).ToArray();
        }

        private static void AssertProperty (object instance, PropertyInfo property)
        {
            object value;
            try
            {
                value = property.GetValue(instance);
            }
            catch (TargetInvocationException exception)
            {
                throw exception.InnerException.NotNull();
            }

            if (!(value is string strValue) || property.GetCustomAttribute<NoConvertAttribute>() != null)
                return;

            bool.TryParse(strValue, out var _).Should().BeFalse("boolean");
            long.TryParse(strValue, out var _).Should().BeFalse("long");
            decimal.TryParse(strValue, out var _).Should().BeFalse("decimal");
            DateTime.TryParse(strValue, out var _).Should().BeFalse("DateTime");
            TimeSpan.TryParse(strValue, out var _).Should().BeFalse("TimeSpan");
            Guid.TryParse(strValue, out var _).Should().BeFalse("Guid");
        }

        private class BuildServerTheoryAttribute : TheoryAttribute
        {
            private readonly Type _type;

            public BuildServerTheoryAttribute (Type type)
            {
                _type = type;
            }

            public override string Skip => HasNoInstance() ? $"Only applies to {_type.Name}." : null;

            private bool HasNoInstance ()
            {
                var property = _type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).NotNull();
                return property.GetValue(obj: null) == null;
            }
        }

        private class BuildServerFactAttribute : FactAttribute
        {
            private readonly Type _type;

            public BuildServerFactAttribute (Type type)
            {
                _type = type;
            }

            public override string Skip => HasNoInstance() ? $"Only applies to {_type.Name}." : null;

            private bool HasNoInstance ()
            {
                var property = _type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).NotNull();
                return property.GetValue(obj: null) == null;
            }
        }
    }
}
