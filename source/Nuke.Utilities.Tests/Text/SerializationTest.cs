// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Utilities.Text.Yaml;
using Xunit;

namespace Nuke.Common.Tests
{
    public class SerializationTest
    {
        [Fact]
        public void JsonTest()
        {
            var data = CreateData("Json");
            var content = data.ToJson();
            var copy = content.GetJson<Data>();

            copy.Should().BeEquivalentTo(data);
        }

        [Fact]
        public void YamlTest()
        {
            var data = CreateData("Yaml");
            var content = data.ToYaml();
            var copy = content.GetYaml<Data>();

            copy.Should().BeEquivalentTo(data);
        }

        [Fact]
        public void XmlTest()
        {
            var data = CreateData("Xml");
            var content = data.ToXml();
            var copy = content.GetXml<Data>();

            copy.Should().BeEquivalentTo(data);
        }

        private static Data CreateData(string name)
        {
            return new Data
                   {
                       String = name,
                       Number = 5,
                       Boolean = true,
                       Nested = new Data
                                {
                                    Boolean = false
                                }
                   };
        }

        public class Data
        {
            public string String { get; set; }
            public int Number { get; set; }
            public bool Boolean { get; set; }

            public Data Nested { get; set; }
        }
    }
}
