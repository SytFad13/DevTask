namespace App.DataAccess.Components.Responses
{
    public class MoveEmployeesToNewDepartmentResponse
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName => $"{FirstName} {LastName}";
		public int DepartmentId { get; set; }
		public static DateTime? CreatedDate => DateTime.Now;
	}
}
