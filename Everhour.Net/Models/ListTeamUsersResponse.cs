using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListTeamUsersResponse: EverhourResponse<ListTeamUsersResponse>
    {
        public List<User> Users { get; set; }
        
        public override ListTeamUsersResponse FromJson(string json) => 
            new ListTeamUsersResponse() {
                Users = JsonConvert.DeserializeObject<List<User>>(json)
            };
    }
}