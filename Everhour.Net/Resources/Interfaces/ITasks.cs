using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ListTasksResponse> ListProjectTasksAsync(string projectId);
        Task<CreateTaskResponse> CreateTaskAsync(CreateTaskRequest request);
        Task<CreateTaskResponse> CreateTaskAsync(string projectId, string name, int section);
        Task<RetrieveTaskResponse> RetrieveTaskAsync(string taskId);
        Task<UpdateTaskResponse> UpdateTaskAsync(UpdateTaskRequest request);
        Task<UpdateTaskResponse> UpdateTaskAsync(string taskId, string name, int section);
        Task<bool> DeleteTaskAsync(string taskId);
        Task<SetTaskEstimateResponse> SetTaskEstimateAsync(SetTaskEstimateRequest request);
        Task<SetTaskEstimateResponse> SetTaskEstimateAsync(string taskId, EstimateType type, int total, IList<UserWithTaskEstimate> users);
        Task<bool> DeleteTaskEstimateAsync(string taskId);
    }
}