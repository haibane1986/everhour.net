using System;
using System.Web;

namespace Everhour.Net.Models {
    public class ExportAllTeamEstimatesRequest : EverhourRequest 
    {
        /// <summary>
        /// Task due date from you what to fetch estimates.
        /// <example>
        /// 2018-01-01
        /// </example>
        /// </summary>
        public DateTime? DueFrom { get; set; }

        /// <summary>
        /// Task due date to you what to fetch estimate.
        /// <example>
        /// 2018-01-31
        /// </example>
        /// </summary>
        public DateTime? DueTo { get; set; }

        /// <summary>
        /// Task status (e.g. open or completed).
        /// <example>
        /// open
        /// </example>
        /// </summary>
        public TaskStatus Status { get; set; }

        public override string ToQuery() 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (DueFrom.HasValue) query["dueFrom"] = DueFrom.Value.ToString("yyyy-MM-dd");
            if (DueTo.HasValue) query["dueTo"] = DueTo.Value.ToString("yyyy-MM-dd");
            if (Status != null) query["status"] = Status.Name;
            return query.ToString();
        }
    }
}