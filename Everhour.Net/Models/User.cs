using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class User
    {
        /// <summary>
        /// Identifier of the user.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        [JsonProperty("id", Required=Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// <example>
        /// Chris Wonder
        /// </example>
        /// </summary>
        public string Name { get; set; }

        public string Headline { get; set; }

        public string AvatarUrl { get; set; }
        
        [JsonConverter(typeof(EnumerationConverter<RoleType>))]
        public RoleType Role { get; set; }

        [JsonConverter(typeof(EnumerationConverter<UserStatus>))]
        public UserStatus Status { get; set; }
    }
}