using ITITaskMVC.DAL.Repositories.InstructorRepository;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace ITITaskMVC.BLL.Services.InstructorService
{
	public class InstructorService : IInstructorService
	{
		private readonly IInstructorRepo _instructorRepo;

		public InstructorService(IInstructorRepo instructorRepo)
		{
			_instructorRepo = instructorRepo;
		}

		public IEnumerable<SelectListItem> GetAllInstructors()
		{
			return _instructorRepo.GetAll()
				.Select(i => new SelectListItem
				{
					Value = i.Id.ToString(),
					Text = i.FirstName+ " " + i.LastName,
				}).ToList();
		}
	}
}
