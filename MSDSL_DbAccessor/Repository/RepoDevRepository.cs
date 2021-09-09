using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Dtos;
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

        public RepoDevMap CreateRepoDev(RepoDevMap repoDevMap, out string errMsg)
        {
            string ObjSql = "select * from RepoDevs where DevID=@DevID and RepoID=@RepoID";
            var IsExist = _db.Query<RepoDev>(ObjSql, new
            {
                @DevID= repoDevMap.DevID,
                @RepoID = repoDevMap.RepoID,
            }).FirstOrDefault();

            if(IsExist!=null)
            {
                errMsg = "Already Exist";
                return null;
            }
            //
            errMsg = string.Empty;
            var sql = "insert into RepoDevs (RepoID,DevID,AssignDate,AssignFrom,IsFirstAssign) values (@RepoID,@DevID,@AssignDate,@AssignFrom,@IsFirstAssign);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)";

            if (_db.State == ConnectionState.Closed)
                _db.Open();
            using (var transaction = _db.BeginTransaction())
            {
                var id = _db.Query<int>(sql, new
                {
                    @RepoID = repoDevMap.RepoID,
                    @DevID = repoDevMap.DevID,
                    @AssignDate = repoDevMap.AssignDate,
                    @AssignFrom = repoDevMap.AssignFrom,
                    @IsFirstAssign = repoDevMap.IsFirstAssign,

                }, transaction: transaction).FirstOrDefault();

                if (string.IsNullOrEmpty(id.ToString()))
                {

                    errMsg = "Scope identity null.Error in query parameter.";
                    transaction.Rollback();
                }
                else
                {
                    repoDevMap.ID = id;
                    transaction.Commit();
                }
            }
            return repoDevMap;
        }


        public string DeleteRepoDev(int id,out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "delete from RepoDevs where ID= @repodevId; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @repodevId = id });
            if (objResult <= 0)
            {
                errMsg = "No row affected";
            }
            return "Delete Successfull";
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

        public RepoDevMap UpdateRepoDev(RepoDevMap repoDevMap, out string errMessage)
        {
            string ObjSql = "select * from RepoDevs where DevID=@DevID and RepoID=@RepoID";
            var IsExist = _db.Query<RepoDev>(ObjSql, new
            {
                @DevID = repoDevMap.DevID,
                @RepoID = repoDevMap.RepoID,
            }).FirstOrDefault();

            if (IsExist != null)
            {
                errMessage = "Already Exist";
                return null;
            }
            errMessage = string.Empty;
            string sql = "update RepoDevs set RepoID=@RepoID,DevID=@DevID,AssignDate=@AssignDate,AssignFrom=@AssignFrom,IsFirstAssign=@IsFirstAssign where ID=@ID";
            _db.Query<RepoDevMap>(sql, new
            {
                @RepoID = repoDevMap.RepoID,
                @DevID = repoDevMap.DevID,
                @AssignDate = repoDevMap.AssignDate,
                @AssignFrom = repoDevMap.AssignFrom,
                @IsFirstAssign = repoDevMap.IsFirstAssign,
                @ID = repoDevMap.ID,
            });
            return repoDevMap;
        }
    }
}
