// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Core.Tooling;
using Xunit;

namespace Nuke.Core.Tests
{
    public class ArgumentsTest
    {
        private void Assert(Func<Arguments, Arguments> transform, string expected)
        {
            Assert(x => transform(x).ToString(), expected);
        }

        private void Assert(Func<Arguments, string> transform, string expected)
        {
            transform(new Arguments()).Should().Be(expected);
        }

        [Fact]
        public void Test()
        {
            Assert(x => x.Add("-unconditional"), "-unconditional");
            Assert(x => x.Add("-do-not-add", condition: false), "");

            Assert(x => x.Add("-arg {value}", "custom-value"), "-arg custom-value");
            Assert(x => x.Add("-arg {value}", (int?)null), "");
            Assert(x => x.Add("-arg {value}", value: 1), "-arg 1");

            Assert(x => x.Add("-arg {value}", "secret", secret: true).RenderForOutput(), "-arg [hidden]");
            Assert(x => x.Add("-arg {value}", "secret", secret: true).RenderForExecution(), "-arg secret");

            Assert(x => x.Add("-arg {value}", new[] { 1, 2, 3 }, mainSeparator: ":"), "-arg 1:2:3");
            Assert(x => x.Add("-arg {value}", new[] { 1, 2, 3 }), "-arg 1 -arg 2 -arg 3");
            // TODO: trim collection values
            Assert(x => x.Add("-arg {value}", new[] { " foo ", " bar " }, mainSeparator: ":"), "-arg \"foo : bar\"");
            Assert(x => x.Add("-arg {value}",
                    new Dictionary<string, string> { { "a", "b" }, { "c", null } },
                    mainSeparator: ";",
                    keyValueSeparator: "="),
                "-arg a=b;c=");
            Assert(x => x.Add("-arg {value}",
                    new[] { 1, 2, 3, 4 }.ToLookup(y => y % 2 == 0, y => y),
                    keyValueSeparator: "="),
                "-arg False=1 -arg False=3 -arg True=2 -arg True=4");

            Assert(x => x.Add("-arg {value}", "secret", secret: true).Filter("foosecretbar"), "foo[hidden]bar");
        }
    }
}
