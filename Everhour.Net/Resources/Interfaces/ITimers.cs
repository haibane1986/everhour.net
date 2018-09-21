using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<StartTimerResponse> StartTimerAsync(string taskId);
        Task<StartTimerResponse> StartTimerAsync(StartTimerRequest request);
        Task<RetrieveRunningTimerResponse> RetrieveRunningTimerAsync();
        Task<StopTimerResponse> StopTimerAsync();
        Task<ListTeamUsersTimersResponse> ListTeamUsersTimersAsync();
    }
}