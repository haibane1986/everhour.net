using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class SetProjectBudgetRequest: EverhourRequest
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }
        
        /// <summary>
        /// Budget Type
        /// <example>
        /// moneny or time
        /// </example>
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(EnumerationConverter<BudgetType>))]
        public BudgetType Type { get; set; }

        /// <summary>
        /// Budget value in cents (for money) or seconds (for time)
        /// <example>
        /// 100000
        /// </example>
        /// </summary>
        [JsonProperty("budget", Required = Required.Always)]
        public int Budget { get; set; }
    }
}