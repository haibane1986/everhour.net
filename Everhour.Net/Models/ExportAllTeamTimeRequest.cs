using System;
using System.Collections.Generic;
using System.Web;

namespace Everhour.Net.Models
{
    public class ExportAllTeamTimeRequest: EverhourRequest
    {
        public ExportAllTeamTimeRequest(DateTime from, DateTime to) 
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Date from you what to fetch reported time.
        /// <example>
        /// 2018-01-01
        /// </example>
        /// </summary>
        public DateTime From { get; private set; }

        /// <summary>
        /// Date to you what to fetch reported time.
        /// <example>
        /// 2018-01-31
        /// </example>
        /// </summary>
        public DateTime To { get; private set; }

        /// <summary>
        /// Comma separated objects to group by and fetch (allowed: user, project, task and date).
        /// <example>
        /// date,user,task
        /// </example>
        /// </summary>
        public ExportAllTeamTimeField? Fields { get; set; }

        public override string ToQuery() 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["from"] = From.ToString("yyyy-MM-dd");
            query["to"] = To.ToString("yyyy-MM-dd");
            if (Fields.HasValue) {
                var fields = new List<string>();
                if ((Fields & ExportAllTeamTimeField.DATE) == ExportAllTeamTimeField.DATE) fields.Add(ExportAllTeamTimeField.DATE.ToLower());
                if ((Fields & ExportAllTeamTimeField.PROJECT) == ExportAllTeamTimeField.PROJECT) fields.Add(ExportAllTeamTimeField.PROJECT.ToLower());
                if ((Fields & ExportAllTeamTimeField.TASK) == ExportAllTeamTimeField.TASK) fields.Add(ExportAllTeamTimeField.TASK.ToLower());
                if ((Fields & ExportAllTeamTimeField.USER) == ExportAllTeamTimeField.USER) fields.Add(ExportAllTeamTimeField.USER.ToLower());
                query["fields"] = string.Join(",", fields);
            }
            return query.ToString();
        }
    }
}