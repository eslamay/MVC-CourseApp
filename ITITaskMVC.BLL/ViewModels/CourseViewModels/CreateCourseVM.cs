using ITITaskMVC.BLL.Validations;
using ITITaskMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.BLL.ViewModels.CourseViewModels
{
	public class CreateCourseVM
	{
		//[Remote(action: "CheckCourseName", controller: "Course")]
		[NoNumbers]
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public CategoryCourse Category { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }

		public bool IsActive { get; set; }
		public Guid? InstructorId { get; set; }

		public Instructor? Instructor { get; set; }
	}
}
