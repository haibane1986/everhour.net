namespace Everhour.Net.Models
{
    public class TeamEstimate
    {
        public Time Time { get; set; }

        public Estimate Estimate { get; set; }

        /// <summary>
        /// Will appear only if 'project' passed to fields parameter.
        /// </summary>
        public Project Project { get; set; }

        public TeamTask Task { get; set; }
    }
}