using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateClientRequest: EverhourRequest
    {
        /// <summary>
        /// Client ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

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