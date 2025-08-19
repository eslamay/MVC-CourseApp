using ITITaskMVC.BLL.Services.CourseServices;
using ITITaskMVC.BLL.Services.InstructorService;
using ITITaskMVC.BLL.ViewModels.CourseViewModels;
using ITITaskMVC.Configurations;
using ITITaskMVC.DAL.Data;
using ITITaskMVC.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ITITaskMVC.Controllers
{
	public class CourseController : Controller
	{
		private readonly IcourseService courseService;
		private readonly IInstructorService instructorService;
		private readonly IOptionsMonitor<CourseSettings> options;

		public CourseController(IcourseService courseService, IInstructorService instructorService,
			IOptionsMonitor<CourseSettings> options
			)
		{
			this.courseService = courseService;
			this.instructorService = instructorService;
			this.options = options;
		}
		public IActionResult Index(int page=1,string? searchName=null)
		{
			int pageSize = options.CurrentValue.DefaultPageSize;
			//var courses =  courseService.GetAll();
			var courses = courseService.GetPage(page, pageSize, searchName);
			ViewBag.Categories = Enum.GetValues(typeof(CategoryCourse)).Cast<CategoryCourse>();
			ViewBag.SearchName = searchName;
			return View(courses);
		}

		public IActionResult GetById(Guid id)
		{
			var course = courseService.GetById(id);
			if (course == null)
				return NotFound();

			return View("Details", course);
		}

		[HttpGet]
		public IActionResult Create()
		{
			var instructors = instructorService.GetAllInstructors();
			ViewData["instructors"] = instructors;
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateCourseVM model)
		{
			if (ModelState.IsValid)
			{
				courseService.Add(model);
				return RedirectToAction(nameof(Index));
			}

			var instructors = instructorService.GetAllInstructors();
			ViewData["instructors"] = instructors;
			return View(model);
		}

		[HttpGet]
		public IActionResult Edit(Guid id)
		{
			var course = courseService.GetById(id);
			if (course == null)
				return NotFound();

			var instructors =	instructorService.GetAllInstructors();
			ViewData["instructors"] = instructors;

			return View(course);
		}

		[HttpPost]
		public IActionResult Edit(Guid id,CourseVM model)
		{
			if (id != model.Id)
				return BadRequest();

			if (ModelState.IsValid)
			{
				var updated = courseService.Update(id, model);
				if (!updated)
				{
					return View(model);
				}

				return RedirectToAction(nameof(Index));
			}

			var instructors = instructorService.GetAllInstructors();
			ViewData["instructors"] = instructors;

			return View(model);
		}

		[HttpPost]
		public IActionResult Delete(Guid id)
		{
			var deleted = courseService.Delete(id);
			if (!deleted)
			{
				return RedirectToAction(nameof(Index));
			}

			return RedirectToAction(nameof(Index));
		}

		public IActionResult CheckCourseName(string name)
		{
			var isUnique = courseService.IsNameUnique(name);
			if (!isUnique)
				return Json($"Course name '{name}' is already taken.");

			return Json(true);
		}
	}
}
