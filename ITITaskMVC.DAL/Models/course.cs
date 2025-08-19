using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITITaskMVC.DAL.Models
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
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		[MaxLength(500)]
		public string Description { get; set; }

		[Required]
		public CategoryCourse Category { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime startDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime endDate { get; set; }

		public bool IsActive { get; set; }

		public Guid? InstructorId { get; set; }

		public Instructor? Instructor { get; set; }
	}
}
