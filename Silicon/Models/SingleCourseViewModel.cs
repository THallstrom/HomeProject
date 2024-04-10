using Infrastructure.Migrations;

namespace Silicon.Models
{
    public class SingleCourseViewModel
    {
        public SingleCourseView SingleCourseView { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
    }
}
