﻿using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
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
    public string? Reviews { get; set; }
    public DateTime Created { get; set; }
    public DateTime LastUpdated { get; set; }
    public string? ImageUrl { get; set; }
    public string? BigImageUrl { get; set; }
    public int? CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }
    public int? TeacherId { get; set; }
    public TeacherEntity? Teacher { get; set; }
}
