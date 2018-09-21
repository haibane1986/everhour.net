using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateSectionResponse: EverhourResponse<CreateSectionResponse>
    {
        public Section Section { get; set; }
        
        public override CreateSectionResponse FromJson(string json) => 
            new CreateSectionResponse() {
                Section = JsonConvert.DeserializeObject<Section>(json)
            };
    }
}