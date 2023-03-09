// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Xunit;

namespace Nuke.Common.Tests
{
    public class SerializationTest
    {
        [Theory]
        [MemberData(nameof(Serializers))]
        public void Test(string name, Func<Data, Data> serializationChain)
        {
            var obj = new Data
                      {
                          String = name,
                          Number = 5,
                          Boolean = true,
                          Nested = new Data
                                   {
                                       Boolean = false
                                   }
                      };

            var obj2 = serializationChain(obj);

            obj2.String.Should().Be(obj.String);
            obj2.Number.Should().Be(obj.Number);
            obj2.Boolean.Should().Be(obj.Boolean);
            obj2.Nested.Should().NotBeNull();
            obj2.Nested.Boolean.Should().Be(obj.Nested.Boolean);
            obj2.Nested.String.Should().Be(obj.Nested.String);
        }

        public class Data
        {
            public string String { get; set; }
            public int Number { get; set; }
            public bool Boolean { get; set; }

            public Data Nested { get; set; }
        }

        public static IEnumerable<object[]> Serializers
        {
            [UsedImplicitly]
            get
            {
                static object[] GetSerialization(string name, Func<Data, Data> serialization) => new object[] { name, serialization };

                yield return GetSerialization("Json", x => SerializationTasks.JsonDeserialize<Data>(SerializationTasks.JsonSerialize(x)));
                yield return GetSerialization("Yaml", x => SerializationTasks.YamlDeserialize<Data>(SerializationTasks.YamlSerialize(x)));
                yield return GetSerialization("Xml", x => SerializationTasks.XmlDeserialize<Data>(SerializationTasks.XmlSerialize(x)));
                //yield return GetSerialization(x => XmlSerialize(x), x => XmlDeserialize<Data>(x));
            }
        }
    }
}
