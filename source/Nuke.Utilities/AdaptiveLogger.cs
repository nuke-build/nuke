// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;
using MethodDecorator.Fody.Interfaces;
using Nuke.Common;
using Serilog.Events;

namespace Nuke.Utilities
{
    public class AdaptiveLogger
    {
        [ThreadStatic]
        internal static LogEventLevel Level;

        public static void Log(string messageTemplate, params object[] propertyValues)
        {
            Assert.True(Level is LogEventLevel.Information or LogEventLevel.Verbose);
            Serilog.Log.Write(Level, messageTemplate, propertyValues);
        }
    }

    public class AdaptiveLoggingAttribute : Attribute, IMethodDecorator
    {
        private static int Nesting;
        private static LogEventLevel? PreviousLevel;

        public void Init(object instance, MethodBase method, object[] args)
        {
        }

        public void OnEntry()
        {
            Nesting++;
            if (Nesting == 2)
            {
                PreviousLevel ??= AdaptiveLogger.Level;
                AdaptiveLogger.Level = LogEventLevel.Verbose;
            }
        }

        public void OnExit()
        {
            Nesting--;
            if (Nesting == 1)
            {
                AdaptiveLogger.Level = PreviousLevel ?? AdaptiveLogger.Level;
                PreviousLevel = null;
            }
        }

        public void OnException(Exception exception)
        {
            OnExit();
        }
    }
}
