using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class StartTimerResponse: EverhourResponse<StartTimerResponse>
    {
        public Timer Timer { get; set; }
        
        public override StartTimerResponse FromJson(string json) => 
            new StartTimerResponse() {
                Timer = JsonConvert.DeserializeObject<Timer>(json)
            };
    }
}