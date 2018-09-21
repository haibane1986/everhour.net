using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ListProjectSectionsResponse: EverhourResponse<ListProjectSectionsResponse>
    {
        public List<Section> Sections { get; set; }
        
        public override ListProjectSectionsResponse FromJson(string json) => 
            new ListProjectSectionsResponse() {
                Sections = JsonConvert.DeserializeObject<List<Section>>(json)
            };
    }
}