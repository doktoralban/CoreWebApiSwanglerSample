using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Utils;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly DbContextNW _context;
        private readonly SqlConnection connection;
       
        public ProductsController( DbContextNW context, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _context = context;
          

            connection = new SqlConnection(clsUtils.GetConnectionString());
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAsync()
        {
            string sql = "SELECT * FROM dbo.PRODUCTS";
            return await connection.QueryAsync<Product>(sql);
        }



    }
}
