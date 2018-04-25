// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Xunit;

namespace Nuke.Common.Tests
{
    public class BuildServerTest
    {
        [BuildServerFact(typeof(TeamCity))]
        public void TestTeamCityRestClient()
        {
            CreateBuildServer<TeamCity>().RestClient
                .GetBuildQueue().Result
                .Builds.Length.Should().BeGreaterThan(expected: 0);
        }

        [BuildServerTheory(typeof(AppVeyor))]
        [MemberData(nameof(Properties), typeof(AppVeyor))]
        public void TestAppVeyor(PropertyInfo property, AppVeyor instance)
        {
            AssertProperty(instance, property);
        }

        [BuildServerTheory(typeof(Bitrise))]
        [MemberData(nameof(Properties), typeof(Bitrise))]
        public void TestBitrise(PropertyInfo property, Bitrise instance)
        {
            AssertProperty(instance, property);
        }

        [BuildServerTheory(typeof(TeamCity))]
        [MemberData(nameof(Properties), typeof(TeamCity))]
        public void TestTeamCity(PropertyInfo property, TeamCity instance)
        {
            AssertProperty(instance, property);
        }

        [BuildServerTheory(typeof(TeamServices))]
        [MemberData(nameof(Properties), typeof(TeamServices))]
        public void TestTeamServices(PropertyInfo property, TeamServices instance)
        {
            AssertProperty(instance, property);
        }

        [BuildServerTheory(typeof(Jenkins))]
        [MemberData(nameof(Properties), typeof(Jenkins))]
        public void TestJenkins(PropertyInfo property, Jenkins instance)
        {
            AssertProperty(instance, property);
        }

        [BuildServerTheory(typeof(Travis))]
        [MemberData(nameof(Properties), typeof(Travis))]
        public void TestTravis(PropertyInfo property, Travis instance)
        {
            AssertProperty(instance, property);
            Assert.True(instance.Ci);
            Assert.True(instance.ContinousIntegration);
        }

        [BuildServerTheory(typeof(GitLab))]
        [MemberData(nameof(Properties), typeof(GitLab))]
        public void TestGitLab(PropertyInfo property, GitLab instance)
        {
            AssertProperty(instance, property);
            Assert.True(instance.Ci);
            Assert.True(instance.GitLabCi);
            Assert.True(instance.Server);
        }

        public static IEnumerable<object[]> Properties(Type type)
        {
            var instance = CreateBuildServer(type);

            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(x => new[] { x, instance }).ToArray();
        }

        private static void AssertProperty(object instance, PropertyInfo property)
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

            if (property.GetCustomAttribute<CanBeNullAttribute>() == null)
                value.Should().NotBeNull();

            if (!(value is string strValue) || property.GetCustomAttribute<NoConvertAttribute>() != null)
                return;

            bool.TryParse(strValue, out var _).Should().BeFalse("boolean");
            long.TryParse(strValue, out var _).Should().BeFalse("long");
            decimal.TryParse(strValue, out var _).Should().BeFalse("decimal");
            DateTime.TryParse(strValue, out var _).Should().BeFalse("DateTime");
            TimeSpan.TryParse(strValue, out var _).Should().BeFalse("TimeSpan");
            Guid.TryParse(strValue, out var _).Should().BeFalse("Guid");
        }

        private static T CreateBuildServer<T>()
        {
            return (T) CreateBuildServer(typeof(T));
        }

        private static object CreateBuildServer(Type type)
        {
            var bindingFlags = BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.OptionalParamBinding;
            return Activator.CreateInstance(type, bindingFlags, binder: null, args: new object[0], culture: CultureInfo.CurrentCulture);
        }
        
        private static bool IsRunning(Type type)
        {
            var property = type.GetProperty($"IsRunning{type.Name}", BindingFlags.NonPublic | BindingFlags.Static).NotNull();
            return (bool) property.GetValue(obj: null);
        }

        private class BuildServerTheoryAttribute : TheoryAttribute
        {
            private readonly Type _type;

            public BuildServerTheoryAttribute(Type type)
            {
                _type = type;
            }

            public override string Skip => !IsRunning(_type) ? $"Only applies to {_type.Name}." : null;

        }

        private class BuildServerFactAttribute : FactAttribute
        {
            private readonly Type _type;

            public BuildServerFactAttribute(Type type)
            {
                _type = type;
            }

            public override string Skip => !IsRunning(_type) ? $"Only applies to {_type.Name}." : null;
        }
    }
}
