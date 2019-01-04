using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class TeamTask
    {
        /// <summary>
        /// <example>
        /// ev:1234567890
        /// </example>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <example>
        /// Task Name
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <example>
        /// open or closed
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<TaskStatus>))]
        public TaskStatus Status { get; set; }

        /// <summary>
        /// <example>
        /// task
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<TaskType>))]
        public TaskType Type { get; set; }

        /// <summary>
        /// <example>
        /// Iteration/column/section name
        /// </example>
        /// </summary>
        public string Iteration { get; set; }

        /// <summary>
        /// Task number
        /// <example>
        /// 123
        /// </example>
        /// </summary>
        public int? Number { get; set; }

        /// <summary>
        /// <example>
        /// 2018-01-20
        /// </example>
        /// </summary>
        public DateTime? DueAt { get; set; }

        public List<string> Labels { get; set; }
    }
}