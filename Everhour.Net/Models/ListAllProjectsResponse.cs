using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListAllProjectsResponse: EverhourResponse<ListAllProjectsResponse>
    {
        public List<ProjectWithAttributes> Projects { get; set; }
        
        public override ListAllProjectsResponse FromJson(string json) => 
            new ListAllProjectsResponse() {
                Projects = JsonConvert.DeserializeObject<List<ProjectWithAttributes>>(json)
            };
    }
}