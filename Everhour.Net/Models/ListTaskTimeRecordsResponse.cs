using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListTaskTimeRecordsResponse: EverhourResponse<ListTaskTimeRecordsResponse>
    {
        public List<TimeRecord> TimeRecords { get; set; }
        
        public override ListTaskTimeRecordsResponse FromJson(string json) => 
            new ListTaskTimeRecordsResponse() {
                TimeRecords = JsonConvert.DeserializeObject<List<TimeRecord>>(json)
            };
    }
}