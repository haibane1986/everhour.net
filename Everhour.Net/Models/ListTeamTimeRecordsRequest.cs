using System;
using System.Web;

namespace Everhour.Net.Models
{
    public class ListTeamTimeRecordsRequest: EverhourRequest
    {
        /// <summary>
        /// Date from you want to fetch task time (format YYYY-MM-DD).
        /// <example>
        /// 2018-01-01
        /// </example>
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Date to you want to fetch task time (format YYYY-MM-DD).
        /// <example>
        /// 2018-01-31
        /// </example>
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// Single date you want to fetch task time (format YYYY-MM-DD).
        /// <example>
        /// 2018-01-15
        /// </example>
        /// </summary>
        public DateTime? Date { get; set; }

        public override string ToQuery() 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (From.HasValue) query["from"] = From.Value.ToString("yyyy-MM-dd");
            if (To.HasValue) query["to"] = To.Value.ToString("yyyy-MM-dd");
            if (Date.HasValue) query["date"] = Date.Value.ToString("yyyy-MM-dd");
            return query.ToString();
        }
    }
}