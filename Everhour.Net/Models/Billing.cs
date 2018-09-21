using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Billing
    {
        /// <summary>
        /// Project Type.
        /// <example>
        /// flat_rate or user_rate
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<BillingType>))]
        public BillingType Type { get; set; }

        /// <summary>
        /// Flat-rate in cents (e.g. 10000 means $100.00)
        /// <example>
        /// 10000
        /// </example>
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// User ID=xxxx has billable rate $100.00/hrs (10000 cents).
        /// <example>
        /// 10000
        /// </example>
        /// </summary>
        [JsonConverter(typeof(UserWithRateConverter))]
        public List<UserWithRate> Users { get; set; }
    }
}