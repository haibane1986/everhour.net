using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ExportAllTeamTimeResponse : EverhourResponse<ExportAllTeamTimeResponse> {
        public List<TeamTime> TeamTimes { get; set; }
        
        public override ExportAllTeamTimeResponse FromJson(string json) => 
            new ExportAllTeamTimeResponse() {
                TeamTimes = JsonConvert.DeserializeObject<List<TeamTime>>(json)
            };
    }
}