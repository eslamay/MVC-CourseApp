using ITITaskMVC.DAL.Data;
using ITITaskMVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Repositories.CourseRepository
{
	public class CourseRepo : ICourseRepo
	{
		private readonly AppDbContext dbContext;

		public CourseRepo(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public IEnumerable<course> GetAll()
		{
			return dbContext.Courses.Include(x => x.Instructor).ToList();
		}

		public course? GetById(Guid id)
		{
			return dbContext.Courses.Include(c => c.Instructor).FirstOrDefault(x => x.Id == id);
		}
		public int GetCount(string? searchName = null)
		{
			var query = dbContext.Courses.AsNoTracking();
			if (!string.IsNullOrEmpty(searchName))
			{
				query = query.Where(x => x.Name.Contains(searchName));
			}
			return query.Count();
		}

		public IEnumerable<course> GetPage(int page, int pageSize, string? searchName = null)
		{
			var query = dbContext.Courses.Include(x => x.Instructor).AsNoTracking();
			if (!string.IsNullOrEmpty(searchName))
			{
				query = query.Where(x => x.Name.Contains(searchName));
			}
			query = query.OrderBy(x => x.Name);
			return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}
		public void Add(course course)
		{
			dbContext.Courses.Add(course);
		}
		public void Update(course course)
		{
           dbContext.Courses.Update(course);
		}

		public void Delete(Guid id)
		{
           var course = dbContext.Courses.FirstOrDefault(x => x.Id == id);
			dbContext.Courses.Remove(course);
		}

		

		public void Save()
		{
           dbContext.SaveChanges();
		}
		public bool IsNameExists(string name, Guid? excludeId = null)
		{
			return dbContext.Courses.Any(c => c.Name == name && (!excludeId.HasValue || c.Id != excludeId));
		}

		
	}
}
