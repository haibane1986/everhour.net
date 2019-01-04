namespace Everhour.Net.Models {
    public class Owner {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Headline { get; set; }
        public string AvatarUrl { get; set; }
        public bool EnableResourcePlanner { get; set; }
        public int Capacity { get; set; }
        public bool AccessToResourcePlanner { get; set; }
    }
}