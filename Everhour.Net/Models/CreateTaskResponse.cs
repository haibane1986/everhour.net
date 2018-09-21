using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateTaskResponse: EverhourResponse<CreateTaskResponse>
    {
        public Task Task { get; set; }
        
        public override CreateTaskResponse FromJson(string json) => 
            new CreateTaskResponse() {
                Task = JsonConvert.DeserializeObject<Task>(json)
            };
    }
}