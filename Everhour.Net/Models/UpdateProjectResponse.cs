using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateProjectResponse: EverhourResponse<UpdateProjectResponse>
    {
        public ProjectWithAttributes Project { get; set; }
        
        public override UpdateProjectResponse FromJson(string json) => 
            new UpdateProjectResponse() {
                Project = JsonConvert.DeserializeObject<ProjectWithAttributes>(json)
            };
    }
}