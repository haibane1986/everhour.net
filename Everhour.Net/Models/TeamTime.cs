
using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class TeamTime
    {
        /// <summary>
        /// Report time in seconds
        /// <example>
        /// 7200
        /// </example>
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Billable time
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        [JsonProperty("billable_time")]
        public int BillableTime { get; set; }

        /// <summary>
        /// Will appear only if 'date' passed to fields parameter.
        /// <example>
        /// 2018-03-20
        /// </example>
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Will appear only if 'user' passed to fields parameter.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Will appear only if 'project' passed to fields parameter.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Will appear only if 'task' passed to fields parameter.
        /// </summary>
        public TeamTask Task { get; set; }
    }
}