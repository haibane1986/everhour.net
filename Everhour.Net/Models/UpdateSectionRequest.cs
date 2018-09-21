using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class UpdateSectionRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// Project Name.
        /// <example>
        /// Project Name
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
        public int Position { get; set; }

        /// <summary>
        /// <example>
        /// open or archived
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<SectionStatus>))]
        public SectionStatus Status { get; set; }
    }
}