using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class DeleteTimeInTaskRequest: EverhourRequest
    {
        /// <summary>
        /// Task ID.
        /// <example>
        /// ev:9876543210
        /// </example>
        /// </summary>
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        /// <summary>
        /// User ID.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        [JsonProperty("user")]
        public int? User { get; set; }

        /// <summary>
        /// Date.
        /// <example>
        /// 2018-01-20
        /// </example>
        /// </summary>
        [JsonConverter(typeof(DateConverter))]
        [JsonProperty("date", Required = Required.Always)]
        public DateTime Date { get; set; }
    }
}