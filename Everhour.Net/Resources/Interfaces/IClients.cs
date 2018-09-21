using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ListAllClientsResponse> ListAllClientsAsync();
        Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request);
        Task<CreateClientResponse> CreateClientAsync(string name);
        Task<RetrieveClientResponse> RetrieveClientAsync(int clientId);
        Task<UpdateClientResponse> UpdateClientAsync(UpdateClientRequest request);
        Task<UpdateClientResponse> UpdateClientAsync(int clientId, string name);
        Task<SetClientBudgetResponse> SetClientBudgetAsync(int clientId, BudgetType type, int budget);
        Task<bool> DeleteClientBudgetAsync(int clientId);
    }
}