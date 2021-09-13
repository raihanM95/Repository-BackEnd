using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MSDSL_DbAccessor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IDbConnection _dapper;

        public DashboardController(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _dapper = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public IActionResult TotalClients()
        {
            var clients = _db.Clients.Count();
            return Ok(clients);
        }

        [HttpGet]
        public IActionResult TotalDevelopers()
        {
            var developers = _db.Developers.Count();
            return Ok(developers);
        }

        [HttpGet]
        public IActionResult TotalRepository()
        {
            var clients = _db.RepositoryLists.Count();
            return Ok(clients);
        }
        [HttpGet]
        public IActionResult TrendingRepo()
        {
            var sql = "select COUNT(*) as maxx,RepoID  as id from RepoDevs group by repoid order by count(*) desc";

            var obj = _dapper.Query<Object>(sql);

            var repoobj = _db.RepositoryLists.FirstOrDefault(obj.id);
            return Ok(obj);
        }
    }
}
