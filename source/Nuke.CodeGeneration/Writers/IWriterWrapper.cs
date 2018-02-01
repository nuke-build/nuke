// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.CodeGeneration.Writers
{
    public interface IWriterWrapper
    {
        IWriter Writer { get; }
    }
}
