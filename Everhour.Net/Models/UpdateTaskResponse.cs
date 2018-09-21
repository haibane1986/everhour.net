using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateTaskResponse: EverhourResponse<UpdateTaskResponse>
    {
        public Task Task { get; set; }
        
        public override UpdateTaskResponse FromJson(string json) => 
            new UpdateTaskResponse() {
                Task = JsonConvert.DeserializeObject<Task>(json)
            };
    }
}