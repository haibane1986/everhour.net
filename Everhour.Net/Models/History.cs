using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class History
    {
        /// <summary>
        /// Time record history ID.
        /// <example>
        /// 4622379
        /// </example>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User ID.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Time difference in seconds.
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Previous time in seconds.
        /// <example>
        /// 0
        /// </example>
        /// </summary>
        public int PreviousTime { get; set; }

        /// <summary>
        /// <example>
        /// TIMER or ADD or EDIT or REMOVE or COMMENT or MOVE
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<HistoryStatus>))]
        public HistoryStatus Status { get; set; }

        /// <summary>
        /// <example>
        /// 2018-01-16 12:42:59
        /// </example>
        /// </summary>
        public DateTime? CreatedAt { get; set; }
    }
}