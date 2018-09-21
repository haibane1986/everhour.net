using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetProjectBillingRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }
        
        /// <summary>
        /// Budget Type
        /// <example>
        /// flat_rate or user_rate
        /// </example>
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(EnumerationConverter<BillingType>))]
        public BillingType Type { get; set; }

        /// <summary>
        /// Flat-rate in cents (e.g. 10000 means $100.00)
        /// <example>
        /// 10000
        /// </example>
        /// </summary>
        [JsonProperty("rate")]
        public int? Rate { get; set; }

        /// <summary>
        /// User ID=1234 and billable rate $100.00/hrs (10000 cents)
        /// <example>
        /// 1234=10000
        /// </example>
        /// </summary>
        [JsonProperty("users")]
        [JsonConverter(typeof(UserWithRateConverter))]
        public IList<UserWithRate> Users { get; set; }
    }
}