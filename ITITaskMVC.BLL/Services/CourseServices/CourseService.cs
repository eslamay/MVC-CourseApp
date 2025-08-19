using ITITaskMVC.BLL.Pagination;
using ITITaskMVC.BLL.ViewModels.CourseViewModels;
using ITITaskMVC.DAL.Models;
using ITITaskMVC.DAL.Repositories.CourseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.BLL.Services.CourseServices
{
	public class CourseService : IcourseService
	{
		private readonly ICourseRepo courseRepo;

		public CourseService(ICourseRepo courseRepo)
		{
			this.courseRepo = courseRepo;
		}

		public IEnumerable<CourseVM> GetAll()
		{
			return courseRepo.GetAll()
			.Select(c => new CourseVM
			{
                Id = c.Id,
				Name = c.Name,
				Description = c.Description,
				startDate = c.startDate,
				endDate = c.endDate,
				Category = c.Category,
				Instructor = c.Instructor,
				 IsActive = c.IsActive
			}).ToList();
		}
		public CourseVM? GetById(Guid id)
		{
			var course = courseRepo.GetById(id);
			if (course == null) return null;

			return new CourseVM
			{
				Id = course.Id,
				Name = course.Name,
				Description = course.Description,
				startDate = course.startDate,
				endDate = course.endDate,
				Category = course.Category,
				InstructorId = course.InstructorId,
				IsActive = course.IsActive
			};
		}

		
		public void Add(CreateCourseVM createCourseVM)
		{
			var course = new course
			{
				Id = Guid.NewGuid(),
				Name = createCourseVM.Name,
				Description = createCourseVM.Description,
				startDate = createCourseVM.startDate,
				endDate = createCourseVM.endDate,
				Category = createCourseVM.Category,
				InstructorId = createCourseVM.InstructorId,
				IsActive = createCourseVM.IsActive
			};

			courseRepo.Add(course);
			courseRepo.Save();
		}

		
		public bool Update(Guid id, CourseVM courseVM)
		{
			var course = courseRepo.GetById(id);

			if (course == null) return false;

			course.Id = courseVM.Id;
			course.Name = courseVM.Name;
			course.Description = courseVM.Description;
			course.startDate = courseVM.startDate;
			course.endDate = courseVM.endDate;
			course.Category = courseVM.Category;
			course.InstructorId = courseVM.InstructorId;
			course.IsActive = courseVM.IsActive;

			courseRepo.Update(course);
			courseRepo.Save();

			return true;
		}

		public bool Delete(Guid id)
		{
			courseRepo.Delete(id);
			courseRepo.Save();

			return true;
		}
        public bool IsNameUnique(string name, Guid? excludeId = null)
		{
			return courseRepo.IsNameExists(name, excludeId);
		}

		public PageResult<CourseVM> GetPage(int page, int pageSize, string? serachName = null)
		{
			var items = courseRepo.GetPage(page, pageSize, serachName).Select(c => new CourseVM
			{
				Id = c.Id,
				Name = c.Name,
				Description = c.Description,
				startDate = c.startDate,
				endDate = c.endDate,
				Category = c.Category,
				Instructor = c.Instructor,
				IsActive = c.IsActive
			}).ToList();

			var totalCount = courseRepo.GetCount(serachName);

			return new PageResult<CourseVM>
			{
				Items = items,
				TotalCount = totalCount,
				Page = page,
				PageSize = pageSize
            };
		}
	}
}
