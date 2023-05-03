using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public int DepartmentId { get; set; }
		public static DateTime? CreatedDate => DateTime.Now;
	}
}
