using System;
using System.Collections.Generic;

namespace Everhour.Net.Models {
    public class Account {
        public int User { get; set; }
        public string Id { get; set; }
        public string Platform { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Shared { get; set; }
        public List<object> TaxRates { get; set; }
    }
}