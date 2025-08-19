using ITITaskMVC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Data
{
	public static class InstructorData
	{
		public static List<Instructor> instructors = new List<Instructor>
	{
		new Instructor
		{
			Id =Guid.Parse("c9d4c053-49b6-410c-bc78-2d54a9991870"),
			FirstName = "John",
			LastName = "Doe",
			Bio = "Expert in C# and ASP.NET",
			Specialization = Specialization.SoftwareDevelopment,
			IsActive = true
		},
		new Instructor
		{
			Id=Guid.Parse("3d490a70-94ce-4d15-9494-5248280c2ce3"),
			FirstName = "Sara",
			LastName = "Smith",
			Bio = "Business Analyst",
			Specialization = Specialization.Business,
			IsActive = true
		}
	};
	}
}
