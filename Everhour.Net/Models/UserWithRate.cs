using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UserWithRate
    {
        /// <summary>
        /// Identifier of the user.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        [JsonProperty("id", Required=Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// Billable rate in cents.
        /// <example>
        /// 10000
        /// </example>
        /// </summary>
        [JsonProperty("rate", Required=Required.Always)]
        public int Rate { get; set; }
    }
}