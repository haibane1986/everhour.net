using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetTaskEstimateResponse: EverhourResponse<SetTaskEstimateResponse>
    {
        public Estimate Estimate { get; set; }
        
        public override SetTaskEstimateResponse FromJson(string json) => 
            new SetTaskEstimateResponse() {
                Estimate = JsonConvert.DeserializeObject<Estimate>(json)
            };
    }
}