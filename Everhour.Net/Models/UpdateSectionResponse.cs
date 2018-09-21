using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateSectionResponse: EverhourResponse<UpdateSectionResponse>
    {
        public Section Section { get; set; }
        
        public override UpdateSectionResponse FromJson(string json) => 
            new UpdateSectionResponse() {
                Section = JsonConvert.DeserializeObject<Section>(json)
            };
    }
}