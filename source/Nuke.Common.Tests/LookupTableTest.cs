// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using FluentAssertions;
using JetBrains.Annotations;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core;
using Nuke.Core.Tooling;
using Xunit;

namespace Nuke.Common.Tests
{
    public abstract class SettingsTestBase<T>
        where T : ToolSettings
    {
        protected T Modify([InstantHandle] Expression<Func<T>> modification, bool forOutput = false)
        {
            var text = modification.Body.ToString();
            text = text.Substring(text.IndexOf(value: ')') + 2);
            var settings = modification.Compile().Invoke ();
            var arguments = forOutput
                ? settings.GetArguments().RenderForOutput()
                : settings.GetArguments().RenderForExecution();

            File.AppendAllLines(
                @"C:\OSS\Nuke\log.txt",
                new[] { text, arguments, string.Empty },
                Encoding.UTF8);

            return settings;
        }
        protected void Throws(Expression<Func<T>> modification)
        {
            var text = modification.Body.ToString();
            text = text.Substring(text.IndexOf(value: ')') + 2);
            var exception = Assert.Throws<Exception>(() => modification.Compile().Invoke().GetArguments());

            File.AppendAllLines(
                @"C:\OSS\Nuke\log.txt",
                new[] { text, exception.Message, Environment.NewLine },
                Encoding.UTF8);
        }
    }

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

            ControlFlow.ExecuteWithRetry(OnSecondExecution, waitInSeconds: 10);
            executions.Should().Be(2);
        }
    }

    public class MSBuildSettingsTest : SettingsTestBase<MSBuildSettings>
    {
        //[Fact]
        public void Test ()
        {
            var s = new MSBuildSettings();

            s = Modify(() => s.AddTarget("rebuild"));
            s = Modify(() => s.AddProperty("runCodeAnalysis", "true"));

            Throws(() => s.SetTargetPath("abc"));
        }
    }

    public class LookupTableTest
    {
        [Fact]
        public void Test ()
        {
            var lookupTable = new LookupTable<string, int>(StringComparer.OrdinalIgnoreCase);

            lookupTable.Should().BeEmpty();
            lookupTable["first"].Should().BeEmpty();

            lookupTable.Add("first", value: 2);
            lookupTable.Add("first", value: 3);
            lookupTable.Add("first", value: 4);
            lookupTable.Add("second", value: 5);
            lookupTable.Should().HaveCount(expected: 2);
            lookupTable["first"].Should().HaveCount(expected: 3);
            lookupTable["first"].Should().BeEquivalentTo(2, 3, 4);

            lookupTable.Remove("first", value: 3);
            lookupTable["first"].Should().HaveCount(expected: 2);
            lookupTable["first"].Should().BeEquivalentTo(2, 4);

            lookupTable.Remove("first");
            lookupTable["first"].Should().BeEmpty();
            lookupTable.Should().HaveCount(expected: 1);

            var copy = new LookupTable<string, int>(lookupTable, StringComparer.OrdinalIgnoreCase);
            lookupTable.Add("second", value: 6);
            copy["second"].Should().HaveCount(expected: 1);

            lookupTable.Clear();
            lookupTable.Should().BeEmpty();
            copy.Should().NotBeEmpty();
        }
    }
}
