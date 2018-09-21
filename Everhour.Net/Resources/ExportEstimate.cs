using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string TEAM_ESTIMATE_EXPORT_PATH = "team/estimate/export";

        /// <summary>
        /// Export Estimates / Export All Team Estimates
        /// </summary>
        /// <param name="from">Task due date from you what to fetch estimates.</param>
        /// <param name="to">Task due date to you what to fetch estimates.</param>
        public async Task<ExportAllTeamEstimatesResponse> ExportAllTeamEstimatesAsync(DateTime dueFrom, DateTime dueTo) =>  await ExecuteAsync<ExportAllTeamEstimatesResponse>(Request(new UriBuilder() { Path = TEAM_TIME_EXPORT_PATH, Query = new ExportAllTeamEstimatesRequest(dueFrom, dueTo).ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);

        /// <summary>
        /// Export Estimates / Export All Team Estimates
        /// </summary>
        public async Task<ExportAllTeamEstimatesResponse> ExportAllTeamEstimatesAsync(ExportAllTeamEstimatesRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));

            return await ExecuteAsync<ExportAllTeamEstimatesResponse>(Request(new UriBuilder() { Path = TEAM_ESTIMATE_EXPORT_PATH, Query = request?.ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);
        }
    }
}