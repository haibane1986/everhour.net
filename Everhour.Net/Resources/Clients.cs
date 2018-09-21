using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string CLIENTS_PATH = "clients";

        /// <summary>
        /// Clients / List All Clients
        /// </summary>
        public async Task<ListAllClientsResponse> ListAllClientsAsync() => await ExecuteAsync<ListAllClientsResponse>(ListRequest(CLIENTS_PATH)).ConfigureAwait(false);

        /// <summary>
        /// Clients / Create Client
        /// </summary>
        public async Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request){
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));

            return await ExecuteAsync<CreateClientResponse>(CreateRequest<CreateClientRequest>(CLIENTS_PATH, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Clients / Create Client
        /// </summary>
        /// <param name="name">Client Name</param>
        public async Task<CreateClientResponse> CreateClientAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            return await ExecuteAsync<CreateClientResponse>(CreateRequest<CreateClientRequest>(CLIENTS_PATH, new CreateClientRequest() { Name = name })).ConfigureAwait(false);
        }

        /// <summary>
        /// Clients / Retrieve Client
        /// </summary>
        /// <param name="clientId">Client ID</param>
        public async Task<RetrieveClientResponse> RetrieveClientAsync(int clientId)
        {
            if (clientId <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(clientId));

            return await ExecuteAsync<RetrieveClientResponse>(Request(CLIENTS_PATH, clientId, HttpMethod.Get)).ConfigureAwait(false);
        }

        /// <summary>
        /// Clients / Update Client
        /// </summary>
        /// <param name="clientId">Client ID</param>
        public async Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));

            return await ExecuteAsync<UpdateClientResponse>(UpdateRequest<UpdateClientRequest>(CLIENTS_PATH, request.Id, request)).ConfigureAwait(false);
        }

        /// <summary>
        /// Clients / Update Client
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="name">Client Name</param>
        public async Task<UpdateClientResponse> UpdateClientAsync(int clientId, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            return await ExecuteAsync<UpdateClientResponse>(UpdateRequest<UpdateClientRequest>(CLIENTS_PATH, clientId, new UpdateClientRequest() { Id = clientId, Name = name })).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Clients / Set Client Budget
        /// </summary>
        /// <param name="clientId">Client ID</param>
        /// <param name="type">Budget Type</param>
        /// <param name="budget">Budget value in cents (for money) or seconds (for time)</param>
        public async Task<SetClientBudgetResponse> SetClientBudgetAsync(int clientId, BudgetType type, int budget)
        {
            if (budget < 0) throw new ArgumentOutOfRangeException("Non-negative number required.", nameof(budget));
            if (type == null) throw new ArgumentNullException("Value cannot be null or empty.", nameof(type));

            return await ExecuteAsync<SetClientBudgetResponse>(UpdateRequest<SetClientBudgetRequest>(CLIENTS_PATH, clientId, "budget", new SetClientBudgetRequest() { Id = clientId, Type = type, Budget = budget })).ConfigureAwait(false);
        }

        /// <summary>
        /// Clients / Delete Client Budget
        /// </summary>
        /// <param name="clientId">Client ID</param>
        public async Task<bool> DeleteClientBudgetAsync(int clientId)
        {
            var result = await ExecuteAsync(Request(CLIENTS_PATH, clientId, "budget", HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }
    }
}