// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nuke.Common.Utilities
{
    public static partial class ReflectionUtility
    {
        public static IEnumerable<object> GetArguments(this MethodCallExpression methodCall)
        {
            return methodCall.Arguments.Cast<ConstantExpression>().Select(x => x.Value);
        }

        public static MemberInfo GetMemberInfo<T>(Expression<Func<T>> expression)
        {
            return expression.GetMemberInfo();
        }

        public static MemberInfo GetMemberInfo(this LambdaExpression expression)
        {
            if (expression.Body is MethodCallExpression methodCallExpression)
                return methodCallExpression.Method;

            var memberExpression = !(expression.Body is UnaryExpression unaryExpression)
                ? (MemberExpression) expression.Body
                : (MemberExpression) unaryExpression.Operand;
            return memberExpression.Member;
        }
    }
}
