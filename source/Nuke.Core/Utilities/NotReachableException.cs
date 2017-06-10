// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

#if !NETCORE
using System.Runtime.Serialization;
#endif

namespace Nuke.Core.Utilities
{
    [Serializable]
    public class NotReachableException : Exception
    {
        public NotReachableException (int exitCode)
        {
            Environment.Exit(exitCode);
        }

#if !NETCORE
        protected NotReachableException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
