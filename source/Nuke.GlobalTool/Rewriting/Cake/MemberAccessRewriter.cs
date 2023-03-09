// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class MemberAccessRewriter : SafeSyntaxRewriter
    {
        private Dictionary<string, string> Replacements =>
            new()
            {
                ["BuildSystem"] = null,
            };

        public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            node = (MemberAccessExpressionSyntax) base.VisitMemberAccessExpression(node).NotNull();
            return node.Expression is not IdentifierNameSyntax identifierNameSyntax ||
                   !Replacements.TryGetValue(identifierNameSyntax.Identifier.Text, out var newName)
                ? node
                : newName != null
                    ? node.WithExpression(identifierNameSyntax.WithIdentifier(Identifier(newName)))
                    : node.Name;
        }
    }
}
