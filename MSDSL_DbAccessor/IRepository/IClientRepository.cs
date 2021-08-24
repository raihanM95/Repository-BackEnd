using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();
        Client GetClient(string clientName, out string errMsg);
        Client GetClientById(int clientId, out string errMsg);
        Client CreateClient(Client client, out string msg);
        Client UpdateClient(Client client);
        int DeleteClient(int clientID, out string errMsg);
        bool IsUniqueClient(string ClientName);
    }
}
