// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class RegularFieldRewriter : SafeSyntaxRewriter
    {
        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            node = (FieldDeclarationSyntax) base.VisitFieldDeclaration(node).NotNull();
            var initializerValue = node.GetSingleDeclarator().Initializer?.Value;
            if (initializerValue != null)
                node = node.WithDeclaration(node.Declaration
                    .WithType(initializerValue.GetExpressionType()));

            return node;
        }
    }
}
