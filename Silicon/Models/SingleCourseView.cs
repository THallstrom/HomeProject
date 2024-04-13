namespace Silicon.Models
{
    public class SingleCourseView
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string OriginalPrice { get; set; } = null!;
        public string? DiscountPrice { get; set; }
        public int Hours { get; set; }
        public string? LikesInProcent { get; set; }
        public string? NumbersOfLikes { get; set; }
        public bool IsDigital { get; set; }
        public bool IsBestSeller { get; set; }
        public string? ImageUrl { get; set; }
        public string? BigImageUrl { get; set; }
        public string Category { get; set; } = null!;
        public string? Teacher { get; set; }
        public int? TeacherID { get; set; }
        public string? Review { get; set; }
        public string? Articles { get; set; }
        public string? Downloads { get; set; }
    }
}
