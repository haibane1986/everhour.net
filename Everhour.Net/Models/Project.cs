namespace Everhour.Net.Models
{
    public class Project
    {
        /// <summary>
        /// <example>
        /// ev:9876543210
        /// </example>
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// <example>
        /// Project Name
        /// </example>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <example>
        /// Project Workspace Name
        /// </example>
        /// </summary>
        public string Workspace { get; set; }
    }
}