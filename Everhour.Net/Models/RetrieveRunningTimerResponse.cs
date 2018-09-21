using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class RetrieveRunningTimerResponse: EverhourResponse<RetrieveRunningTimerResponse>
    {
        public Timer Timer { get; set; }
        
        public override RetrieveRunningTimerResponse FromJson(string json) => 
            new RetrieveRunningTimerResponse() {
                Timer = JsonConvert.DeserializeObject<Timer>(json)
            };
    }
}