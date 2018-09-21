
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class StopTimerResponse: EverhourResponse<StopTimerResponse>
    {
        public Timer Timer { get; set; }
        
        public override StopTimerResponse FromJson(string json) => 
            new StopTimerResponse() {
                Timer = JsonConvert.DeserializeObject<Timer>(json)
            };
    }
}