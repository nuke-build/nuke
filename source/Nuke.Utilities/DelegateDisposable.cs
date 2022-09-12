// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public class DelegateDisposable : IDisposable
    {
        public static IDisposable CreateBracket([InstantHandle] Action setup = null, [InstantHandle] Action cleanup = null)
        {
            setup?.Invoke();
            return new DelegateDisposable(cleanup);
        }

        public static IDisposable SetAndRestore<T>(Expression<Func<T>> memberProvider, T value)
        {
            var member = memberProvider.GetMemberInfo();
            var target = memberProvider.GetTarget();
            var previousValue = member.GetValue<T>(target);
            member.SetValue(target, value);
            return new DelegateDisposable(() => member.SetValue(target, previousValue));
        }

        [CanBeNull] private readonly Action _cleanup;

        private DelegateDisposable([CanBeNull] Action cleanup)
        {
            _cleanup = cleanup;
        }

        public void Dispose()
        {
            _cleanup?.Invoke();
        }
    }
}
