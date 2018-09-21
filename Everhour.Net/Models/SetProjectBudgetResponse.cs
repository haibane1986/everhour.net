using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetProjectBudgetResponse: EverhourResponse<SetProjectBudgetResponse>
    {
        public ProjectWithAttributes Project { get; set; }
        
        public override SetProjectBudgetResponse FromJson(string json) => 
            new SetProjectBudgetResponse() {
                Project = JsonConvert.DeserializeObject<ProjectWithAttributes>(json)
            };
    }
}