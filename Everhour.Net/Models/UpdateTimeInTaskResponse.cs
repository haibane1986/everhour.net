using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateTimeInTaskResponse: EverhourResponse<UpdateTimeInTaskResponse>
    {
        public TimeRecord TimeRecord { get; set; }
        
        public override UpdateTimeInTaskResponse FromJson(string json) => 
            new UpdateTimeInTaskResponse() {
                TimeRecord = JsonConvert.DeserializeObject<TimeRecord>(json)
            };
    }
}