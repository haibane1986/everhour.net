using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string USERS_PATH = "users";
        private const string TEAM_TIME_PATH = "team/time";

        /// <summary>
        /// Tasks / List Project Tasks
        /// </summary>
        /// <param name="taskId">Task ID</param>
        /// <param name="time">Time in seconds</param>
        /// <param name="date">Date</param>
        public async Task<AddTimeToTaskResponse> AddTimeToTaskAsync(string taskId, int time, DateTime date)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));
            if (time <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(time));

            return await ExecuteAsync<AddTimeToTaskResponse>(CreateRequest(TASKS_PATH, taskId, "time", new AddTimeToTaskRequest() { Time = time, Date = date})).ConfigureAwait(false);
        }

        /// <summary>
        /// Time Recording / Add Time To Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<AddTimeToTaskResponse> AddTimeToTaskAsync(AddTimeToTaskRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.TaskId)) throw new ArgumentNullException("Value cannot be null or empty.", nameof(request.TaskId));
            if (request.Time <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Time));
            if (request.User <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.User));

            return await ExecuteAsync<AddTimeToTaskResponse>(CreateRequest(TASKS_PATH, request.TaskId, "time", request)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / Update Time In Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<UpdateTimeInTaskResponse> UpdateTimeInTaskAsync(string taskId, int time, DateTime date)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));
            if (time <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(time));

            return await ExecuteAsync<UpdateTimeInTaskResponse>(UpdateRequest<UpdateTimeInTaskRequest>(TASKS_PATH, taskId, "time", new UpdateTimeInTaskRequest() { TaskId = taskId, Time = time, Date = date })).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / Update Time In Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<UpdateTimeInTaskResponse> UpdateTimeInTaskAsync(UpdateTimeInTaskRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.TaskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.TaskId));
            if (request.Time <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Time));

            return await ExecuteAsync<UpdateTimeInTaskResponse>(UpdateRequest<UpdateTimeInTaskRequest>(TASKS_PATH, request.TaskId, "time", request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Time Recording / Delete Time In Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<DeleteTimeInTaskResponse> DeleteTimeInTaskAsync(string taskId, DateTime date)
        {
            if (string.IsNullOrEmpty(taskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));

            return await ExecuteAsync<DeleteTimeInTaskResponse>(DeleteRequest<DeleteTimeInTaskRequest>(TASKS_PATH, taskId, "time", new DeleteTimeInTaskRequest() { TaskId = taskId, Date = date })).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / Delete Time In Task
        /// </summary>
        /// <param name="taskId">Task ID</param>
        public async Task<DeleteTimeInTaskResponse> DeleteTimeInTaskAsync(DeleteTimeInTaskRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.TaskId)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.TaskId));

            return await ExecuteAsync<DeleteTimeInTaskResponse>(DeleteRequest<DeleteTimeInTaskRequest>(TASKS_PATH, request.TaskId, "time", request)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / List User Time Records
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="limit">Max results</param>
        public async Task<ListUserTimeRecordsResponse> ListUserTimeRecordsAsync(int userId, int limit)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(userId));
            if (limit <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(limit));

            return await ExecuteAsync<ListUserTimeRecordsResponse>(Request(new UriBuilder() { Path = USERS_PATH, Query = new ListUserTimeRecordsRequest() { Limit = limit } .ToQuery() }.Uri.PathAndQuery, userId, "time", HttpMethod.Get)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / List User Time Records.
        /// </summary>
        public async Task<ListUserTimeRecordsResponse> ListUserTimeRecordsAsync(ListUserTimeRecordsRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));

            return await ExecuteAsync<ListUserTimeRecordsResponse>(Request(new UriBuilder() { Path = USERS_PATH, Query = request.ToQuery() }.Uri.PathAndQuery, request.UserId, "time", HttpMethod.Get)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / List Team Time Records
        /// </summary>
        public async Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync() =>  await ExecuteAsync<ListTeamTimeRecordsResponse>(ListRequest(TEAM_TIME_PATH)).ConfigureAwait(false);

        /// <summary>
        /// Time Recording / List Team Time Records
        /// </summary>
        /// <param name="date">Single date you want to fetch task time</param>
        public async Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync(DateTime date)
        {
            return await ExecuteAsync<ListTeamTimeRecordsResponse>(ListRequest(new UriBuilder() { Path = TEAM_TIME_PATH, Query = new ListTeamTimeRecordsRequest() { Date = date} .ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);
        }

        /// <summary>
        /// Time Recording / List Team Time Records
        /// </summary>
        /// <param name="from">Date from you want to fetch task time</param>
        /// <param name="to">Date to you want to fetch task time</param>
        public async Task<ListTeamTimeRecordsResponse> ListTeamTimeRecordsAsync(DateTime from, DateTime to)
        {
            if (from > to) throw new ArgumentException("`From` must be before `To`.", nameof(from));

            return await ExecuteAsync<ListTeamTimeRecordsResponse>(ListRequest(new UriBuilder() { Path = TEAM_TIME_PATH, Query = new ListTeamTimeRecordsRequest() { From = from, To = to} .ToQuery() }.Uri.PathAndQuery)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Time Recording / List Task Time Records
        /// </summary>
        public async Task<ListTaskTimeRecordsResponse> ListTaskTimeRecordsAsync(string taskId)
        {
            if (string.IsNullOrEmpty(taskId))  throw new ArgumentException("Value cannot be null or empty.", nameof(taskId));

            return await ExecuteAsync<ListTaskTimeRecordsResponse>(Request(TASKS_PATH, taskId, "time", HttpMethod.Get)).ConfigureAwait(false);
        }
    }
}