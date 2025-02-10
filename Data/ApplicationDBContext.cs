using System;
using Microsoft.EntityFrameworkCore;
using api.Models;


namespace api.Data
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOption)
			:base(dbContextOption)
		{
			
		}

		//creazione tabelle
		public DbSet<Stock> Stocks { get; set; } 
		public DbSet<Comment> Comments { get; set; }
	}
}
