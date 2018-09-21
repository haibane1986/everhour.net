using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Time
    {
        /// <summary>
        /// Total task time in seconds.
        /// <example>
        /// 7200
        /// </example>
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// User id and task time.
        /// </summary>
        [JsonConverter(typeof(UserWithTimeConverter))]
        public List<UserWithTime> Users { get; set; }
    }
}