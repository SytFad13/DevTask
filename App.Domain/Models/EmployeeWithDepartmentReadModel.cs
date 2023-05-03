namespace App.Domain.Models
{
	public class EmployeeWithDepartmentReadModel
	{
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public int? DepartmentId { get; set; }
		public string DepartmentName { get; set; }
	}
}
