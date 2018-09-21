using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListTeamTimeRecordsResponse: EverhourResponse<ListTeamTimeRecordsResponse>
    {
        public List<TeamTimeRecord> TeamTimeRecords { get; set; }
        
        public override ListTeamTimeRecordsResponse FromJson(string json) => 
            new ListTeamTimeRecordsResponse() {
                TeamTimeRecords = JsonConvert.DeserializeObject<List<TeamTimeRecord>>(json)
            };
    }
}