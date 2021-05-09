using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace WebApplication1.Models
{
	public  class DbContextNW : DbContext
	{
	

		public DbContextNW(DbContextOptions<DbContextNW> options) : base(options)
		{

		}
		 

		public DbSet<Product> Products { get; set; }


	}
}