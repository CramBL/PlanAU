using System;
using Microsoft.EntityFrameworkCore;

namespace DBApi.Models {
	public class StudentContext : DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> options) : base(options) {
		}

		public DbSet<Student> STUDENTS { get; set; }
	}
}