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
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _db;

        public ClientRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Client CreateClient(Client client, out string msg)
        {
            msg = string.Empty;

            var sql = "insert into Clients (Client_Name) values (@ClientName);SELECT CAST(SCOPE_IDENTITY() AS INT)";
            if (_db.State == ConnectionState.Closed)
                _db.Open();
            using (var transaction = _db.BeginTransaction())
            {
                var id = _db.Query<int>(sql, new
                {
                    @ClientName = client.Client_Name,
                }, transaction: transaction).FirstOrDefault();

                if (string.IsNullOrEmpty(id.ToString()))
                {
                    
                    msg = "Scope identity null.Error in query parameter.";
                    transaction.Rollback();
                }
                else
                {
                    client.ClientID = id;
                    transaction.Commit();
                }
            }

            return client;
        }

        public int DeleteClient(int clientID, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "delete from Clients where ClientID= @clientId; SELECT @@ROWCOUNT";
            var objResult = _db.Execute(sql, new { @clientId = clientID });
            if (objResult <= 0)
            {
                errMsg = "No row affected";
            }
            return objResult;
        }


        public Client GetClient(string clientName, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "select * from Clients where Client_Name = @ClientName";
            var objResponse = _db.Query<Client>(sql, new { @ClientName = clientName }).FirstOrDefault();
            if (objResponse == null)
            {
                errMsg = "No data found.";
            }
            return objResponse;
        }
        public Client GetClientById(int clientId, out string errMsg)
        {
            errMsg = string.Empty;
            string sql = "select * from Clients where ClientID = @ClientId";
            var objResponse = _db.Query<Client>(sql, new { ClientId = clientId }).FirstOrDefault();
            if (objResponse == null)
            {
                errMsg = "No data found.";
            }
            return objResponse;
        }

        public ICollection<Client> GetClients()
        {
            string sql = "select * from Clients";
            return _db.Query<Client>(sql).ToList();
        }


        public bool IsUniqueClient(string ClientName)
        {
            string sql = "SELECT COUNT(*) FROM Clients WHERE Client_Name = @name";
            bool value = _db.Query<bool>(sql, new { @name = ClientName }).Single();
            return value;
        }


        public Client UpdateClient(Client client)
        {
            string sql = "update Clients set Client_Name=@Client_Name where ClientID=@ClientID;";
            _db.Execute(sql, client);
            return client;
        }
    }
}
