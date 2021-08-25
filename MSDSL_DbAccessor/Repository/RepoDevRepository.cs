using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.Repository
{
    public class RepoDevRepository : IRepoDevRepository
    {
        private readonly IDbConnection _db;
        private readonly ApplicationDbContext _context;
        public RepoDevRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _context = context;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public List<RepoDev> GetAllRepoDevs()
        {
            var ObjData = _context.RepoDevs.Include(c => c.RepositoryList).Include(c => c.Developer).ToList();
            return ObjData;
        }

        public RepoDev GetRepoDev(int id)
        {
            var ObjData = _context.RepoDevs.Include(c => c.RepositoryList).Include(c => c.Developer).FirstOrDefault(a=>a.RepoID==id);
            return ObjData;
        }

        public bool IsExist(int id)
        {
            var ObjData = _context.RepoDevs.Include(c => c.RepositoryList).Include(c => c.Developer).Any(a => a.RepoID == id);
            return ObjData;
        }
    }
}
