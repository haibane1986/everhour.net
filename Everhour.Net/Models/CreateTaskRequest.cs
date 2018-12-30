using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateTaskRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// <example>
        /// Project ID
        /// </example>
        /// </summary>
        [JsonProperty("project_id", Required = Required.Always)]
        public string ProjectId { get; set; }

        /// <summary>
        /// Task Name.
        /// <example>
        /// Task Name
        /// </example>
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Section ID.
        /// <example>
        /// 1234
        /// </example>
        /// </summary>
        [JsonProperty("section", Required = Required.Always)]
        public int Section { get; set; }

        /// <summary>
        /// <example>
        /// high
        /// <para/>
        /// bug
        /// </example>
        /// </summary>
        [JsonProperty("labels")]
        public IList<string> Labels { get; set; }

        /// <summary>
        /// <example>
        /// 1
        /// </example>
        /// </summary>
        [JsonProperty("position")]
        public int? Position { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Format: Y-m-d H:i:s
        /// <example>
        /// 2018-03-05 16:00:00
        /// </example>
        /// </summary>
        [JsonProperty("dueAt")]
        public DateTime? DueAt { get; set; }

        /// <summary>
        /// <example>
        /// open or closed
        /// </example>
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(EnumerationConverter<TaskStatus>))]
        public TaskStatus Status { get; set; }
    }
}