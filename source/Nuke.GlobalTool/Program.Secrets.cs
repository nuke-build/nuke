// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Constants;
using static Nuke.Common.Utilities.EncryptionUtility;

namespace Nuke.GlobalTool
{
    // TODO: unlock prompt
    // TODO: environment variable name
    // TODO: profile vs. environment
    // TODO: nuke :profile <name>
    partial class Program
    {
        private const string SaveAndExit = "<Save & Exit>";
        private const string DiscardAndExit = "<Discard & Exit>";
        private const string DeletePasswordAndExit = "<Delete Password & Exit>";

        // ReSharper disable once CognitiveComplexity
        [UsedImplicitly]
        public static int Secrets(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var secretParameters = GetSecretParameters(rootDirectory.NotNull("No root directory")).ToList();
            if (secretParameters.Count == 0)
            {
                Host.Information($"There are no parameters marked with {nameof(SecretAttribute)}");
                return 0;
            }

            var profile = args.SingleOrDefault();
            var parametersFile = profile == null
                ? GetDefaultParametersFile(rootDirectory)
                : GetParametersProfileFile(rootDirectory, profile);

            var generatedPassword = false;
            var credentialStoreName = GetCredentialStoreName(rootDirectory, profile);
            var password = TryGetPasswordFromCredentialStore(credentialStoreName);
            var fromCredentialStore = password != null;
            password ??= CreateNewPassword(out generatedPassword);
            var existingSecrets = LoadSecrets(secretParameters, password, parametersFile);

            if (EnvironmentInfo.IsOsx && existingSecrets.Count == 0 && !fromCredentialStore)
            {
                if (generatedPassword || PromptForConfirmation($"Save password to keychain? (associated with '{rootDirectory}')"))
                    SavePasswordToCredentialStore(credentialStoreName, password);
            }

            var options = secretParameters
                .Concat(SaveAndExit, DiscardAndExit)
                .Concat(fromCredentialStore ? DeletePasswordAndExit : null).WhereNotNull().ToList();

            var addedSecrets = new Dictionary<string, string>();
            while (true)
            {
                var choice = PromptForChoice(
                    "Choose secret parameter to enter value:",
                    options.Select(x => (x, addedSecrets.ContainsKey(x) || existingSecrets.ContainsKey(x) ? $"* {x}" : x)).ToArray());

                if (!choice.EqualsAnyOrdinalIgnoreCase(SaveAndExit, DiscardAndExit, DeletePasswordAndExit))
                {
                    addedSecrets[choice] = PromptForSecret(choice);
                }
                else
                {
                    if (choice == SaveAndExit)
                        SaveSecrets(addedSecrets, password, parametersFile);

                    if (choice == DeletePasswordAndExit)
                        DeletePasswordFromCredentialStore(credentialStoreName);

                    if (addedSecrets.Any())
                        Host.Information("Remember to clear your clipboard!");

                    return 0;
                }
            }
        }

        private static Dictionary<string, string> LoadSecrets(IReadOnlyCollection<string> secretParameters, string password, AbsolutePath parametersFile)
        {
            var jobject = parametersFile.ReadJson();
            return jobject.Properties()
                .Where(x => secretParameters.Contains(x.Name))
                .ToDictionary(x => x.Name, x => Decrypt(x.Value.Value<string>(), password, x.Name));
        }

        private static void SaveSecrets(Dictionary<string, string> secrets, string password, AbsolutePath parametersFile)
        {
            parametersFile.UpdateJson(obj =>
            {
                foreach (var (name, secret) in secrets)
                    obj[name] = Encrypt(secret, password);
            });
        }

        private static IEnumerable<string> GetSecretParameters(AbsolutePath rootDirectory)
        {
            var buildSchemaFile = GetBuildSchemaFile(rootDirectory);
            var jobject = buildSchemaFile.ReadJson();
            return jobject
                .GetPropertyValue("definitions")
                .GetPropertyValue("build")
                .GetPropertyValue("properties")
                .Children<JProperty>()
                .Where(x => x.Value.Value<JObject>().GetPropertyValueOrNull<string>("default") != null)
                .Select(x => x.Name);
        }
    }
}
