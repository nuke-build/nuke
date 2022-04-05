// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Execution;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Xunit;

namespace Nuke.Common.Tests.Execution
{
    public class LogExtensionTest
    {
        //example: replace console logging template
        [LogExtension(ConsoleTemplate="My Template: {Message:l}{NewLine}")]
        private class TestBuildWithConsoleTemplate : NukeBuild
        {
            Target Foo => _ => _.Executes(() =>{ Log.Information("hello"); });
        }

        //example: modify (or replace) built-in logging configuration
        [CustomLogConfiguration]
        private class TestBuildAppendLogSink : NukeBuild
        {
            Target Foo => _ => _.Executes(() =>{ Log.Information("hello"); });
        }

        private class CustomLogConfiguration : LogExtensionAttribute
        {
            public override LoggerConfiguration Configure(LoggerConfiguration configuration, NukeBuild build)
            {
                //append custom logging sink
                return configuration.WriteTo.Sink(CustomLogSinkInstance, LogEventLevel.Debug);
            }
        }

        private static CustomLogSink CustomLogSinkInstance = new CustomLogSink();
        private class CustomLogSink : ILogEventSink, IDisposable
        {
            public readonly List<LogEvent> LogEvents = new List<LogEvent>();

            public void Emit(LogEvent logEvent)
            {
                LogEvents.Add(logEvent);
            }

            public void Dispose()
            {
                LogEvents.Clear();
            }
        }

        [Fact]
        public void CanAppendCustomLogSink()
        {
            var build = new TestBuildAppendLogSink();
            Logging.Configure(build);
            Log.Information("CanAppendCustomLogSink");

            var lastMessage = CustomLogSinkInstance.LogEvents.Last();
            lastMessage.MessageTemplate.Text.Should().Be("CanAppendCustomLogSink");

            Log.CloseAndFlush();
        }

        private class TestBuild : NukeBuild
        {
            Target Foo => _ => _.Executes(() =>{ Log.Information("hello"); });
        }

        [Fact]
        public void CheckConsoleTemplates()
        {
            Logging.GetConsoleTemplate(null).Should().Be(Host.DefaultOutputTemplate);
            Logging.GetConsoleTemplate(new TestBuild()).Should().Be( NukeBuild.Host.OutputTemplate );
            Logging.GetConsoleTemplate(new TestBuildWithConsoleTemplate()).Should().Be( "My Template: {Message:l}{NewLine}" );
        }

        [Fact]
        public void LoggingWithNullBuild()
        {
            Logging.Configure(null);
            Log.Error("LoggingWithNullBuild");
            Log.Logger.NotNull();
            Log.CloseAndFlush();
        }
    }
}
