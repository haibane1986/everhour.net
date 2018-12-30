using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<AddTimeToTaskResponse> AddTimeToTaskAsync(string taskId, int time, DateTime date);
        Task<AddTimeToTaskResponse> AddTimeToTaskAsync(AddTimeToTaskRequest request);
        Task<UpdateTimeInTaskResponse> UpdateTimeInTaskAsync(string taskId, int time, DateTime date);
        Task<UpdateTimeInTaskResponse> UpdateTimeInTaskAsync(UpdateTimeInTaskRequest request);
        Task<DeleteTimeInTaskResponse> DeleteTimeInTaskAsync(string taskId, DateTime date);
        Task<DeleteTimeInTaskResponse> DeleteTimeInTaskAsync(DeleteTimeInTaskRequest request);
        Task<ListUserTimeRecordsResponse> ListUserTimeRecordsAsync(int userId, int limit);
        Task<ListUserTimeRecordsResponse> ListUserTimeRecordsAsync(ListUserTimeRecordsRequest request);
        Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync();
        Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync(DateTime date);
        Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync(DateTime from, DateTime to);
        Task<ListTaskTimeRecordsResponse> ListTaskTimeRecordsAsync(string taskId);
    }
}