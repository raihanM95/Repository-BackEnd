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
    public class RepositoriesRepository : IRepositoriesRepository
    {
        private readonly IDbConnection _db;
        public RepositoriesRepository(IConfiguration configation)
        {
            _db = new SqlConnection(configation.GetConnectionString("DefaultConnection"));
        }
        public RepositoryList CreateRepository(RepositoryList repoList, out string errMessage)
        {
            errMessage = string.Empty;

            var sql = "insert into RepositoryLists (RepositoryName,URL,ToolsTech,Comments,RepoType,CreateDate,LastUpdate) " +
                "values (@RepositoryName,@URL,@ToolsTech,@Comments,@RepoType,@CreateDate,@LastUpdate);" +
                "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            if (_db.State == ConnectionState.Closed)
                _db.Open();
            using (var transaction = _db.BeginTransaction())
            {
                var id = _db.Query<int>(sql, new
                {
                    @RepositoryName = repoList.RepositoryName,
                    @URL = repoList.URL,
                    @ToolsTech = repoList.ToolsTech,
                    @Comments = repoList.Comments,
                    @RepoType = repoList.RepoType,
                    @CreateDate = repoList.CreateDate,
                    @LastUpdate = repoList.LastUpdate,
                }, transaction: transaction).FirstOrDefault();

                if (string.IsNullOrEmpty(id.ToString()))
                {

                    errMessage = "Scope identity null.Error in query parameter.";
                    transaction.Rollback();
                }
                else
                {
                    repoList.ID = id;
                    transaction.Commit();
                }
            }

            return repoList;
        }

        public string DeleteRepository(int id, out string errMessage)
        {
            errMessage = string.Empty;
            string sql = "delete from RepositoryLists  where ID=@id; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @id = id });
            if (objResult <= 0)
            {
                errMessage = "No row affected";
                return errMessage;
            }
            return "Delete Successfull";
        }

        public ICollection<RepositoryList> GetRepositories()
        {
            var sql = "select * from RepositoryLists";
            return _db.Query<RepositoryList>(sql).ToList();
        }

        public RepositoryList GetRepository(int id, out string errMessage)
        {
            errMessage = string.Empty;
            var sql = "select * from RepositoryLists where ID=@id";
            var response = _db.Query<RepositoryList>(sql, new
            {
                @id = id
            }).FirstOrDefault();

            if (response == null)
            {
                errMessage = "No data found.";
            }
            return response;
        }

        public bool isUniqueRepo(string name)
        {
            string sql = "SELECT COUNT(*) FROM RepositoryLists WHERE RepositoryName = @name";
            bool value = _db.Query<bool>(sql, new { @name = name }).Single();
            return value;
        }
        public bool IsUniqueRepoID(int ID)
        {
            string sql = "SELECT COUNT(*) FROM RepositoryLists WHERE ID = @ID";
            bool value = _db.Query<bool>(sql, new { @ID = ID }).Single();
            return value;
        }

        public RepositoryList UpdateRepository(RepositoryList repoList, out string errMessage)
        {
            errMessage = string.Empty;
            string sql = "update RepositoryLists set RepositoryName=@RepositoryName,URL=@URL,ToolsTech=@ToolsTech," +
                "Comments=@Comments,RepoType=@RepoType,CreateDate=@CreateDate,LastUpdate=@LastUpdate where ID=@ID;";
            _db.Execute(sql, repoList);
            return repoList;
        }
    }

}
