// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Utilities
{
    public static class CompletionUtility
    {
        // ReSharper disable once CognitiveComplexity
        public static IEnumerable<string> GetRelevantCompletionItems(
            string words,
            IReadOnlyDictionary<string, string[]> completionItems)
        {
            completionItems = new Dictionary<string, string[]>(completionItems.ToDictionary(x => x.Key, x => x.Value), StringComparer.OrdinalIgnoreCase).AsReadOnly();
            var suggestedItems = new List<string>();

            var parts = words.Split(separator: ' ');
            var currentWord = parts.Last() != string.Empty ? parts.Last() : null;
            var parameters = parts.Where(ParameterService.IsParameter).Select(ParameterService.GetParameterMemberName).ToList();
            var lastParameter = parameters.LastOrDefault();

            void AddParameters()
            {
                var useDashes = currentWord == null ||
                                currentWord.TrimStart('-').Length == 0 ||
                                currentWord.StartsWith("--");
                var items = completionItems.Keys
                    .Except(parameters, StringComparer.InvariantCultureIgnoreCase)
                    .Select(x => useDashes
                        ? $"--{ParameterService.GetParameterDashedName(x)}"
                        : $"-{x}");

                AddItems(items);
            }

            void AddTargetsOrValues(string parameter)
            {
                var passedItems = parts
                    .Reverse()
                    .TakeUntil(ParameterService.IsParameter)
                    .Select(ParameterService.GetParameterMemberName);

                var items = completionItems.GetValueOrDefault(parameter)?.Except(passedItems, StringComparer.OrdinalIgnoreCase) ??
                            new string[0];

                if (parameter.EqualsOrdinalIgnoreCase(Constants.InvokedTargetsParameterName))
                    items = items.Select(x => x.SplitCamelHumpsWithSeparator("-", Constants.KnownWords));

                AddItems(items);
            }

            void AddItems(IEnumerable<string> items)
            {
                foreach (var item in items)
                {
                    if (currentWord == null)
                        suggestedItems.Add(item);
                    else if (item.StartsWithOrdinalIgnoreCase(currentWord))
                    {
                        var normalizedItem = item.ReplaceRegex(currentWord, _ => currentWord, RegexOptions.IgnoreCase);
                        if (normalizedItem != item)
                        {
                            var letters = currentWord.Where(char.IsLetter).ToList();
                            if (letters.All(char.IsUpper))
                                normalizedItem = normalizedItem.ToUpperInvariant();
                            else if (letters.All(char.IsLower))
                                normalizedItem = normalizedItem.ToLowerInvariant();
                        }

                        suggestedItems.Add(normalizedItem);
                    }
                }
            }

            if (lastParameter == null)
                AddTargetsOrValues(Constants.InvokedTargetsParameterName);
            else if (currentWord != lastParameter)
                AddTargetsOrValues(lastParameter);

            if (currentWord == null || ParameterService.IsParameter(currentWord))
                AddParameters();

            return suggestedItems;
        }
    }
}
