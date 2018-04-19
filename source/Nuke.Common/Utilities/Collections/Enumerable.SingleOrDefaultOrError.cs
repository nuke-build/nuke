using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Utilities.Collections
{

    public static partial class EnumerableExtensions
    {
        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate, string message)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("message must not be null or empty", nameof(message));

            try
            {
                return enumerable.SingleOrDefault(predicate);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }

        public static T SingleOrDefaultOrError<T>(this IEnumerable<T> enumerable, string message)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("message must not be null or empty", nameof(message));

            try
            {
                return enumerable.SingleOrDefault();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(message, ex);
            }
        }
    }
}
