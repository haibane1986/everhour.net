using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateClientResponse: EverhourResponse<UpdateClientResponse>
    {
        public Client Client { get; set; }
        
        public override UpdateClientResponse FromJson(string json) => 
            new UpdateClientResponse() {
                Client = JsonConvert.DeserializeObject<Client>(json)
            };
    }
}