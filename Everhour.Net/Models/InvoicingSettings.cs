namespace Everhour.Net.Models {
    public class InvoicingSettings {
        public int InvoiceTimeRounding { get; set; }
        public string InvoiceTimeRoundingDirection { get; set; }
        public int InvoiceTimeFormat { get; set; }
        public string Currency { get; set; }
        public string BusinessDetails { get; set; }
        public string InvoicePageSize { get; set; }
    }
}