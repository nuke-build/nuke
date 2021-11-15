// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;

namespace Nuke.Common.Utilities
{
    public static class ExceptionExtensions
    {
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
