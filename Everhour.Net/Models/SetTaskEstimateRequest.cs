using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    internal class SetTaskEstimateRequest: EverhourRequest
    {
        /// <summary>
        /// Task ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Total task estimate in seconds.
        /// <example>
        /// 7200
        /// </example>
        /// </summary>
        [JsonProperty("total", Required = Required.Always)]
        public int? Total { get; set; }

        /// <summary>
        /// <example>
        /// overall or users
        /// </example>
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(EnumerationConverter<EstimateType>))]
        public EstimateType Type { get; set; }

        /// <summary>
        /// Task estimate for user ID=1234
        /// <example>
        /// 1234=3600
        /// </example>
        /// </summary>
        [JsonProperty("users")]
        [JsonConverter(typeof(UserWithTaskEstimateConverter))]
        public IList<UserWithTaskEstimate> Users { get; set; }
    }
}