using System;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string TIMERS_PATH = "timers";
        private const string TIMERS_CURRENT_PATH = "timers/current";
        private const string TEAM_TIMERS_PATH = "team/timers";

        /// <summary>
        /// Timers / Start Timer
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<StartTimerResponse> StartTimerAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));

            return await ExecuteAsync<StartTimerResponse>(CreateRequest(TIMERS_PATH, new StartTimerRequest() { TaskId = taskId })).ConfigureAwait(false);
        }

        /// <summary>
        /// Timers / Start Timer
        /// </summary>
        public async Task<StartTimerResponse> StartTimerAsync(StartTimerRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.TaskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.TaskId));

            return await ExecuteAsync<StartTimerResponse>(CreateRequest(TIMERS_PATH, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Timers / Retrieve Running Timer
        /// </summary>
        public async Task<RetrieveRunningTimerResponse> RetrieveRunningTimerAsync()
        {
            return await ExecuteAsync<RetrieveRunningTimerResponse>(Request(TIMERS_CURRENT_PATH)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Timers / Stop Timer
        /// </summary>
        public async Task<StopTimerResponse> StopTimerAsync()
        {
            return await ExecuteAsync<StopTimerResponse>(DeleteRequest(TIMERS_CURRENT_PATH)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Timers / List Team Users Timers
        /// </summary>
        public async Task<ListTeamUsersTimersResponse> ListTeamUsersTimersAsync()
        {
            return await ExecuteAsync<ListTeamUsersTimersResponse>(Request(TEAM_TIMERS_PATH)).ConfigureAwait(false);
        }
    }
}