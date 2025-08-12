namespace ITITaskMVC.Models.ViewModels
{
	public class CourseVM
	{
		public string Name { get; set; }=string.Empty;
		public string Description { get; set; } = string.Empty;
		public CategoryCourse Category { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public Guid InstructorId { get; set; }
	}
}
