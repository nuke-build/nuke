// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.Utilities;

#if !NETCORE
using System.Runtime.Serialization;
#endif

namespace Nuke.Core.Execution
{
    [Serializable]
    public class LoaderException : Exception
    {
        public LoaderException (params string[] message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message.Join(Environment.NewLine));
            Console.ForegroundColor = color;
            Environment.Exit(-message.First().GetHashCode());
        }

#if !NETCORE
        protected LoaderException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
