// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nuke.Common;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class SafeSyntaxRewriter : CSharpSyntaxRewriter
    {
        public override SyntaxNode Visit(SyntaxNode node)
        {
            try
            {
                return base.Visit(node);
            }
            catch (Exception)
            {
                Host.Warning($"Could not handle fragment '{node.ToFullString().Trim()}', skipping ...");
                return node;
            }
        }
    }
}
