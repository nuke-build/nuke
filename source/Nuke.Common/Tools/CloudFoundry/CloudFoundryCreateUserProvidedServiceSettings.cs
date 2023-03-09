// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Tools.CloudFoundry
{
    public partial class CloudFoundryCreateUserProvidedServiceSettings : ISerializable
    {
        [NonSerialized]
        private JObject _credentials = new();

        public CloudFoundryCreateUserProvidedServiceSettings()
        {
        }

        protected CloudFoundryCreateUserProvidedServiceSettings(SerializationInfo info, StreamingContext context)
        {
            var credentials = (string) info.GetValue(nameof(_credentials), typeof(string));
            if (credentials != null)
                _credentials = JObject.Parse(credentials);

            var writableProperties = GetType().GetProperties().Where(x => x.Name != nameof(Credentials) && x.CanWrite);
            foreach (var property in writableProperties)
                property.SetValue(this, info.GetValue(property.Name, property.PropertyType));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(_credentials), GetCredentials());

            var otherProperties = GetType().GetProperties().Where(x => x.Name != nameof(Credentials));
            foreach (var property in otherProperties)
                info.AddValue(property.Name, property.GetValue(this));
        }

        internal string GetCredentials()
        {
            return _credentials.ToString(Formatting.None);
        }

        public virtual JObject Credentials
        {
            get => _credentials;
            set => _credentials = value;
        }
    }
}
