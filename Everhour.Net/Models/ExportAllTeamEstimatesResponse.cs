using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models {
    public class ExportAllTeamEstimatesResponse : EverhourResponse<ExportAllTeamEstimatesResponse> 
    {
        public List<TeamEstimate> TeamEstimates { get; set; }
        
        public override ExportAllTeamEstimatesResponse FromJson(string json) => 
            new ExportAllTeamEstimatesResponse() {
                TeamEstimates = JsonConvert.DeserializeObject<List<TeamEstimate>>(json)
            };
    }
}