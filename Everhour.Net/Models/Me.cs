using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models {
    public class Me {
        public NotificationSettings NotificationSettings { get; set; }
        public bool IsSuspended { get; set; }
        public bool HasPassword { get; set; }
        public bool HasEmailChangeRequestPending { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Headline { get; set; }
        public string AvatarUrl { get; set; }
        public bool NewsSubscribed { get; set; }
        public string InstallStep { get; set; }
        public string SignupType { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PrivacyAcceptedAt { get; set; }
        public string ApiKey { get; set; }
        public Team Team { get; set; }
        public List<Group> Groups { get; set; }
        public List<Account> Accounts { get; set; }
        [JsonConverter(typeof(EnumerationConverter<RoleType>))]
        public RoleType Role { get; set; }

        [JsonConverter(typeof(EnumerationConverter<UserStatus>))]
        public UserStatus Status { get; set; }
        public int DateFormat { get; set; }
        public int TimeFormat { get; set; }
        public int ExportTimeFormat { get; set; }
        public int ExportCsvSeparator { get; set; }
        public int TimeRounding { get; set; }
        public string StartPage { get; set; }
        public string ActivityMode { get; set; }
        public DateTime ExtensionUsedAt { get; set; }
        public bool WelcomeSeen { get; set; }
        public bool AccessToResourcePlanner { get; set; }
        public int Timezone { get; set; }
        public bool EnableResourcePlanner { get; set; }
        public int Capacity { get; set; }
    }
}