using Infrastructure.Context;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;
using Silicon.Models;

namespace Silicon.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _dataContext;

        public CourseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ActionResult Courses(string catergory = "", int pageNumber = 1, int pageSize = 6)
        {
            var viewModel = new CoursesViewModel();

            List<Infrastructure.Entities.CourseEntity> courseEntities = [.. _dataContext.Courses]; // Hämta alla kurser från databasen
            List<Infrastructure.Entities.CategoryEntity> categoryEntities = [.. _dataContext.Categories];

            if (courseEntities != null && courseEntities.Count != 0)
            {
                if (!string.IsNullOrEmpty(catergory) && catergory != "all")
                {
                    var test = catergory;
                }
                var cat = categoryEntities.Select(categoryEntities => new Category
                {
                    CategoryName = categoryEntities.CategoryName
                });

                viewModel.Categories = cat;
                
                var course = courseEntities.Select(courseEntity => new Course
                {
                    Title = courseEntity.Title,
                    Author = courseEntity.Author,
                    OriginalPrice = courseEntity.OriginalPrice,
                    Hours = courseEntity.Hours,
                    ImageUrl = courseEntity.ImageUrl,
                    NumbersOfLikes = courseEntity.NumbersOfLikes,
                    LikesInProcent = courseEntity.LikesInProcent,
                    DiscountPrice = courseEntity.DiscountPrice,
                    IsDigital = courseEntity.IsDigital,
                    IsBestSeller = courseEntity.IsBestSeller,
                    // Lägg till andra egenskaper här om det behövs
                }).ToList();

                int totalItemCount = courseEntities.Count();
                var totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);

                viewModel.Paginering = new Paginering
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = totalPages,
                    TotalCount = totalItemCount,
                };

                var coursesForPage = course.Skip((pageNumber - 1) * pageSize)
                                            .Take(pageSize)
                                            .ToList();

                viewModel.Courses = coursesForPage;
                return View(viewModel);
            }
            else
            {
                return View(new List<CourseViewModel>()); // Om det inte finns några kurser, skicka en tom lista till vyn
            }
        }

    }
}
