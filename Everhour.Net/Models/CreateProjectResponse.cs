using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateProjectResponse: EverhourResponse<CreateProjectResponse>
    {
        public ProjectWithAttributes Project { get; set; }
        
        public override CreateProjectResponse FromJson(string json) => 
            new CreateProjectResponse() {
                Project = JsonConvert.DeserializeObject<ProjectWithAttributes>(json)
            };
    }
}