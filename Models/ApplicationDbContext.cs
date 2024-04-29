using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace TestApp.Models
{
	public class ApplicationDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		
		public ApplicationDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite(Configuration.GetConnectionString("ToDoDatabase"));
		}

		public DbSet<ToDoPost> ToDoPosts { get; set; }
		public DbSet<Category> Categories { get; set; }

	}
}
