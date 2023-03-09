// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class AbsolutePathRewriter : SafeSyntaxRewriter
    {
        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            var reducedFieldDeclaration = (FieldDeclarationSyntax) base.VisitFieldDeclaration(node).NotNull();
            if (reducedFieldDeclaration == node)
                return node;

            var variableDeclarator = reducedFieldDeclaration.GetSingleDeclarator();
            return SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(nameof(AbsolutePath)), variableDeclarator.Identifier)
                .WithExpressionBody(SyntaxFactory.ArrowExpressionClause(variableDeclarator.Initializer?.Value))
                .WithSemicolonToken(node.SemicolonToken)
                .WithTriviaFrom(node);
        }

        public override SyntaxNode VisitInterpolatedStringExpression(InterpolatedStringExpressionSyntax node)
        {
            var textTokens = node.Contents.OfType<InterpolatedStringTextSyntax>().Select(x => x.TextToken.Text).ToList();
            if (textTokens.All(x => !x.Contains("/")) ||
                textTokens.Any(x => x.ContainsAnyOrdinalIgnoreCase("<", ">", ":", " -")))
                return node;

            if (node.Parent is BinaryExpressionSyntax)
                return node;

            if (node.Parent?.Parent?.Parent is InvocationExpressionSyntax invocationExpression &&
                invocationExpression.GetIdentifierName().EqualsAnyOrdinalIgnoreCase("SelectNodes", "SelectSingleNode", "Append"))
                return node;

            var str = node.ToString();
            var index = str.IndexOf('*');
            if (index == -1)
                return CreateAbsolutePathExpression(new[] { SyntaxFactory.ParseExpression(str.Replace("/", "\" / $\"")) });

            var lastPathSeparatorIndex = str.Substring(0, index).LastIndexOf('/');
            if (lastPathSeparatorIndex < 0)
                return node;

            var absolutePart = str.Substring(0, lastPathSeparatorIndex) + "\"";
            var wildcardPart = "\"" + str.Substring(lastPathSeparatorIndex + 1);

            return SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        node.Contents.First() is InterpolationSyntax
                            ? SyntaxFactory.ParseExpression(absolutePart)
                            : SyntaxFactory.ParenthesizedExpression(CreateAbsolutePathExpression(new[] { SyntaxFactory.ParseExpression(absolutePart) })),
                        SyntaxFactory.IdentifierName(GetGlobbingMethod(node, wildcardPart.Split("/")))))
                .WithArguments(wildcardPart.TrimMatchingDoubleQuotes().ToLiteralExpression());

            // var parts = node.Token.ValueText.Split('/', RemoveEmptyEntries).Where(x => x != ".").ToList();
            // var nonWildcardParts = parts.TakeWhile(x => !x.Contains('*')).ToList();
            // var wildcardParts = parts.Skip(nonWildcardParts.Count).ToList();
            //
            // var literalExpressions =
            //     nonWildcardParts.Select(x => LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(x)));
            // var absolutePathExpression = CreateAbsolutePathExpression(literalExpressions);
            // if (wildcardParts.Count == 0)
            //     return absolutePathExpression;
            //

            //
            // return InvocationExpression(
            //         MemberAccessExpression(
            //             SyntaxKind.SimpleMemberAccessExpression,
            //             ParenthesizedExpression(absolutePathExpression),
            //             IdentifierName(GetGlobbingMethod())))
            //     .WithArguments(wildcardParts.Join("/").ToLiteralExpression());
        }

        // "foo/bar"        => RootDirectory / "foo" / "bar"
        // "foo/**/bar"     => (RootDirectory / "foo").GlobDirectories("**/bar")
        // "foo/**/bar.*"   => (RootDirectory / "foo").GlobFiles("**/bar.*")
        public override SyntaxNode VisitLiteralExpression(LiteralExpressionSyntax node)
        {
            if (node.Token.Value is not string ||
                !node.Token.ValueText.Contains('/') ||
                node.Token.ValueText.ContainsAnyOrdinalIgnoreCase("<", ">", ":", " -"))
                return node;

            if (node.Parent is BinaryExpressionSyntax)
                return node;

            if (node.Parent?.Parent?.Parent is InvocationExpressionSyntax invocationExpression &&
                invocationExpression.GetIdentifierName().EqualsAnyOrdinalIgnoreCase("SelectNodes", "SelectSingleNode", "Append"))
                return node;

            var parts = node.Token.ValueText.Split('/', StringSplitOptions.RemoveEmptyEntries).Where(x => x != ".").ToList();
            var nonWildcardParts = parts.TakeWhile(x => !x.Contains('*')).ToList();
            var wildcardParts = parts.Skip(nonWildcardParts.Count).ToList();

            var literalExpressions =
                nonWildcardParts.Select(x => SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(x)));
            var absolutePathExpression = CreateAbsolutePathExpression(literalExpressions);
            if (wildcardParts.Count == 0)
                return absolutePathExpression;

            return SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.ParenthesizedExpression(absolutePathExpression),
                        SyntaxFactory.IdentifierName(GetGlobbingMethod(node))))
                .WithArguments(wildcardParts.JoinSlash().ToLiteralExpression());
        }

        private string GetGlobbingMethod(SyntaxNode node, IEnumerable<string> wildcardparts = null)
        {
            return (wildcardparts?.LastOrDefault()?.Contains(".") ?? false) ||
                   node.Parent?.Parent?.Parent is InvocationExpressionSyntax invocationExpression &&
                   (invocationExpression.GetIdentifierName() == "GetFiles" ||
                    invocationExpression.GetIdentifierName() == "CopyFiles")
                ? "GlobFiles"
                : "GlobDirectories";
        }

        // MakeAbsolute(expr)   => expr
        // File(expr)           => expr
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            node = (InvocationExpressionSyntax) base.VisitInvocationExpression(node).NotNull();

            if (node.GetIdentifierName() == "MakeAbsolute" ||
                node.GetIdentifierName() == "Directory" ||
                node.GetIdentifierName() == "File")
                return node.GetSingleArgument<ExpressionSyntax>();

            if (node.GetIdentifierName() == "Combine")
                return CreateAbsolutePathExpression(node.Arguments());

            if (node.GetIdentifierName() == "GetFiles")
            {
                var expr = node.Arguments().Skip(1)
                    .Aggregate(
                        node.Arguments().FirstOrDefault()?.ToFullString(),
                        (f, s) => f + ".Concat(" + s.ToFullString() + ")");
                return SyntaxFactory.ParseExpression(expr);
                // return InvocationExpression(
                //     MemberAccessExpression(
                //         SyntaxKind.SimpleMemberAccessExpression,
                //         ParenthesizedExpression(
                //             CastExpression(
                //                 ParseTypeName("AbsolutePath"),
                //                 ParenthesizedExpression(expressionSyntax))),
                //         IdentifierName("GlobFiles")));
            }

            if (node.GetIdentifierName() == "CleanDirectories")
            {
                var expressionSyntax = node.GetSingleArgument<ExpressionSyntax>();
                return SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            expressionSyntax,
                            SyntaxFactory.IdentifierName("ForEach")))
                    .WithArguments(SyntaxFactory.IdentifierName("EnsureCleanDirectory"));
            }

            return node;
        }

        private ExpressionSyntax CreateAbsolutePathExpression(IEnumerable<ExpressionSyntax> parts)
        {
            return parts.Aggregate(
                (ExpressionSyntax) SyntaxFactory.IdentifierName("RootDirectory"),
                (left, right) => SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, left, right));
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            return node.Identifier.Text switch
            {
                "FilePath" => node.WithIdentifier(SyntaxFactory.Identifier("AbsolutePath")),
                "DirectoryPath" => node.WithIdentifier(SyntaxFactory.Identifier("AbsolutePath")),
                _ => node
            };
        }

        public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            node = (MemberAccessExpressionSyntax) base.VisitMemberAccessExpression(node).NotNull();
            if (node.GetIdentifierName() != "FullPath")
                return node;

            return node.Expression;
        }
    }
}
