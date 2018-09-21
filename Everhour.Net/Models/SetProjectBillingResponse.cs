using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetProjectBillingResponse: EverhourResponse<SetProjectBillingResponse>
    {
        public ProjectWithAttributes Project { get; set; }
        
        public override SetProjectBillingResponse FromJson(string json) => 
            new SetProjectBillingResponse() {
                Project = JsonConvert.DeserializeObject<ProjectWithAttributes>(json)
            };
    }
}