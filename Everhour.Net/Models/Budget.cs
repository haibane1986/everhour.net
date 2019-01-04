using Newtonsoft.Json;

namespace Everhour.Net.Models {
    public class Budget {
        /// <summary>
        /// Budget value in cents (for money) or seconds (for time).
        /// <example>
        /// 100000
        /// </example>
        /// </summary>
        [JsonProperty ("budget")]
        public int Value { get; set; }

        /// <summary>
        /// Current budget usage in cents (for money) or seconds (for time).
        /// <example>
        /// 0
        /// </example>
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Budget Type.
        /// <example>
        /// moneny or time
        /// </example>
        /// </summary>
        [JsonConverter (typeof (EnumerationConverter<BudgetType>))]
        public BudgetType Type { get; set; }

        public bool? ExcludeUnbillableTime { get; set; }

        public bool? ExcludeExpenses { get; set; }

        public string Period { get; set; }

        public string AppliedFrom { get; set; }

        public bool? DisallowOverbudget { get; set; }

        public bool? ShowToUsers { get; set; }

        public int? Threshold { get; set; }

        public int? TimeProgress { get; set; }

        public int? ExpenseProgress { get; set; }
    }
}