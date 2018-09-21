using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class RetrieveTaskResponse: EverhourResponse<RetrieveTaskResponse>
    {
        public Task Task { get; set; }
        
        public override RetrieveTaskResponse FromJson(string json) => 
            new RetrieveTaskResponse() {
                Task = JsonConvert.DeserializeObject<Task>(json)
            };
    }
}