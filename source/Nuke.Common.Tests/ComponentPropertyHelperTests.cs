// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Reflection;
using Nuke.Common.ValueInjection;
using FluentAssertions;
using Nuke.Common.Tests.Execution;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class ComponentPropertyHelperTests
    {
        [Fact]
        public void FieldDefaultsTests()
        {
            IMyComponent build = new TestBuild();
            build.FieldStruct.Should().Be(0);
            build.FieldObject.Should().BeNull();
            build.FieldWithDefault.Should().Be("default");
            build.InjectedField.Should().Be("injected");
        }
        
        [Fact]
        public void FieldSetTests()
        {
            IMyComponent build = new TestBuild();
            build.FieldStruct = 1;
            build.FieldObject = "pass";
            build.FieldWithDefault = "foo";
            
            build.FieldStruct.Should().Be(1);
            build.FieldObject.Should().Be("pass");
            build.FieldWithDefault.Should().Be("foo");
        }
        
        [Fact]
        public void FieldInjectorCache()
        {
            IMyComponent build = new TestBuild();
            build.InjectedField.Should().Be("injected");
            var value = build.InjectedField; // cause a second getter call
            build.InjectorCallCount.Should().Be(1);
        }
        
       
        private class TestBuild : NukeBuild, IMyComponent
        {
            public int InjectorCallCount { get; set; }
        }

        private interface IMyComponent : INukeBuild 
        {
            int FieldStruct { get => this.Get(); set => this.Set(value); }
            string FieldObject { get => this.Get(); set => this.Set(value); }
            string FieldWithDefault { get => this.Get("default"); set => this.Set(value); }
            [TestValue(Value = "injected")] public string InjectedField { get => this.Get(); }
            public int InjectorCallCount { get; set; }
        }

        public class TestValueAttribute : ValueInjectionAttributeBase
        {
            public string Value { get; set; }
            
            public override object GetValue(MemberInfo member, object instance)
            {
                var callCountProperty = member.DeclaringType!.GetProperty(nameof(IMyComponent.InjectorCallCount));
                var currentCount = (int)callCountProperty!.GetValue(instance)!;
                currentCount++;
                callCountProperty.SetValue(instance, currentCount);
                return Value;
            }
        }
    }
}
