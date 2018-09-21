using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ExportAllTeamTimeResponse> ExportAllTeamTimeAsync(DateTime from, DateTime to);
        Task<ExportAllTeamTimeResponse> ExportAllTeamTimeAsync(ExportAllTeamTimeRequest request);
    }
}