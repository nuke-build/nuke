// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class ParameterRewriter : SafeSyntaxRewriter
    {
        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            if (node.Parent is not CompilationUnitSyntax)
                return node;

            var variableDeclarator = node.GetSingleDeclarator();
            var invocationExpression = variableDeclarator.Initializer?.Value as InvocationExpressionSyntax;
            if (invocationExpression?.GetIdentifierName() != "Argument")
                return node;

            var originalNode = node;
            var resolutionName = invocationExpression.GetArgumentAt<LiteralExpressionSyntax>(0).GetConstantValue<string>();
            var defaultValue = invocationExpression.GetArgumentAt<ExpressionSyntax>(1);
            var nonDefaultValue = defaultValue is LiteralExpressionSyntax literalExpression
                ? literalExpression.GetNonDefaultValue()
                : defaultValue;

            AttributeListSyntax CreateAttributeListWith(string name, string argument = null)
            {
                var attribute = Attribute(IdentifierName(name));
                if (argument != null)
                    attribute = attribute.WithArgumentList(AttributeArgumentList(
                        SeparatedList(new[] { AttributeArgument(argument.ToLiteralExpression()) })));

                return AttributeList(SeparatedList(new[] { attribute }));
            }

            node = node.WithoutTrivia();
            node = node.AddAttributeLists(
                CreateAttributeListWith(
                    "Parameter",
                    !resolutionName.Replace("_", string.Empty).Replace("-", string.Empty)
                        .EqualsOrdinalIgnoreCase(variableDeclarator.Identifier.Text)
                        ? resolutionName
                        : null));
            node = node.WithDeclaration(
                node.Declaration.WithType(
                    variableDeclarator.Identifier.Text.ContainsAnyOrdinalIgnoreCase("path", "dir", "file")
                    ? ParseTypeName(nameof(AbsolutePath))
                    : invocationExpression.GetSingleGenericArgumentOrNull() ?? defaultValue.GetExpressionType()));
            node = node.WithDeclaration(
                node.Declaration
                    .WithVariables(
                        SeparatedList(node.Declaration.Variables
                            .Select(x => x.WithInitializer(nonDefaultValue != null
                                ? EqualsValueClause(nonDefaultValue)
                                : null)))));
            node = node.WithModifiers(TokenList(Token(SyntaxKind.ReadOnlyKeyword)));

            if (variableDeclarator.Identifier.Text.ContainsAnyOrdinalIgnoreCase("password", "key", "token", "secret", "credentials"))
                node = node.AddAttributeLists(CreateAttributeListWith("Secret"));

            return node.WithTriviaFrom(originalNode);
        }
    }
}
