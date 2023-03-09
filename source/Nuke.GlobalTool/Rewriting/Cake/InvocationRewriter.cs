// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;
using Nuke.Common.IO;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class InvocationRewriter : SafeSyntaxRewriter
    {
        private static IEnumerable<ReplacementData> Replacements =>
            new ReplacementData[]
            {
                new(original: "Does", replacement: nameof(ITargetDefinition.Executes), convert: ConvertLambdaBodyToBlock),
                new(original: "IsDependentOn", replacement: nameof(ITargetDefinition.DependsOn), convert: ConvertStringToIdentifier),
                new(original: "IsDependeeOf", replacement: nameof(ITargetDefinition.DependentFor), convert: ConvertStringToIdentifier),
                new(original: "ContinueOnError", replacement: nameof(ITargetDefinition.ProceedAfterFailure)),
                new(original: "WithCriteria", replacement: RenameWithCriteria, convert: ConvertWithCriteria),
                // Logger
                new(original: "Information", replacement: nameof(Logger.Info)),
                new(original: "Verbose", replacement: nameof(Logger.Trace)),
                // FileSystem
                new(original: "CreateDirectory", replacement: nameof(FileSystemTasks.EnsureExistingDirectory)),
                new(original: "CleanDirectory", replacement: nameof(FileSystemTasks.EnsureCleanDirectory)),
                new(original: "CalculateFileHash", replacement: nameof(FileSystemTasks.GetFileHash)),
            };

        private static Func<ExpressionSyntax, ExpressionSyntax> ConvertStringToIdentifier = x =>
        {
            var literalExpression = (LiteralExpressionSyntax) x;
            var targetName = literalExpression.GetConstantValue<string>();
            return IdentifierName(targetName);
        };

        private static Func<ExpressionSyntax, ExpressionSyntax> ConvertLambdaBodyToBlock = x =>
        {
            var lambdaExpression = (LambdaExpressionSyntax) x;
            return lambdaExpression.Block != null
                ? lambdaExpression
                : lambdaExpression
                    .WithExpressionBody(null)
                    .WithBlock(Block(
                        ExpressionStatement(lambdaExpression.ExpressionBody.NotNull())));
        };

        private static Func<InvocationExpressionSyntax, string> RenameWithCriteria => x => x
            .GetSingleArgument<LambdaExpressionSyntax>() == null
            ? nameof(ITargetDefinition.OnlyWhenStatic)
            : nameof(ITargetDefinition.OnlyWhenDynamic);

        private static Func<InvocationExpressionSyntax, ExpressionSyntax, ExpressionSyntax> ConvertWithCriteria => (i, e) => i
            .GetSingleArgument<LambdaExpressionSyntax>() == null
            ? ParenthesizedLambdaExpression(e)
            : e;

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            node = (InvocationExpressionSyntax) base.VisitInvocationExpression(node).NotNull();
            var name = node.GetIdentifierName();
            var replacement = Replacements.SingleOrDefault(x => x.Original == name);
            if (replacement == null)
                return node;

            return node.Expression switch
            {
                IdentifierNameSyntax identifierName => node
                    .WithExpression(identifierName.WithIdentifier(Identifier(replacement.Replacement.Invoke(node))))
                    .WithConvertedArguments(x => replacement.Convert(node, x))
                    .WithReorderedArguments(replacement.Reorder),
                MemberAccessExpressionSyntax memberAccessExpression => node
                    .WithExpression(memberAccessExpression.WithName(IdentifierName(replacement.Replacement.Invoke(node))))
                    .WithConvertedArguments(x => replacement.Convert(node, x))
                    .WithReorderedArguments(replacement.Reorder),
                _ => throw new NotSupportedException(node.Expression.GetType().Name)
            };
        }

        private class ReplacementData
        {
            public ReplacementData(
                string original,
                string replacement,
                Func<ExpressionSyntax, ExpressionSyntax> convert = null,
                Func<ExpressionSyntax[], ExpressionSyntax[]> reorder = null)
                : this(
                    original,
                    _ => replacement,
                    (_, e) => (convert ?? (x => x)).Invoke(e),
                    x => (reorder ?? (x => x)).Invoke(x))
            {
            }

            public ReplacementData(
                string original,
                Func<InvocationExpressionSyntax, string> replacement,
                Func<InvocationExpressionSyntax, ExpressionSyntax, ExpressionSyntax> convert = null,
                Func<ExpressionSyntax[], ExpressionSyntax[]> reorder = null)
            {
                Original = original;
                Replacement = replacement;
                Convert = convert ?? ((_, e) => e);
                Reorder = reorder ?? (x => x);
            }

            public string Original { get; }
            public Func<InvocationExpressionSyntax, string> Replacement { get; }
            public Func<InvocationExpressionSyntax, ExpressionSyntax, ExpressionSyntax> Convert { get; }
            public Func<ExpressionSyntax[], ExpressionSyntax[]> Reorder { get; }
        }
    }
}
