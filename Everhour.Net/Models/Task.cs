using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Task
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
        /// 1234
        /// </example>
        /// </summary>
        public IList<string> Projects { get; set; }

        /// <summary>
        /// Section ID.
        /// <example>
        /// 1234
        /// </example>
        /// </summary>
        public int? Section { get; set; }

        /// <summary>
        /// <example>
        /// high
        /// <para/>
        /// bug
        /// </example>
        /// </summary>
        public IList<string> Labels { get; set; }

        /// <summary>
        /// <example>
        /// 1
        /// </example>
        /// </summary>
        public int? Position { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// Format: Y-m-d H:i:s
        /// <example>
        /// 2018-03-05 16:00:00
        /// </example>
        /// </summary>
        public DateTime? DueAt { get; set; }

        /// <summary>
        /// <example>
        /// open or closed
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<TaskStatus>))]
        public TaskStatus Status { get; set; }

        public Time Time { get; set; }

        public Estimate Estimate { get; set; }

        /// <summary>
        /// Custom attributes from integration.
        /// </summary>
        public Attribute Attributes { get; set; }

        /// <summary>
        /// Custom metrics from integration.
        /// </summary>
        public Metrics Metrics { get; set; }
    }
}