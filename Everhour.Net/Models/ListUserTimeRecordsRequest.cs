namespace Everhour.Net.Models
{
    public class ListUserTimeRecordsRequest: EverhourRequest
    {
        /// <summary>
        /// User ID.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Max results.
        /// <example>
        /// 100
        /// </example>
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Results offset.
        /// <example>
        /// 0
        /// </example>
        /// </summary>
        public int? Offset { get; set; }
    }
}