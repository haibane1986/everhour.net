using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Estimate
    {
        /// <summary>
        /// Total task estimate in seconds.
        /// <example>
        /// 7200
        /// </example>
        /// </summary>
        public int? Total { get; set; }

        /// <summary>
        /// <example>
        /// overall or users
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<EstimateType>))]
        public EstimateType Type { get; set; }

        [JsonConverter(typeof(UserWithTimeConverter))]
        public List<UserWithTime> Users { get; set; }
    }
}