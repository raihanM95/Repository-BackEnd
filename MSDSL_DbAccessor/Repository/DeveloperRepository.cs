using Dapper;
using Microsoft.Data.SqlClient;
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
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly IDbConnection _db;

        public DeveloperRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public Developer CreateDeveloper(Developer developer, out string msg)
        {
            msg = string.Empty;

            var sql = "insert into Developers (DeveloperName) values (@DeveloperName);SELECT CAST(SCOPE_IDENTITY() AS INT)";

            if (_db.State == ConnectionState.Closed)
                _db.Open();
            using (var transaction = _db.BeginTransaction())
            {
                var id = _db.Query<int>(sql, new
                {
                    developer.DeveloperName,
                }, transaction: transaction).FirstOrDefault();

                if (string.IsNullOrEmpty(id.ToString()))
                {
                    msg = "Scope identity null.Error in query parameter.";
                    transaction.Rollback();
                }
                else
                {
                    developer.DeveloperID = id;
                    transaction.Commit();
                }
            }

            return developer;
        }

        public int DeleteDeveloper(int developerID, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "delete from Developers where DeveloperID= @DeveloperID; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @DeveloperID = developerID });
            if (objResult <= 0)
            {
                errMsg = "No row affected";
            }
            return objResult;
        }

        public Developer GetDeveloper(string developerName, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "select * from Developers where DeveloperName = @DeveloperName";
            var objResponse = _db.Query<Developer>(sql, new { DeveloperName = developerName }).FirstOrDefault();
            if (objResponse == null)
            {
                errMsg = "No data found.";
            }
            return objResponse;
        }

        public Developer GetDeveloperById(int developerId, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "select * from Developers where DeveloperID = @DeveloperID";
            var objResponse = _db.Query<Developer>(sql, new { @DeveloperID = developerId }).FirstOrDefault();
            if (objResponse == null)
            {
                errMsg = "No data found.";
            }
            return objResponse;
        }

        public ICollection<Developer> GetDevelopers()
        {
            string sql = "select * from Developers";
            return _db.Query<Developer>(sql).ToList();
        }

        public bool IsUniqueDeveloper(string DeveloperName)
        {
            string sql = "SELECT COUNT(*) FROM Developers WHERE DeveloperName = @name";
            bool value = _db.Query<bool>(sql, new { @name = DeveloperName }).Single();
            return value;
        }

        public Developer UpdateDeveloper(Developer developer)
        {
            string sql = "update Developers set DeveloperName=@DeveloperName where DeveloperID=@DeveloperID;";
            _db.Execute(sql, developer);
            return developer;
        }
    }
}
