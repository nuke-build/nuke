// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.CloudFoundry
{
    public partial class CloudFoundryCreateUserProvidedServiceSettingsExtensions
    {
        public static CloudFoundryCreateUserProvidedServiceSettings SetCredentials(
            this CloudFoundryCreateUserProvidedServiceSettings toolSettings,
            Dictionary<string, string> credentials)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Credentials = JObject.FromObject(credentials);
            return toolSettings;
        }

        public static CloudFoundryCreateUserProvidedServiceSettings SetCredentials(
            this CloudFoundryCreateUserProvidedServiceSettings toolSettings,
            string key,
            string value)
        {
            // credentials are often simple key value pairs but don't have to be,
            // they can be a more complex data structure, so core value is JObject. 
            toolSettings = toolSettings.NewInstance();
            toolSettings.Credentials.SetKeyValue(key, value);
            return toolSettings;
        }

        public static CloudFoundryCreateUserProvidedServiceSettings SetCredentials(
            this CloudFoundryCreateUserProvidedServiceSettings toolSettings,
            string credentialsFile)
        {
            toolSettings = toolSettings.NewInstance();

            using (var file = File.OpenText(credentialsFile))
            using (var reader = new JsonTextReader(file))
            {
                toolSettings.Credentials = (JObject) JToken.ReadFrom(reader);
            }

            return toolSettings;
        }
    }
}
