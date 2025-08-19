using ITITaskMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Repositories.CourseRepository
{
	public interface ICourseRepo
	{
		IEnumerable<course> GetAll();
		course? GetById(Guid id);
		int GetCount(string? searchName = null);
		IEnumerable<course> GetPage(int page, int pageSize, string? searchName = null);
		void Add(course course);
		void Update(course course);
		void Delete(Guid id);
        void Save();

		bool IsNameExists(string name, Guid? excludeId = null);
	}
}
