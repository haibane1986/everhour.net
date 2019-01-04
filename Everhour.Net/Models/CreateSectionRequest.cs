using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class CreateSectionRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// <example>
        /// Project ID
        /// </example>
        /// </summary>
        [JsonProperty("project_id", Required = Required.Always)]
        public string ProjectId { get; set; }

        /// <summary>
        /// Section Name.
        /// <example>
        /// Section Name
        /// </example>
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// <example>
        /// 1
        /// </example>
        /// </summary>
        [JsonProperty("position")]
        public int? Position { get; set; }

        /// <summary>
        /// <example>
        /// open or archived
        /// </example>
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(EnumerationConverter<SectionStatus>))]
        public SectionStatus Status { get; set; }
    }
}