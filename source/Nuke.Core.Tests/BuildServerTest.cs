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
        [BuildServerTheory(typeof(Bitrise))]
        [MemberData(nameof(Properties), typeof(Bitrise))]
        public void TestBitrise(PropertyInfo property)
        {
            AssertDoesNotThrows(Bitrise.Instance.NotNull(), property);
        }

        [BuildServerTheory(typeof(TeamCity))]
        [MemberData(nameof(Properties), typeof(TeamCity))]
        public void TestTeamCity(PropertyInfo property)
        {
            AssertDoesNotThrows(TeamCity.Instance.NotNull(), property);
        }

        [BuildServerTheory(typeof(TeamFoundationServer))]
        [MemberData(nameof(Properties), typeof(TeamFoundationServer))]
        public void TestTeamFoundationServer(PropertyInfo property)
        {
            AssertDoesNotThrows(TeamFoundationServer.Instance.NotNull(), property);
        }

        public static IEnumerable<object[]> Properties(Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(x => new object[] { x }).ToArray();
        }

        private static void AssertDoesNotThrows (object instance, PropertyInfo property)
        {
            Action act = () => property.GetValue(instance);
            act.ShouldNotThrow<Exception>();
        }

        internal class BuildServerTheoryAttribute : TheoryAttribute
        {
            private readonly Type _type;

            public BuildServerTheoryAttribute (Type type)
            {
                _type = type;
            }

            public override string Skip => HasNoInstance() ? $"Only applies to {_type.Name}." : null;

            private bool HasNoInstance()
            {
                var property = _type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).NotNull();
                return property.GetValue(obj: null) == null;
            }
        }
    }
}
