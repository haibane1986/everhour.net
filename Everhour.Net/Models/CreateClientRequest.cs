using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateClientRequest: EverhourRequest
    {
        /// <summary>
        /// Client Name.
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("projects")]
        public IList<string> Projects { get; set; }

        [JsonProperty("businessDetails")]
        public string BusinessDetails { get; set; }
    }
}