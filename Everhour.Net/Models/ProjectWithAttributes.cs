using System.Collections.Generic;
using Newtonsoft.Json;

namespace Everhour.Net.Models
{
    public class ProjectWithAttributes: Project
    {
        private string WorkspaceName { set { Workspace = value; } }

        /// <summary>
        /// <example>
        /// as:9876543219
        /// </example>
        /// </summary>
        public string WorkspaceId { get; set; }

        /// <summary>
        /// Project Type
        /// <example>
        /// boad or list
        /// </example>
        /// </summary>
        [JsonConverter(typeof(EnumerationConverter<ProjectType>))]
        public ProjectType Type { get; set; }

        /// <summary>   
        /// <example>
        /// false
        /// </example>
        /// </summary>
        public bool Favorite { get; set; }

        /// <summary>
        /// List of assigned user IDs.
        /// </summary>
        public List<int> Users { get; set; }

        /// <summary>
        /// Project Budget.
        /// </summary>
        public Budget Budget { get; set; }

        /// <summary>
        /// Project Billing.
        /// </summary>
        public Billing Billing { get; set; }
    }
}