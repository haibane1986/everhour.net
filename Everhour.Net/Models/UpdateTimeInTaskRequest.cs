using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateTimeInTaskRequest
    {
        /// <summary>
        /// Task ID.
        /// </summary>
        [JsonProperty("task_id", Required = Required.Always)]
        public string TaskId { get; set; }

        /// <summary>
        /// Time in seconds.
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        [JsonProperty("time", Required = Required.Always)]
        public int Time { get; set; }

        /// <summary>
        /// Date.
        /// <example>
        /// 2018-01-20
        /// </example>
        /// </summary>
        [JsonProperty("date", Required = Required.Always)]
        public DateTime Date { get; set; }

        /// <summary>
        /// User ID.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        [JsonProperty("user")]
        public int User { get; set; }
    }
}