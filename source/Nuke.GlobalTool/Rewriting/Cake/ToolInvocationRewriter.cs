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
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.SignTool;
using Nuke.Common.Utilities.Collections;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class ToolInvocationRewriter : SafeSyntaxRewriter
    {
        private static IEnumerable<ReplacementData> Replacements =>
            new ReplacementData[]
            {
                new(original: "DotNetCoreRestore", replacement: nameof(DotNetTasks.DotNetRestore), positionals: new[] { "ProjectFile" }),
                new(original: "DotNetCoreBuild", replacement: nameof(DotNetTasks.DotNetBuild), positionals: new[] { "ProjectFile" }),
                new(original: "DotNetCoreTest", replacement: nameof(DotNetTasks.DotNetTest), positionals: new[] { "ProjectFile" }),
                new(original: "DotNetCorePack", replacement: nameof(DotNetTasks.DotNetPack), positionals: new[] { "ProjectFile" }),
                new(original: "DotNetCorePublish", replacement: nameof(DotNetTasks.DotNetPublish), positionals: new[] { "Project" }),
                new(original: "Sign", replacement: nameof(SignToolTasks.SignTool), positionals: new[] { "Files" }),
                new(original: "NuGetRestore", replacement: nameof(NuGetTasks.NuGetRestore), positionals: new[] { "TargetPath" }),
                new(original: "NuGetPack", replacement: nameof(NuGetTasks.NuGetPack), positionals: new[] { "TargetPath" }),
                new(original: "MSBuild", replacement: nameof(MSBuildTasks.MSBuild), positionals: new[] { "TargetPath" }),
            };

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            node = (InvocationExpressionSyntax) base.VisitInvocationExpression(node).NotNull();
            var identifierName = node.GetIdentifierName();
            var replacement = Replacements.SingleOrDefault(x => x.Original == identifierName);
            if (replacement == null)
                return node;

            var arguments = new List<(string Name, ExpressionSyntax Value)>();
            var settings = node.GetArgumentAt<ObjectCreationExpressionSyntax>(replacement.Positionals.Length);

            node.Arguments().Take(replacement.Positionals.Length)
                .ForEach((x, i) => arguments.Add((replacement.Positionals[i], x)));
            settings?.Initializer?.Expressions.Cast<AssignmentExpressionSyntax>()
                .ForEach(x => arguments.Add((((IdentifierNameSyntax) x.Left).Identifier.Text, x.Right)));

            ExpressionSyntax expr = IdentifierName("_");
            foreach (var (name, value) in arguments)
            {
                expr = InvocationExpression(
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                            expr,
                            IdentifierName("Set" + replacement.Renames.GetValueOrDefault(name, name))))
                    .WithArguments(value);
            }

            return InvocationExpression(IdentifierName(replacement.Replacement))
                .WithArguments(
                    SimpleLambdaExpression(Parameter(Identifier("_")))
                        .WithBody(expr))
                .WithTriviaFrom(node);
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            return node.Identifier.Text == "Append"
                ? node.WithIdentifier(Identifier("Add"))
                : node;
        }

        private class ReplacementData
        {
            public ReplacementData(
                string original,
                string replacement,
                string[] positionals = null,
                Dictionary<string, string> renames = null)
            {
                Original = original;
                Replacement = replacement;
                Positionals = positionals ?? new string[0];
                Renames = renames ?? new Dictionary<string, string>();

                Renames.Add("ArgumentCustomization", "ProcessArgumentConfigurator");
                Renames.Add("ToolPath", "ProcessToolPath");
            }

            public string Original { get; }
            public string Replacement { get; }
            public string[] Positionals { get; }
            public Dictionary<string, string> Renames { get; }
        }
    }
}
