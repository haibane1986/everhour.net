using System;

namespace Everhour.Net.Models {
    public class TeamBilling {
        public bool isTrialExtended { get; set; }
        public string Plan { get; set; }
        public string Status { get; set; }
        public DateTime TrialEndedAt { get; set; }
        public int Quantity { get; set; }
    }
}