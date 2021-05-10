using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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
        /// <summary>
        /// FirstOrDefault
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EnUcuz")]
        public async Task<Product> EnUcuz()
        {
            string sql = "SELECT TOP 1 * FROM dbo.PRODUCTS WHERE UnitPrice >0 ORDER BY UnitPrice ASC ; ";
            return await connection.QueryFirstOrDefaultAsync<Product>(sql); 
        }

        /// <summary>
        /// FirstOrDefault
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("EnPahali")]
        public async Task<Product> EnPahali()
        {
            string sql = "SELECT TOP 1 * FROM dbo.PRODUCTS WHERE UnitPrice >0 ORDER BY UnitPrice DESC ; ";
            return await connection.QueryFirstOrDefaultAsync<Product>(sql);
        }

        /// <summary>
        /// return ANONYMOUS type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OrdersAndDetails")]
        [ProducesResponseType(StatusCodes.Status200OK )]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> OrdersAndDetails()
        {
            string sql = "SELECT * FROM vOrdersAndDetails";

            var result =await connection.QueryAsync(sql);

            return Ok(result);
        }

       



    }
}
