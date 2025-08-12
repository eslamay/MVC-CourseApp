namespace ITITaskMVC.Models
{
	public enum CategoryCourse
	{
		Business,
		Design,
		Marketing,
		Programming,
	}
	public class course
	{
		public Guid Id { get; set; }
		public string Name { get; set; }=string.Empty;
		public string Description { get; set; } = string.Empty;

		public CategoryCourse Category { get; set; }
		public DateTime startDate { get; set; }

		public DateTime endDate { get; set; }

		public bool IsActive { get; set; }
	}
}
