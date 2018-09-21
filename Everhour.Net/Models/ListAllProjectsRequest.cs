using System;
using System.Collections.Generic;
using System.Web;

namespace Everhour.Net.Models
{
    public class ListAllProjectsRequest: EverhourRequest
    {

        /// <summary>
        /// Max results.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Search projects by name.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Filter by integration.
        /// <example>
        /// Possible values: as, ev, b3, b2, pv, gh, in, tr, jr.
        /// </example>
        /// </summary>
        public ListAllProjectsPlatform? Platform { get; set; }

        public override string ToQuery() 
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            if (Limit.HasValue) query["limit"] = Limit.Value.ToString();
            if (!string.IsNullOrEmpty(Query)) query["query"] = Query;
            if (Platform.HasValue) query["platform"] = Platform.Value.ToLower();
            return query.ToString();
        }
    }
}