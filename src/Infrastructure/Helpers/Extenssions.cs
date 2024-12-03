using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Helpers
{
    public static class Extenssions
    {
        private static readonly JsonSerializerSettings defaultSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            TypeNameHandling = TypeNameHandling.None,
            ContractResolver = new DefaultContractResolver(),
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateFormatString = @"yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK",
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        /// <summary>
        /// Serializes <paramref name="o"/> to a JSON string.
        /// </summary>
        /// <param name="o">The instance to serialize.</param>
        /// <returns>The resulting JSON object as a string.</returns>
        public static string ToJson(this object o) =>
            o != null ? JsonConvert.SerializeObject(o, defaultSettings) : null;

        public static T ToConvert<T>(this string o) =>
            o != null ? JsonConvert.DeserializeObject<T>(o, defaultSettings) : default;
    }
}
