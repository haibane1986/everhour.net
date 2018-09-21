using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ErrorResponse
    {
        /// <summary>
        /// HTTP Status Code.
        /// <example>
        /// 403
        /// </example>
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error Message.
        /// <example>
        /// Access denied
        /// </example>
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}