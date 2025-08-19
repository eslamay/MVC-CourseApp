using ITITaskMVC.DAL.Data;
using ITITaskMVC.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Repositories.InstructorRepository
{
	public class InstructorRepo : IInstructorRepo
	{
		private readonly AppDbContext dbContext;

		public InstructorRepo(AppDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public IEnumerable<Instructor> GetAll()
		{
			return dbContext.Instructors.ToList();
		}
	}
}
