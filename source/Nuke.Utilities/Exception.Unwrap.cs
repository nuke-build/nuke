// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;

namespace Nuke.Common.Utilities
{
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Unwraps inner exceptions from <see cref="TypeInitializationException"/>, <see cref="TargetInvocationException"/>, and
        /// <see cref="AggregateException"/>.
        /// </summary>
        public static Exception Unwrap(this Exception exception)
        {
            return exception switch
            {
                TypeInitializationException typeInitializationException => typeInitializationException.InnerException.Unwrap(),
                TargetInvocationException targetInvocationException => targetInvocationException.InnerException.Unwrap(),
                AggregateException aggregateException => aggregateException.Flatten(),
                _ => exception
            };
        }
    }
}
