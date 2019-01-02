using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string TASKS_PATH = "tasks";

        /// <summary>
        /// Tasks / List Project Tasks
        /// </summary>
        /// <param name="projectId">Project ID</param>
        public async Task<ListTasksResponse> ListProjectTasksAsync(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(projectId));

            return await ExecuteAsync<ListTasksResponse>(Request(PROJECTS_PATH, projectId, TASKS_PATH, HttpMethod.Get)).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Create Task
        /// </summary>
        public async Task<CreateTaskResponse> CreateTaskAsync(CreateTaskRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.ProjectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.ProjectId));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));
            if (request.Status == null) throw new ArgumentNullException("Value cannot be null.", nameof(request.Status));
            if (request.Position <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Position));
            if (request.DueAt == DateTime.MinValue) throw new ArgumentException("Value cannot unspecified.", nameof(request.DueAt));
            if (request.Section <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Section));

            return await ExecuteAsync<CreateTaskResponse>(CreateRequest<CreateTaskRequest>(PROJECTS_PATH, request.ProjectId, TASKS_PATH, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Create Task
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="name">Task Name</param>
        /// <param name="section">Section ID</param>
        public async Task<CreateTaskResponse> CreateTaskAsync(string projectId, string name, int section)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(projectId));
            if (section <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(section));

            return await ExecuteAsync<CreateTaskResponse>(CreateRequest<CreateTaskRequest>(PROJECTS_PATH, projectId, TASKS_PATH, new CreateTaskRequest() { ProjectId = projectId, Name = name, Section = section })).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Retrieve Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<RetrieveTaskResponse> RetrieveTaskAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));

            return await ExecuteAsync<RetrieveTaskResponse>(Request(TASKS_PATH, taskId, HttpMethod.Get)).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Update Task
        /// </summary>
        public async Task<UpdateTaskResponse> UpdateTaskAsync(UpdateTaskRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Id)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Id));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));

            return await ExecuteAsync<UpdateTaskResponse>(UpdateRequest<UpdateTaskRequest>(TASKS_PATH, request.Id, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Update Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="name">Task Name</param>
        /// <param name="section">Section ID</param>
        public async Task<UpdateTaskResponse> UpdateTaskAsync(string taskId, string name, int section)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            return await ExecuteAsync<UpdateTaskResponse>(UpdateRequest<UpdateTaskRequest>(TASKS_PATH, taskId, new UpdateTaskRequest() { Id = taskId, Name = name, Section = section })).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Delete Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<bool> DeleteTaskAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));

            var result = await ExecuteAsync(Request(TASKS_PATH, taskId, HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }

        /// <summary>
        /// Tasks / Set Task Estimate
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="total">Total task estimate in seconds</param>
        public async Task<SetTaskEstimateResponse> SetTaskEstimateAsyncByOverAll(string taskId, int total)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null.", nameof(taskId));
            if (total < 0)  throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(total));

            return await ExecuteAsync<SetTaskEstimateResponse>(UpdateRequest<SetTaskEstimateRequest>(TASKS_PATH, taskId, "estimate", new SetTaskEstimateRequest() { Id = taskId, Type = EstimateType.OVERALL, Total = total })).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Set Task Estimate
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="users">Task estimate for user ID in seconds</param>
        public async Task<SetTaskEstimateResponse> SetTaskEstimateAsyncByUsers(string taskId, IList<UserWithTaskEstimate> users)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null.", nameof(taskId));
            if (users == null) throw new ArgumentNullException("Value cannot be null or empty.", nameof(users));
            if (users.Count == 0) throw new ArgumentException("Value cannot be empty.", nameof(users));

            return await ExecuteAsync<SetTaskEstimateResponse>(UpdateRequest<SetTaskEstimateRequest>(TASKS_PATH, taskId, "estimate", new SetTaskEstimateRequest() { Id = taskId, Type = EstimateType.USERS, Users = users })).ConfigureAwait(false);
        }

        /// <summary>
        /// Tasks / Delete Task Estimate
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<bool> DeleteTaskEstimateAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null.", nameof(taskId));

            var result = await ExecuteAsync(Request(TASKS_PATH, taskId, "estimate", HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }
    }
}