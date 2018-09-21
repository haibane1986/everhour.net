using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListTasksResponse: EverhourResponse<ListTasksResponse>
    {
        public List<Task> Tasks { get; set; }
        
        public override ListTasksResponse FromJson(string json) => 
            new ListTasksResponse() {
                Tasks = JsonConvert.DeserializeObject<List<Task>>(json)
            };
    }
}