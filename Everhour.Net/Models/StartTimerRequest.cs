using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class StartTimerRequest: EverhourRequest
    {
        /// <summary>
        /// <example>
        /// ev:9876543210
        /// </example>
        /// </summary>
        [JsonProperty("task", Required = Required.Always)]
        public string TaskId { get; set; }

        /// <summary>
        /// <example>
        /// 2018-01-16
        /// </example>
        /// </summary>
        [JsonConverter(typeof(DateConverter))]
        [JsonProperty("userDate")]
        public DateTime? UserDate { get; set; }

        /// <summary>
        /// <example>
        /// </example>
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}