using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateProjectRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

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
        public List<int> Users { get; set; }
    }
}