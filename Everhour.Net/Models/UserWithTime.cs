namespace Everhour.Net.Models
{
    public class UserWithTime
    {
        /// <summary>
        /// Identifier of the user.
        /// <example>
        /// 1304
        /// </example>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Task time in seconds.
        /// <example>
        /// 3600
        /// </example>
        /// </summary>
        public int Time { get; set; }
    }
}