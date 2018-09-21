using System;
using System.Web;

namespace Everhour.Net.Models {
    public class ExportAllTeamEstimatesRequest : EverhourRequest 
    {
        public ExportAllTeamEstimatesRequest(DateTime dueFrom, DateTime dueTo) 
        {
            DueFrom = dueFrom;
            DueTo = dueTo;
        }

        /// <summary>
        /// Task due date from you what to fetch estimates.
        /// <example>
        /// 2018-01-01
        /// </example>
        /// </summary>
        public DateTime DueFrom { get; private set; }

        /// <summary>
        /// Task due date to you what to fetch estimate.
        /// <example>
        /// 2018-01-31
        /// </example>
        /// </summary>
        public DateTime DueTo { get; private set; }

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
            query["dueFrom"] = DueFrom.ToString("yyyy-MM-dd");
            query["dueTo"] = DueTo.ToString("yyyy-MM-dd");
            if (Status != null) query["status"] = Status.Name;
            return query.ToString();
        }
    }
}