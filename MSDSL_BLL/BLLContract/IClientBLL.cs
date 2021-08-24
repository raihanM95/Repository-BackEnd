using MSDSL_RepoModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL
{
    public interface IClientBLL
    {
        ICollection<ClientMap> GetClients(out string errMsg);
        ClientMap GetClient(string clientName, out string errMsg);
        ClientMap GetClientById(int clientId, out string errMsg);
        ClientMap CreateClient(ClientMap client, out string msg);
        ClientMap UpdateClient(ClientMap client);
        int DeleteClient(int clientID, out string errMsg);
        bool IsUniqueClient(string ClientName);
    }
}
