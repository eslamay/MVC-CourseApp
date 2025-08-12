namespace ITITaskMVC.Models
{
	public enum Specialization
	{
		SoftwareDevelopment,
		Marketing,
		Business
	}

	public class Instructor
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Bio { get; set; }
		public Specialization Specialization { get; set; }
		public bool IsActive { get; set; }
		public List<course> Courses { get; set; } = new List<course>();
	}
}
