using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class DeleteTimeInTaskResponse: EverhourResponse<DeleteTimeInTaskResponse>
    {
        public TimeRecord TimeRecord { get; set; }
        
        public override DeleteTimeInTaskResponse FromJson(string json) => 
            new DeleteTimeInTaskResponse() {
                TimeRecord = JsonConvert.DeserializeObject<TimeRecord>(json)
            };
    }
}