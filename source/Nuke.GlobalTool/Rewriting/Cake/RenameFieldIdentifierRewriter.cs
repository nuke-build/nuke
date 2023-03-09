// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common.Utilities;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class RenameFieldIdentifierRewriter : SafeSyntaxRewriter
    {
        private readonly Dictionary<string, string> _renames = new();

        public override SyntaxNode VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            if (node.Parent is not CompilationUnitSyntax or ClassDeclarationSyntax)
                return node;

            string CreateRename(string name)
                => _renames[name] = name.Capitalize().ReplaceKnownWords();

            var renamedVariables = node.Declaration.Variables
                .Select(x => x.WithIdentifier(Identifier(CreateRename(x.Identifier.Text))));

            return node.WithDeclaration(
                node.Declaration.WithVariables(
                    SeparatedList(renamedVariables)));
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            return _renames.TryGetValue(node.Identifier.Text, out var rename)
                ? IdentifierName(rename)
                : node;
        }
    }
}
