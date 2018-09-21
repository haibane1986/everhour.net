using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListTeamUsersTimersResponse: EverhourResponse<ListTeamUsersTimersResponse>
    {
        public IList<Timer> Timers { get; set; }
        
        public override ListTeamUsersTimersResponse FromJson(string json) => 
            new ListTeamUsersTimersResponse() {
                Timers = JsonConvert.DeserializeObject<IList<Timer>>(json)
            };
    }
}