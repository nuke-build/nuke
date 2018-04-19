// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Core.Utilities.Collections;
using Xunit;

namespace Nuke.Core.Tests
{
    public class DictionaryExtensionsTest
    {
        [Fact]
        public static void ToGeneric()
        {
            var sourceDictionary = new Dictionary<string, string> { { "key", "value" }, { "key2", "value2" } };
            IDictionary dict = sourceDictionary;
            dict.ToGeneric<string, string>().Should().Equal(sourceDictionary);
        }
    }
}
