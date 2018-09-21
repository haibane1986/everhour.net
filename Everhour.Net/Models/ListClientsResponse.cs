using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListAllClientsResponse: EverhourResponse<ListAllClientsResponse>
    {
        public List<Client> Clients { get; set; }
        
        public override ListAllClientsResponse FromJson(string json) => 
            new ListAllClientsResponse() {
                Clients = JsonConvert.DeserializeObject<List<Client>>(json)
            };
    }
}