using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<MeResponse> MeAsync();
        Task<ListTeamUsersResponse> ListTeamUsersAsync();
    }
}