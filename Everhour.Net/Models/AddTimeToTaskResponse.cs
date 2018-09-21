using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class AddTimeToTaskResponse: EverhourResponse<AddTimeToTaskResponse>
    {
        public TimeRecord TimeRecord { get; set; }
        
        public override AddTimeToTaskResponse FromJson(string json) => 
            new AddTimeToTaskResponse {
                TimeRecord = JsonConvert.DeserializeObject<TimeRecord>(json)
            };
    }
}