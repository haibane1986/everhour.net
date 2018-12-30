using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ListAllProjectsResponse> ListAllProjectsAsync(ListAllProjectsRequest request);
        Task<CreateProjectResponse> CreateProjectAsync(CreateProjectRequest request);
        Task<CreateProjectResponse> CreateProjectAsync(string name, ProjectType type);
        Task<RetrieveProjectResponse> RetrieveProjectAsync(string projectId);
        Task<UpdateProjectResponse> UpdateProjectAsync(UpdateProjectRequest request);
        Task<UpdateProjectResponse> UpdateProjectAsync(string projectId, string name, ProjectType type);
        Task<bool> DeleteProjectAsync(string projectId);
        Task<SetProjectBudgetResponse> SetProjectBudgetAsync(string projectId, BudgetType type, int budget);
        Task<bool> DeleteProjectBudgetAsync(string projectId);
        Task<SetProjectBillingResponse> SetProjectBillingByFlatRateAsync(string projectId, int rate);
        Task<SetProjectBillingResponse> SetProjectBillingByUserRateAsync(string projectId, IList<UserWithRate> users);
        Task<bool> DeleteProjectBillingAsync(string projectId);
    }
}