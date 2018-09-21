using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetTaskEstimateResponse: EverhourResponse<SetTaskEstimateResponse>
    {
        public Task Task { get; set; }
        
        public override SetTaskEstimateResponse FromJson(string json) => 
            new SetTaskEstimateResponse() {
                Task = JsonConvert.DeserializeObject<Task>(json)
            };
    }
}