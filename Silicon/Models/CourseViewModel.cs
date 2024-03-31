namespace Silicon.Models;

public class CourseViewModel
{
    public string? ImgLink { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal Price { get; set; }
    public int Hours { get; set; }
    public bool Discount { get; set; }
    public decimal DiscountPrice { get; set; }
    public int Grade { get; set; }
    public decimal GradeBy { get; set; }
}

