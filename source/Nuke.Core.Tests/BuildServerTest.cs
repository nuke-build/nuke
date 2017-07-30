// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            AssertProperty(Bitrise.Instance.NotNull(), property);
        }

        [BuildServerTheory(typeof(TeamCity))]
        [MemberData(nameof(Properties), typeof(TeamCity))]
        public void TestTeamCity(PropertyInfo property)
        {
            AssertProperty(TeamCity.Instance.NotNull(), property);
        }

        [BuildServerTheory(typeof(TeamServices))]
        [MemberData(nameof(Properties), typeof(TeamServices))]
        public void TestTeamFoundationServer(PropertyInfo property)
        {
            AssertProperty(TeamServices.Instance.NotNull(), property);
        }

        public static IEnumerable<object[]> Properties(Type type)
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
            catch (Exception exception)
            {
                throw exception.InnerException;
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

        internal class BuildServerTheoryAttribute : TheoryAttribute
        {
            private readonly Type _type;

            public BuildServerTheoryAttribute (Type type)
            {
                _type = type;
            }

            public override string Skip => HasNoInstance () ? $"Only applies to {_type.Name}." : null;

            private bool HasNoInstance()
            {
                var property = _type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static).NotNull();
                return property.GetValue(obj: null) == null;
            }
        }
    }
}
