using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Utils
{
    public static class clsUtils
    {
		public static string GetConnectionString()
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
							.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
							.AddJsonFile("appsettings.json")
							.Build();
			return configuration.GetConnectionString("DBConnection");
		}



	}
}
