using App.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Department> Departments { get; set; }

		public DbSet<Employee> Employees { get; set; }
	}
}
