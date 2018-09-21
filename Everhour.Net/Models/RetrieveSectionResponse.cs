using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class RetrieveSectionResponse: EverhourResponse<RetrieveSectionResponse>
    {
        public Section Section { get; set; }
        
        public override RetrieveSectionResponse FromJson(string json) => 
            new RetrieveSectionResponse() {
                Section = JsonConvert.DeserializeObject<Section>(json)
            };
    }
}