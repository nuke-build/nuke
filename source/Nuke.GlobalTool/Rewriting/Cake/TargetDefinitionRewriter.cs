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
    internal class TargetDefinitionRewriter : SafeSyntaxRewriter
    {
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            node = (InvocationExpressionSyntax) base.VisitInvocationExpression(node).NotNull();

            if (node.Expression is IdentifierNameSyntax identifierName &&
                identifierName.Identifier.Text == "Task")
            {
                return SimpleLambdaExpression(Parameter(Identifier("_")))
                    .WithExpressionBody(IdentifierName("_"));
            }

            var memberAccessExpression = node.Expression as MemberAccessExpressionSyntax;
            // if (memberAccessExpression?.GetIdentifierName() == "IsDependentOn" ||
            //     memberAccessExpression?.GetIdentifierName() == "IsDependeeOf")
            // {
            //     node = node.WithExpression(memberAccessExpression
            //         .WithName(IdentifierName(memberAccessExpression.GetIdentifierName()
            //             .Replace("IsDependentOn", nameof(ITargetDefinition.DependsOn))
            //             .Replace("IsDependeeOf", nameof(ITargetDefinition.DependentFor)))));
            //
            //     node = node.WithConvertedArguments(x =>
            //     {
            //         var literalExpression = x as LiteralExpressionSyntax;
            //         var targetName = literalExpression.GetConstantValue<string>();
            //         return IdentifierName(targetName);
            //     });
            // }
            //
            // if (memberAccessExpression?.GetIdentifierName() == "WithCriteria")
            // {
            //     node = node.WithExpression(memberAccessExpression
            //         .WithName(IdentifierName(
            //             node.GetSingleArgument<LambdaExpressionSyntax>() == null
            //                 ? nameof(ITargetDefinition.OnlyWhenStatic)
            //                 : nameof(ITargetDefinition.OnlyWhenDynamic))));
            //
            //     if (node.GetSingleArgument<LambdaExpressionSyntax>() == null)
            //         node = node.WithConvertedArguments(ParenthesizedLambdaExpression);
            // }

            // if (memberAccessExpression?.GetIdentifierName() == "Does")
            // {
            //     node = node.WithExpression(memberAccessExpression
            //         .WithName(IdentifierName("Executes")));
            //
            //     node = node.WithConvertedArguments(x =>
            //     {
            //         var lambdaExpression = (LambdaExpressionSyntax) x;
            //         return lambdaExpression.Block != null
            //             ? lambdaExpression
            //             : lambdaExpression
            //                 .WithExpressionBody(null)
            //                 .WithBlock(Block(ExpressionStatement(lambdaExpression.ExpressionBody.NotNull())));
            //     });
            // }

            return node;
        }

        public override SyntaxNode VisitGlobalStatement(GlobalStatementSyntax node)
        {
            var reducedNode = (GlobalStatementSyntax) base.VisitGlobalStatement(node).NotNull();

            if (node.Statement is not ExpressionStatementSyntax expressionStatement)
                return reducedNode;

            var innerInvocationExpression = (expressionStatement.Expression as InvocationExpressionSyntax)
                .Descendants(x => (x.Expression as MemberAccessExpressionSyntax)?.Expression as InvocationExpressionSyntax)
                .LastOrDefault();

            if (innerInvocationExpression?.GetIdentifierName() == "Task")
            {
                var name = innerInvocationExpression.GetSingleArgument<LiteralExpressionSyntax>()
                    .GetConstantValue<string>()
                    .Replace("-", "_");
                var expression = ((ExpressionStatementSyntax) reducedNode.Statement).Expression;
                return PropertyDeclaration(ParseTypeName(nameof(Target)), name)
                    .WithExpressionBody(ArrowExpressionClause(expression))
                    .WithSemicolonToken(expressionStatement.SemicolonToken);
            }

            return reducedNode;
        }
    }
}
