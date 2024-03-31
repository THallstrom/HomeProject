using Infrastructure.Context;
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

        public ActionResult Courses()
        {
            var viewModel = new CoursesViewModel();

            List<Infrastructure.Entities.CourseEntity> courseEntities = [.. _dataContext.Courses]; // Hämta alla kurser från databasen
            List<Infrastructure.Entities.CategoryEntity> categoryEntities = [.. _dataContext.Categories];

            if (courseEntities != null && courseEntities.Count != 0)
            {
                var cat = categoryEntities.Select(categoryEntities => new Category
                {
                    CategoryName = categoryEntities.CategoryName
                });

                viewModel.Categories = cat;
                

                var courseViewModels = courseEntities.Select(courseEntity => new Course
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

                viewModel.Courses = courseViewModels;

                return View(viewModel);
            }
            else
            {
                return View(new List<CourseViewModel>()); // Om det inte finns några kurser, skicka en tom lista till vyn
            }
        }

    }
}
