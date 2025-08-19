using ITITaskMVC.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.BLL.Services.InstructorService
{
	public interface IInstructorService
	{
		IEnumerable<SelectListItem> GetAllInstructors();
	}
}
