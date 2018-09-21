using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string USERS_ME_PATH = "users/me";
        private const string TEAM_USERS_PATH = "team/users";
        
        /// <summary>
        /// Users / Your Profile
        /// </summary>
        public async Task<MeResponse> MeAsync() => await ExecuteAsync<MeResponse>(Request(USERS_ME_PATH)).ConfigureAwait(false);

        /// <summary>
        /// Users / List Team Users
        /// </summary>
        public async Task<ListTeamUsersResponse> ListTeamUsersAsync() => await ExecuteAsync<ListTeamUsersResponse>(Request(TEAM_USERS_PATH)).ConfigureAwait(false);
    }
}