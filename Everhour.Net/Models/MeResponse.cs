using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class MeResponse: EverhourResponse<MeResponse>
    {
        public Me Me { get; set; }

        public override MeResponse FromJson(string json) => 
            new MeResponse() {
                Me = JsonConvert.DeserializeObject<Me>(json)
            };
    }
}