// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class RemoveUsingDirectivesRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode VisitUsingDirective(UsingDirectiveSyntax node)
        {
            return null;
        }
    }
}
