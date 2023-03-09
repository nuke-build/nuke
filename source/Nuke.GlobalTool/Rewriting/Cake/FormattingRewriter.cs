// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;
using Nuke.Common.Utilities.Collections;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class FormattingRewriter : SafeSyntaxRewriter
    {
        private static readonly SyntaxTrivia[] Indent = { Space, Space, Space, Space };

        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            node = (PropertyDeclarationSyntax) base.VisitPropertyDeclaration(node).NotNull();

            return (node.Type as SimpleNameSyntax)?.Identifier.Text == nameof(Target)
                ? node.WithLeadingTrivia(LineFeed.Concat(Indent))
                : node;
        }

        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (token.Parent is not MemberAccessExpressionSyntax memberAccessExpression)
                return token;

            var identifierName = memberAccessExpression.GetIdentifierName();
            if (identifierName == nameof(ITargetDefinition.Executes) ||
                identifierName == nameof(ITargetDefinition.DependsOn) ||
                identifierName == nameof(ITargetDefinition.DependentFor) ||
                identifierName == nameof(ITargetDefinition.OnlyWhenStatic) ||
                identifierName == nameof(ITargetDefinition.OnlyWhenDynamic) ||
                identifierName == nameof(ITargetDefinition.ProceedAfterFailure))
                return token.WithLeadingTrivia(LineFeed.Concat(Indent).Concat(Indent));

            if (identifierName.StartsWith("Set"))
                return token.WithLeadingTrivia(LineFeed.Concat(Indent).Concat(Indent).Concat(Indent));

            return token;
        }

        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            return node
                .WithAttributeLists(List(node
                    .AttributeLists.Select((x, i) => x
                        .When(i != 0,
                            _ => _
                                .WithoutTrivia())
                        .WithTrailingTrivia(Space))))
                .When(node.AttributeLists.Any(),
                    _ => _
                        .WithModifiers(TokenList(node
                            .Modifiers.Select((x, i) => x
                                .WithLeadingTrivia(i == 0 ? new SyntaxTrivia[0] : new[] { Space })))));
        }

        public override SyntaxNode VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            return node.Contents.Count() == 1
                ? node.Contents.Single() switch
                {
                    InterpolationSyntax interpolation
                        => interpolation.Expression,
                    InterpolatedStringTextSyntax interpolatedStringText
                        => interpolatedStringText.TextToken.Text.ToLiteralExpression(),
                    _ => throw new NotSupportedException()
                }
                : node;
        }

        public override SyntaxNode VisitAttributeList(AttributeListSyntax node)
        {
            return node;
            // return node.WithTrailingTrivia(Space);
        }
    }
}
