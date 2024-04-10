namespace Silicon.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Subscribers { get; set; }
        public string? Followers { get; set; }
        public string Image { get; set; } = null!;
    }
}
