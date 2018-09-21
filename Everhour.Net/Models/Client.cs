using System.Collections.Generic;

namespace Everhour.Net.Models
{
    public class Client
    {
        /// <summary>
        /// Identifier of the user.
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
    }
}