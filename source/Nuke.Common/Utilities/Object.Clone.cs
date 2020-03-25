// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T obj)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using var memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, obj);
            memoryStream.Seek(offset: 0, loc: SeekOrigin.Begin);
            return (T) serializer.ReadObject(memoryStream);
        }
    }
}
