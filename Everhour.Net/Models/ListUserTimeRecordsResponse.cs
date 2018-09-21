using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListUserTimeRecordsResponse: EverhourResponse<ListUserTimeRecordsResponse>
    {
        public List<TimeRecord> TimeRecords { get; set; }
        
        public override ListUserTimeRecordsResponse FromJson(string json) => 
            new ListUserTimeRecordsResponse() {
                TimeRecords = JsonConvert.DeserializeObject<List<TimeRecord>>(json)
            };
    }
}