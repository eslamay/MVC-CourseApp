using ITITaskMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Repositories.InstructorRepository
{
	public interface IInstructorRepo
	{
		IEnumerable<Instructor> GetAll();
	}
}
