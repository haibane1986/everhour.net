
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateClientResponse: EverhourResponse<CreateClientResponse>
    {
        public Client Client { get; set; }
        
        public override CreateClientResponse FromJson(string json) => 
            new CreateClientResponse() {
                Client = JsonConvert.DeserializeObject<Client>(json)
            };
    }
}