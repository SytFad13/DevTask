using System.ComponentModel.DataAnnotations;

namespace App.Domain.Models
{
	public class Department
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int? ParentId { get; set; }
		public static DateTime? CreatedDate => DateTime.Now;
	}
}
