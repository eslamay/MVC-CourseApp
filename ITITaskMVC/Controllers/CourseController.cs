using ITITaskMVC.Data;
using ITITaskMVC.Models;
using ITITaskMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITITaskMVC.Controllers
{
	public class CourseController : Controller
	{
		
		public IActionResult Index(CategoryCourse? category)
		{
			var courses = CourseData.Courses.AsQueryable();

			if (category.HasValue)
			{
				courses = courses.Where(c => c.Category == category.Value);
			}

			ViewBag.SelectedCategory = category;
			ViewBag.Categories = Enum.GetValues(typeof(CategoryCourse)).Cast<CategoryCourse>();


			return View(courses.ToList());
		}

		public IActionResult GetById(Guid id)
		{
			var course = CourseData.Courses.FirstOrDefault(c => c.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			var courseVM = new CourseVM
			{
				Name = course.Name,
				Description = course.Description,
				Category = course.Category,
				startDate = course.startDate,
				endDate = course.endDate
			};

			return View("Details", courseVM);
		}
	}
}
