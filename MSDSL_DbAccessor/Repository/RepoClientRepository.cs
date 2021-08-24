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
    public class RepoClientRepository : IRepoClientRepository
    {
        private readonly IDbConnection _db;
        private readonly ApplicationDbContext _context;

        public RepoClientRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _context = context;
        }
        public RepoClient CreateRepoClient(RepoClient repoClient, out string errMsg)
        {
            errMsg = string.Empty;
            var ClientCheck = _context.Clients.Find(repoClient.ClientID);
            var RepoCheck = _context.RepositoryLists.Find(repoClient.RepoID);

            var CheckC = _context.RepoClients.FirstOrDefault(c=>c.ClientID==repoClient.ClientID);
            var CheckR = _context.RepoClients.FirstOrDefault(c=>c.RepoID==repoClient.RepoID);

            if(CheckC!=null && CheckR!=null)
            {
                errMsg = "Data already Exist";
                return repoClient;
            }

            if (ClientCheck != null && RepoCheck != null)
            {
                var sql = "insert into RepoClients (ClientID,RepoID,Dates) values (@ClientID,@RepoID,@Dates);" +
                    "SELECT CAST(SCOPE_IDENTITY() AS INT)";

                if (_db.State == ConnectionState.Closed)
                    _db.Open();
                using (var transaction = _db.BeginTransaction())
                {
                    var id = _db.Query<int>(sql, new
                    {
                        @ClientID = repoClient.ClientID,
                        @RepoID = repoClient.RepoID,
                        @Dates = repoClient.Dates,
                    }, transaction: transaction).FirstOrDefault();

                    if (string.IsNullOrEmpty(id.ToString()))
                    {

                        errMsg = "Scope identity null.Error in query parameter.";
                        transaction.Rollback();
                    }
                    else
                    {
                        repoClient.RepoClientID = id;
                        transaction.Commit();
                    }
                }
            }
            return repoClient;
        }
        public RepoClient UpdateRepoClient(RepoClient repoClient, out string errMessage)
        {
            errMessage = string.Empty;
            string sql = "update RepoClients set ClientID=@ClientID,RepoID=@RepoID,Dates=@Dates where ID=@ID;";
            _db.Execute(sql, repoClient);
            return repoClient;
        }

        public string DeleteRepoClient(int ID,out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "delete from RepoClients  where RepoClientID=@ID; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @ID = ID });
            if (objResult <= 0)
            {
                errMsg = "No row affected";
                return errMsg;
            }
            return "Delete Successfull";
        }

        public List<RepoClient> GetAllRepoClients(RepoClient repoClient)
        {
            string sql = "select * from RepoClients";
            return _db.Query<RepoClient>(sql).ToList();
        }

        public RepoClient GetRepoClient(int ID)
        {
            string sql = "select * from RepoClients where RepoClientID= @ID";
            var obj = _db.Query<RepoClient>(sql, new { @ID = ID }).FirstOrDefault();
            return obj;
        }

        public bool IsExist(int id)
        {
            var sql = "select COUNT(*)  from RepoClients where RepoClientID= @ID";
            bool exist = _db.Query<bool>(sql, new { @ID = id }).Single();
            return exist;
        }
    }
}
