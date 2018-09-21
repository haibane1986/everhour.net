using System;
using System.Collections.Generic;

namespace Everhour.Net.Models
{
    public class TeamTimeRecord
    {
        /// <summary>
        /// Time record ID.
        /// <example>
        /// 2660155
        /// </example>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Time recorded in seconds.
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// User ID.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        public int User { get; set; }

        /// <summary>
        /// Date.
        /// <example>
        /// 2018-01-20
        /// </example>
        /// </summary>
        public DateTime Date { get; set; }

        public Task Task { get; set; }

        /// <summary>
        /// <example>
        /// false
        /// </example>
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// <example>
        /// false
        /// </example>
        /// </summary>
        public bool IsInvoiced { get; set; }

        /// <summary>
        /// <example>
        /// some notes
        /// </example>
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// <example>
        /// some notes
        /// </example>
        /// </summary>
        public IList<History> History { get; set; }
    }
}