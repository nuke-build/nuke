// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;

namespace Nuke.Common.Utilities.Net
{
    // TODO: reduce with overloads
    public static partial class HttpResponseExtensions
    {
        /// <summary>
        /// Reads the HTTP response body as JSON.
        /// </summary>
        public static async Task<T> GetBodyAsJson<T>(this HttpResponseInspector inspector)
        {
            return JsonConvert.DeserializeObject<T>(await inspector.GetBodyAsync());
        }

        /// <summary>
        /// Reads the HTTP response body as JSON.
        /// </summary>
        public static async Task<JObject> GetBodyAsJson(this HttpResponseInspector inspector)
        {
            return await inspector.GetBodyAsJson<JObject>();
        }

        /// <summary>
        /// Reads the HTTP response body as JSON.
        /// </summary>
        public static async Task<T> GetBodyAsJson<T>(this HttpResponseInspector inspector, JsonSerializerSettings settings)
        {
            return JsonConvert.DeserializeObject<T>(await inspector.GetBodyAsync(), settings);
        }

        /// <summary>
        /// Reads the HTTP response body as JSON.
        /// </summary>
        public static async Task<JObject> GetBodyAsJson(this HttpResponseInspector inspector, JsonSerializerSettings settings)
        {
            return await inspector.GetBodyAsJson<JObject>(settings);
        }

        public static async Task WriteToFile(this HttpResponseInspector inspector, AbsolutePath path, FileMode mode = FileMode.CreateNew)
        {
            using var fileStream = File.Open(path, mode);
            await inspector.Response.Content.CopyToAsync(fileStream);
        }
    }
}
