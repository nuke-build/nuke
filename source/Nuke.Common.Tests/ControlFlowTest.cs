// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Core;
using Xunit;

// ReSharper disable ArgumentsStyleLiteral

namespace Nuke.Common.Tests
{
    public class ControlFlowTest
    {
        [Fact]
        public void Test ()
        {
            var executions = 0;

            void OnSecondExecution ()
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
