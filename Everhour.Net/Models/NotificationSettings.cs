namespace Everhour.Net.Models {
    public class NotificationSettings {
        public bool MemberWaitingApproval { get; set; }
        public bool MemberAccepted { get; set; }
        public bool MemberRemoved { get; set; }
        public bool MemberRejected { get; set; }
        public bool EngagementOnboarding { get; set; }
        public bool EngagementUpdates { get; set; }
        public bool EngagementFeedback { get; set; }
        public bool EngagementMarketing { get; set; }
        public bool SummaryDaily { get; set; }
        public bool SummaryWeekly { get; set; }
        public bool SummaryMonthly { get; set; }
        public bool MissedTimerEmail { get; set; }
        public bool MissedTimerPush { get; set; }
        public bool NotifyMissedTimerAt { get; set; }
        public bool ForgottenTimerEmail { get; set; }
        public bool ForgottenTimerPush { get; set; }
        public bool NotifyForgottenTimerAfter { get; set; }
    }
}