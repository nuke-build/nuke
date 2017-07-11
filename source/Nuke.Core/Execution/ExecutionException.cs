// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Utilities;

#if !NETCORE
using System.Runtime.Serialization;

#endif

namespace Nuke.Core.Execution
{
    // TODO: use logger/controlFlow instead with check for Build.Instance != null ?
    [Serializable]
    public class ExecutionException : Exception
    {
        public ExecutionException (params string[] message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message.Join(Environment.NewLine));
            Console.ForegroundColor = color;
            Environment.Exit(-message.First().GetHashCode());
        }

#if !NETCORE
        protected ExecutionException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
