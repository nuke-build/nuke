// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;

namespace Nuke.NSwag.Generator.Utilities
{
    [Serializable]
    internal class SequenceEqualityComparer : IEqualityComparer<List<string>>
    {
        public bool Equals (List<string> x, List<string> y)
        {
            if (x.Count != y.Count) return false;
            for (var i = 0; i < x.Count; i++)
            {
                if (x[i] != y[i])
                    return false;
            }

            return true;
        }

        public int GetHashCode (List<string> obj)
        {
            var result = 17;

            for (var i = 0; i < obj.Count; i++)
            {
                unchecked
                {
                    result = result * 23 + i.GetHashCode();
                }
            }

            return result;
        }
    }

    [Serializable]
    internal class EnumerationEqualityComparer : IEqualityComparer<Enumeration>
    {
        public bool Equals (Enumeration x, Enumeration y)
        {
            return x.Name == y.Name && new SequenceEqualityComparer().Equals(x.Values, y.Values);
        }

        public int GetHashCode (Enumeration obj)
        {
            var result = 17;

            unchecked
            {
                result = result * 23 + obj.Name.GetHashCode();
                result = result * 23 + new SequenceEqualityComparer().GetHashCode(obj.Values);
            }

            return result;
        }
    }
}