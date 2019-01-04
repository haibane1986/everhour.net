using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string TEAM_TIME_EXPORT_PATH = "team/time/export";

        /// <summary>
        /// Export Time / Export All Team Time
        /// </summary>
        /// <param name="from">Date from you what to fetch reported time.</param>
        /// <param name="to">Date to you what to fetch reported time.</param>
        public async Task<ExportAllTeamTimeResponse> ExportAllTeamTimeAsync(DateTime from, DateTime to) =>  await ExecuteAsync<ExportAllTeamTimeResponse>(Request(new UriBuilder() { Path = TEAM_TIME_EXPORT_PATH, Query = new ExportAllTeamTimeRequest() { From = from, To = to }.ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);

        /// <summary>
        /// Export Time / Export All Team Time
        /// </summary>
        public async Task<ExportAllTeamTimeResponse> ExportAllTeamTimeAsync(ExportAllTeamTimeRequest request) 
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));

            return await ExecuteAsync<ExportAllTeamTimeResponse>(Request(new UriBuilder() { Path = TEAM_TIME_EXPORT_PATH, Query = request?.ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);
        }
    }
}