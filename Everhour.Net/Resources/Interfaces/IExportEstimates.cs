using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ExportAllTeamEstimatesResponse> ExportAllTeamEstimatesAsync();

        Task<ExportAllTeamEstimatesResponse> ExportAllTeamEstimatesAsync(ExportAllTeamEstimatesRequest request);
    }
}