using ITITaskMVC.Models;

namespace ITITaskMVC.Data
{
	public static class InstructorData
	{
		public static List<Instructor> instructors = new List<Instructor>
	{
		new Instructor
		{
			FirstName = "John",
			LastName = "Doe",
			Bio = "Expert in C# and ASP.NET",
			Specialization = Specialization.SoftwareDevelopment,
			IsActive = true
		},
		new Instructor
		{
			FirstName = "Sara",
			LastName = "Smith",
			Bio = "Business Analyst",
			Specialization = Specialization.Business,
			IsActive = true
		}
	};
	}
}
