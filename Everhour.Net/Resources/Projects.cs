using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string PROJECTS_PATH = "projects";
        
        /// <summary>
        /// Projects / List All Projects
        /// </summary>
        public async Task<ListAllProjectsResponse> ListAllProjectsAsync(ListAllProjectsRequest request = null) =>  await ExecuteAsync<ListAllProjectsResponse>(ListRequest(new UriBuilder() { Path = PROJECTS_PATH, Query = request?.ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);

        /// <summary>
        /// Projects / Create Project
        /// </summary>
        public async Task<CreateProjectResponse> CreateProjectAsync(CreateProjectRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));
            if (request.Type == null) throw new ArgumentNullException("Value cannot be null.", nameof(request.Type));

            return await ExecuteAsync<CreateProjectResponse>(CreateRequest<CreateProjectRequest>(PROJECTS_PATH, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Projects / Create Project
        /// </summary>
        /// <param name="name">Project Name</param>
        /// <param name="type">Project Type</param>
        public async Task<CreateProjectResponse> CreateProjectAsync(string name, ProjectType type)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (type == null) throw new ArgumentNullException("Value cannot be null.", nameof(type));

            return await ExecuteAsync<CreateProjectResponse>(CreateRequest<CreateProjectRequest>(PROJECTS_PATH, new CreateProjectRequest() { Name = name, Type = type })).ConfigureAwait(false);
        }

        /// <summary>
        /// Projects / Retrieve Project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        public async Task<RetrieveProjectResponse> RetrieveProjectAsync(string projectId) 
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(projectId));
            
            return await ExecuteAsync<RetrieveProjectResponse>(Request(PROJECTS_PATH, projectId, HttpMethod.Get)).ConfigureAwait(false);
        }

        /// <summary>
        /// Projects / Update Project
        /// </summary>
        public async Task<UpdateProjectResponse> UpdateProjectAsync(UpdateProjectRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Id)) throw new ArgumentException("Value cannot be null.", nameof(request.Id));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));
            if (request.Type == null) throw new ArgumentNullException("Value cannot be null.", nameof(request.Type));

            return await ExecuteAsync<UpdateProjectResponse>(UpdateRequest<UpdateProjectRequest>(PROJECTS_PATH, request.Id, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Projects / Update Project
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="name">Project Name</param>
        /// <param name="type">Project Type</param>
        public async Task<UpdateProjectResponse> UpdateProjectAsync(string projectId, string name, ProjectType type)
        {
           if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));
           if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
           if (type == null) throw new ArgumentNullException("Value cannot be null.", nameof(type));

            return await ExecuteAsync<UpdateProjectResponse>(UpdateRequest<UpdateProjectRequest>(PROJECTS_PATH, projectId, new UpdateProjectRequest() { Id = projectId, Name = name, Type = type })).ConfigureAwait(false);
        }
 
        /// <summary>
        /// Projects / Delete Project
        /// </summary>
        public async Task<bool> DeleteProjectAsync(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));
            var result = await ExecuteAsync(Request(PROJECTS_PATH, projectId, HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }

        /// <summary>
        /// Projects / Set Project Budget
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="type">Budget Type</param>
        /// <param name="budget">Budget value in cents (for money) or seconds (for time)</param>
        public async Task<SetProjectBudgetResponse> SetProjectBudgetAsync(string projectId, BudgetType type, int budget)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));
            if (budget < 0) throw new ArgumentOutOfRangeException("Non-negative number required.", nameof(budget));
            if (type == null) throw new ArgumentNullException("Value cannot be null or empty.", nameof(type));

            return await ExecuteAsync<SetProjectBudgetResponse>(UpdateRequest<SetProjectBudgetRequest>(PROJECTS_PATH, projectId, "budget", new SetProjectBudgetRequest() { Id = projectId, Type = type, Budget = budget })).ConfigureAwait(false);
        }
 
        /// <summary>
        /// Projects / Delete Project Budget
        /// </summary>
        /// <param name="projectId">Project ID</param>
        public async Task<bool> DeleteProjectBudgetAsync(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));
            var result = await ExecuteAsync(Request(PROJECTS_PATH, projectId, "budget", HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }
 
        /// <summary>
        /// Projects / Set Project Billing
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="type">Budget Type</param>
        public async Task<SetProjectBillingResponse> SetProjectBillingAsync(string projectId, BillingType type)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));
            if (type == null) throw new ArgumentNullException("Value cannot be null or empty.", nameof(type));

            return await ExecuteAsync<SetProjectBillingResponse>(UpdateRequest<SetProjectBillingRequest>(PROJECTS_PATH, projectId, "billing", new SetProjectBillingRequest() { Id = projectId, Type = type })).ConfigureAwait(false);
        }

        /// <summary>
        /// Projects / Set Project Billing
        /// </summary>
        public async Task<SetProjectBillingResponse> SetProjectBillingAsync(SetProjectBillingRequest request)
        {
            if (request == null) throw new ArgumentException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Id)) throw new ArgumentException("Value cannot be null.", nameof(request.Id));
            if (request.Type == null) throw new ArgumentNullException("Value cannot be null or empty.", nameof(request.Type));

            return await ExecuteAsync<SetProjectBillingResponse>(UpdateRequest<SetProjectBillingRequest>(PROJECTS_PATH, request.Id, "billing", request)).ConfigureAwait(false);
        }
 
        /// <summary>
        /// Projects / Delete Project Billing
        /// <param name="projectId">Project ID</param>
        /// </summary>
        public async Task<bool> DeleteProjectBillingAsync(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null.", nameof(projectId));

            var result = await ExecuteAsync(Request(PROJECTS_PATH, projectId, "billing", HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }

    }
}