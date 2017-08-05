// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [Serializable]
    [PublicAPI]
    [CannotApplyEqualityOperator]
    public abstract class Enumeration
    {
        protected string Value { get; set; }

        protected bool Equals (Enumeration other)
        {
            return string.Equals(Value, other.Value);
        }

        public override bool Equals ([CanBeNull] object obj)
        {
            if (ReferenceEquals(objA: null, objB: obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((Enumeration) obj);
        }

        public override int GetHashCode ()
        {
            // ReSharper disable NonReadonlyMemberInGetHashCode
            return Value != null ? Value.GetHashCode() : 0;
            // ReSharper restore NonReadonlyMemberInGetHashCode
        }

        public override string ToString ()
        {
            return Value.NotNull("Value != null");
        }
    }
}
