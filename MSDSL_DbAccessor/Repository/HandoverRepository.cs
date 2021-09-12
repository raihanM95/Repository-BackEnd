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
    public class HandoverRepository : IHandoverRepository
    {
        private readonly IDbConnection _db;
        private readonly ApplicationDbContext _context;
        public HandoverRepository(IConfiguration configuration, ApplicationDbContext context)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _context = context;
        }


        public List<Object> GetHandoverList()
        {
            string sql = " select * from RepoDevs " +
                "left join Handovers ON Handovers.ID = RepoDevs.RepoID " +
                "left join RepositoryLists ON RepositoryLists.ID = RepoDevs.RepoID " +
                "left join Developers ON Developers.DeveloperID = RepoDevs.DevID";
            return _db.Query<Object>(sql).ToList();
        }

        public HandoverMap UpdateHandOver(HandoverMap handover, out string errMsg)
        {
            string ObjSql = "select * from RepoDevs where DevID=@DevID and RepoID=@RepoID";
            var IsExist = _db.Query<RepoDev>(ObjSql, new
            {
                @DevID = handover.devID,
                @RepoID = handover.repoID,
            }).FirstOrDefault();
            var prevdevid = IsExist.DevID;
            var prevdate = IsExist.AssignDate;


            errMsg = string.Empty;
            string sql = "update RepoDevs set DevID=@NewDev,NewDev=@OldDev,NewDate=@OldDate,AssignDate=@NewDate,IsFirstAssign=@IsFirstAssign where ID=@ID";
            _db.Query<RepoDevMap>(sql, new
            {
                @NewDev = handover.New_Dev,
                @OldDev = prevdevid,
                @OldDate = prevdate,
                @NewDate = handover.NewDate,
                @IsFirstAssign = handover.IsFirstAssign,
                @ID = handover.ID,
            });
            return handover;
        }
    }
}
