using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UserWithTaskEstimate
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
        /// Task estimate.
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        [JsonProperty("taskEstimate", Required=Required.Always)]
        public int TaskEstimate { get; set; }
    }
}