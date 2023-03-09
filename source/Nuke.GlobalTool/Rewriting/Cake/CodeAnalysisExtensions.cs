// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal static class CodeAnalysisExtensions
    {
        public static LiteralExpressionSyntax ToLiteralExpression(this string str)
        {
            return LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(str));
        }

        public static IEnumerable<ExpressionSyntax> Arguments(this InvocationExpressionSyntax node)
        {
            return node.ArgumentList.Arguments.Select(x => x.Expression);
        }

        public static InvocationExpressionSyntax WithArguments(
            this InvocationExpressionSyntax node,
            params ExpressionSyntax[] expressions)
        {
            return node.WithArgumentList(ArgumentList(SeparatedList(expressions.Select(Argument))));
        }

        public static InvocationExpressionSyntax WithArguments(this InvocationExpressionSyntax node, IEnumerable<ExpressionSyntax> expressions)
        {
            return node.WithArguments(expressions.ToArray());
        }

        public static InvocationExpressionSyntax WithConvertedArguments(
            this InvocationExpressionSyntax node,
            Func<ExpressionSyntax, ExpressionSyntax> convert)
        {
            convert ??= x => x;
            return node.WithArguments(node.ArgumentList.Arguments.Select(x => x.Expression).Select(convert));
        }

        public static InvocationExpressionSyntax WithReorderedArguments(
            this InvocationExpressionSyntax node,
            Func<ExpressionSyntax[], ExpressionSyntax[]> reorder)
        {
            reorder ??= x => x;
            return node.WithArguments(reorder(node.ArgumentList.Arguments.Select(x => x.Expression).ToArray()));
        }

        public static string GetIdentifierName(this MemberAccessExpressionSyntax memberAccessExpression)
        {
            return memberAccessExpression.Name.Identifier.Text;
        }

        public static string GetIdentifierName(this InvocationExpressionSyntax invocationExpression)
        {
            return invocationExpression.Expression switch
            {
                MemberAccessExpressionSyntax memberAccessExpression => memberAccessExpression.GetIdentifierName(),
                IdentifierNameSyntax identifierName => identifierName.Identifier.Text,
                GenericNameSyntax genericName => genericName.Identifier.Text,
                _ => null
            };
        }

        public static TypeSyntax GetSingleGenericArgumentOrNull(this InvocationExpressionSyntax invocationExpression)
        {
            return invocationExpression.Expression is GenericNameSyntax genericName ? genericName.TypeArgumentList.Arguments.Single() : null;
        }

        [CanBeNull]
        public static T GetSingleArgument<T>(this InvocationExpressionSyntax invocationExpression)
            where T : ExpressionSyntax
        {
            return invocationExpression.Arguments().Single() as T;
        }

        [CanBeNull]
        public static T GetArgumentAt<T>(this InvocationExpressionSyntax invocationExpression, int index)
            where T : ExpressionSyntax
        {
            return invocationExpression.Arguments().ElementAtOrDefault(index) as T;
        }

        public static T GetConstantValue<T>(this LiteralExpressionSyntax literalExpression)
        {
            return (T) literalExpression.Token.Value;
        }

        public static VariableDeclaratorSyntax GetSingleDeclarator(this FieldDeclarationSyntax fieldDeclaration)
        {
            return fieldDeclaration.Declaration.Variables.Single();
        }

        public static TypeSyntax GetExpressionType(this ExpressionSyntax expression)
        {
            if (expression is LiteralExpressionSyntax literalExpression)
            {
                return literalExpression.Kind() switch
                {
                    SyntaxKind.NumericLiteralExpression => ParseTypeName("int"),
                    SyntaxKind.TrueLiteralExpression => ParseTypeName("bool"),
                    SyntaxKind.FalseLiteralExpression => ParseTypeName("bool"),
                    SyntaxKind.StringLiteralExpression => ParseTypeName("string"),
                    _ => throw new NotSupportedException()
                };
            }

            if (expression is MemberAccessExpressionSyntax memberAccessExpression &&
                memberAccessExpression.Expression is IdentifierNameSyntax identifierName)
                return ParseTypeName(identifierName.Identifier.Text);

            if (expression is ObjectCreationExpressionSyntax objectCreationExpression)
                return objectCreationExpression.Type;

            if (expression is ArrayCreationExpressionSyntax arrayCreationExpression)
                return arrayCreationExpression.Type;

            return ParseTypeName("object");
        }

        public static LiteralExpressionSyntax GetNonDefaultValue(this LiteralExpressionSyntax literalExpression)
        {
            var value = literalExpression.ToString();
            return value switch
            {
                "\"\"" => null,
                "0" => null,
                "false" => null,
                _ => literalExpression
            };
        }

        public static T When<T>(this T builder, bool condition, Func<T, T> action)
        {
            return condition ? action(builder) : builder;
        }
    }
}
