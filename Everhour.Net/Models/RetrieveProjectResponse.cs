using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class RetrieveProjectResponse: EverhourResponse<RetrieveProjectResponse>
    {
        public ProjectWithAttributes Project { get; set; }
        
        public override RetrieveProjectResponse FromJson(string json) => 
            new RetrieveProjectResponse() {
                Project = JsonConvert.DeserializeObject<ProjectWithAttributes>(json)
            };
    }
}