// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;

namespace Nuke.Common.Execution
{
    internal class DelegateConverter : JsonConverter
    {
        private readonly Func<object, object> _convertToJson;
        private readonly Func<object, object> _convertFromJson;

        public DelegateConverter(
            Func<object, object> convertToJson,
            Func<object, object> convertFromJson)
        {
            _convertToJson = convertToJson;
            _convertFromJson = convertFromJson;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(_convertToJson(value));
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            return _convertFromJson(reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
