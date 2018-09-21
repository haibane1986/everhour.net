using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Timer
    {
        /// <summary>
        /// <example>
        /// active or stopped
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<TimerStatus>))]
        public TimerStatus Status { get; set; }

        /// <summary>
        /// Timer duration in seconds.
        /// <example>
        /// 16
        /// </example>
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Today time by user in the timer task.
        /// <example>
        /// 7200
        /// </example>
        /// </summary>
        public int Today { get; set; }

        /// <summary>
        /// <example>
        /// 2018-01-16 12:42:59
        /// </example>
        /// </summary>
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// <example>
        /// 2018-01-16
        /// </example>
        /// </summary>
        public DateTime UserDate { get; set; }

        /// <summary>
        /// <example>
        /// </example>
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// <example>
        /// </example>
        /// </summary>
        public Task Task { get; set; }

        /// <summary>
        /// <example>
        /// </example>
        /// </summary>
        public User User { get; set; }
    }
}