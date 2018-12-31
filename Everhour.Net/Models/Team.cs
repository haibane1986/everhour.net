using System;
using System.Collections.Generic;

namespace Everhour.Net.Models {
    public class Team {
        public List<string> Workdays { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LockTimePeriod { get; set; }
        public int LockTimeAfter { get; set; }
        public int BeginningOfWeek { get; set; }
        public Owner Owner { get; set; }
        public string CompanySize { get; set; }
        public string CurrentTool { get; set; }
        public string AcquisitionChannel { get; set; }
        public TeamBilling Billing { get; set; }
        public string WorkHoursFrom { get; set; }
        public string WorkHoursTo { get; set; }
        public bool TimerStopEnabled { get; set; }
        public bool AllowFutureTracking { get; set; }
        public int TimerStopAt { get; set; }
        public string AcquisitionVisitorId { get; set; }
        public string AcquisitionLanding { get; set; }
        public string AcquisitionReferer { get; set; }
        public string AcquisitionSource { get; set; }
        public CurrencyDetails CurrencyDetails { get; set; }
        public InvoicingSettings InvoicingSettings { get; set; }
    }
}