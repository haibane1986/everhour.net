using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class RetrieveClientResponse: EverhourResponse<RetrieveClientResponse>
    {
        public Client Client { get; set; }
        
        public override RetrieveClientResponse FromJson(string json) => 
            new RetrieveClientResponse() {
                Client = JsonConvert.DeserializeObject<Client>(json)
            };
    }
}