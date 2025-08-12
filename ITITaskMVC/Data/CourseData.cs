using ITITaskMVC.Models;

namespace ITITaskMVC.Data
{
	public static class CourseData
	{
		public static List<course> Courses = new List<course>()
		{
			new course
			{
				Id = Guid.NewGuid(),
				Name = "C#", 
				Description = " Learn the basics of C# programming language.",
				Category = CategoryCourse.Programming,
				startDate = new DateTime(2025, 8, 1),
				endDate = new DateTime(2025, 9, 1),
				IsActive = true
			},
			new course
			{
				Id = Guid.NewGuid(),
				Name = "Design",
				Description = "Understand the core principles of user interface and user experience design.",
				Category = CategoryCourse.Design,
				startDate = new DateTime(2025, 9, 1),
				endDate = new DateTime(2025, 10, 1),
				IsActive = true
			},
			new course
			{
				Id = Guid.NewGuid(),
				Name = "Marketing",
				Description = "Get started with SEO, social media, and online advertising.",
				Category = CategoryCourse.Marketing,
				startDate = new DateTime(2025, 10, 1),
				endDate = new DateTime(2025, 11, 1),
				IsActive = false
			},
			new course
			{
				Id = Guid.NewGuid(),
				Name = "Business",
				Description = "Learn the fundamentals of business management and leadership.",
				Category = CategoryCourse.Business,
				startDate = new DateTime(2025, 11, 1),
				endDate = new DateTime(2025, 12, 1),
				IsActive = true
			}
		};
	}
}
