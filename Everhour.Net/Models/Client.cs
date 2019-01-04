using System;
using System.Collections.Generic;

namespace Everhour.Net.Models {
    public class Client {
        /// <summary>
        /// Identifier of the client.
        /// <example>
        /// 4567
        /// </example>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// <example>
        /// Client Name.
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <example>
        /// ev:1234567890
        /// </example>
        /// </summary>
        public List<string> Projects { get; set; }
        public string BusinessDetails { get; set; }

        /// <summary>
        /// Client Budget.
        /// </summary>
        public Budget Budget { get; set; }

        public DefaultTax DefaultTax { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string LineItemMask { get; set; }

        public int? DefaultDiscount { get; set; }

        public int? PaymentDueDays { get; set; }

        public string Reference { get; set; }

        public string InvoicePublicNotes { get; set; }

        public List<object> ExcludedLabels { get; set; }

        public string Status { get; set; }

        public bool Favorite { get; set; }
    }
}