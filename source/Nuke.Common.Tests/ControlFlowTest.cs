// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

// ReSharper disable ArgumentsStyleLiteral

namespace Nuke.Common.Tests
{
    public class ControlFlowTest
    {
        [Fact]
        public void Test()
        {
            var executions = 0;

            void OnSecondExecution()
            {
                executions++;
                if (executions != 2)
                    throw new Exception(executions.ToString());
            }

            ControlFlow.ExecuteWithRetry(OnSecondExecution);
            executions.Should().Be(2);
        }
    }
}
