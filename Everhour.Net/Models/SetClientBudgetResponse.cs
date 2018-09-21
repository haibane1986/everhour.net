using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetClientBudgetResponse: EverhourResponse<SetClientBudgetResponse>
    {
        public Client Client { get; set; }
        
        public override SetClientBudgetResponse FromJson(string json) => 
            new SetClientBudgetResponse() {
                Client = JsonConvert.DeserializeObject<Client>(json)
            };
    }
}