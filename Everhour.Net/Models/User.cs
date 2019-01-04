using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models {
    public class User {
        /// <summary>
        /// Identifier of the user.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        [JsonProperty ("id", Required = Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// <example>
        /// Chris Wonder
        /// </example>
        /// </summary>
        public string Name { get; set; }

        public string Headline { get; set; }

        public string AvatarUrl { get; set; }

        [JsonConverter (typeof (EnumerationConverter<RoleType>))]
        public RoleType Role { get; set; }

        [JsonConverter (typeof (EnumerationConverter<UserStatus>))]
        public UserStatus Status { get; set; }

        public string Email { get; set; }

        public List<Group> Groups { get; set; }

        public bool? AccessToResourcePlanner { get; set; }

        public int? Rate { get; set; }

        public int? Cost { get; set; }

        public Budget Budget { get; set; }

        public bool? EnableResourcePlanner { get; set; }

        public int? Capacity { get; set; }
    }
}