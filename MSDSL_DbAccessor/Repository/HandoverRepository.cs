using Dapper;
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
    public class HandoverRepository : IHandoverRepository
    {
        private readonly IDbConnection _db;
        private readonly ApplicationDbContext _context;
        public HandoverRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _context = context;
        }
        public Handover CreateHandOver(Handover handover, out string errMsg)
        {
            throw new NotImplementedException();
        }

        public string DeleteHandOver(int ID, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "delete from Handovers where ID=@ID; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @ID = ID });
            if (objResult <= 0)
            {
                errMsg = "No row affected";
                return errMsg;
            }
            return "Delete Successfull";
        }

        public List<Handover> GetHandoverList()
        {
            var response = _context.Handovers.Include(m => m.Developer).Include(m => m.RepositoryList).ToList();
            return response;
        }

        public Handover UpdateHandOver(Handover handover, out string errMsg)
        {
            throw new NotImplementedException();
        }
    }
}
