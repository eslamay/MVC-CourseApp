using ITITaskMVC.BLL.Pagination;
using ITITaskMVC.BLL.ViewModels.CourseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.BLL.Services.CourseServices
{
	public interface IcourseService
	{
		IEnumerable<CourseVM> GetAll();
		CourseVM? GetById(Guid id);
		PageResult<CourseVM> GetPage(int page, int pageSize,string? serachName = null);
		void Add(CreateCourseVM createCourseVM);
		bool Update(Guid id,CourseVM courseVM);
		bool Delete(Guid id);
		bool IsNameUnique(string name, Guid? excludeId = null);
	}
}
