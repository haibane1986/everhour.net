using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateProjectRequest: EverhourRequest
    {
        /// <summary>
        /// Project Name.
        /// <example>
        /// Project Name
        /// </example>
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Project Type.
        /// <example>
        /// board or list
        /// </example>
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(EnumerationConverter<ProjectType>))]
        public ProjectType Type { get; set; }

        /// <summary>
        /// Project Name.
        /// <example>
        /// Project Name
        /// </example>
        /// </summary>
        [JsonProperty("users")]
        public IList<int> Users { get; set; }
    }
}