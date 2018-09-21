using System;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class Section
    {
        /// <summary>
        /// <example>
        /// 1234
        /// </example>
        /// </summary>
        [JsonProperty("id", Required=Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// Section Name.
        /// <example>
        /// Section Name
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <example>
        /// ev:1234567890
        /// </example>
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// <example>
        /// 1
        /// </example>
        /// </summary>
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