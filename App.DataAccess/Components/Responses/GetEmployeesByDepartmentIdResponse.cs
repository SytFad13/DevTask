namespace App.DataAccess.Components.Responses
{
	public class GetEmployeesByDepartmentIdResponse
	{
		public int? DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public int EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public static DateTime? CreatedDate => DateTime.Now;
	}
}
