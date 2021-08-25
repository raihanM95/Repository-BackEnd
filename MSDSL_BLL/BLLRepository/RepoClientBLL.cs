using MSDSL_BLL.BLLContract;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLRepository
{
    public class RepoClientBLL : IRepoClientBLL
    {
        private readonly IRepoClientRepository _repoclient;
        public RepoClientBLL(IRepoClientRepository repoclient)
        {
            _repoclient = repoclient;
        }
        public RepoClient CreateRepoClient(RepoClient repoClient, out string errMsg)
        {
            var isExist = _repoclient.IsExist(repoClient.RepoClientID);
            if(isExist)
            {
                errMsg = "Data already exist";
                return repoClient;
            }
            return _repoclient.CreateRepoClient(repoClient, out errMsg);
        }

        public string DeleteRepoClient(int ID, out string errMsg)
        {
            var isExist = _repoclient.IsExist(ID);
            if (!isExist)
            {
                errMsg = "Not found";
                return errMsg;
            }
            return _repoclient.DeleteRepoClient(ID, out errMsg);
        }

        public List<RepoClient> GetAllRepoClients()
        {
            return _repoclient.GetAllRepoClients();
        }

        public RepoClient GetRepoClient(int ID)
        {
            return _repoclient.GetRepoClient(ID);
        }

        public RepoClient UpdateRepoClient(RepoClient repoClient, out string errMsg)
        {
            var isExist = _repoclient.IsExist(repoClient.RepoClientID);
            if (!isExist)
            {
                errMsg = "No data found.";
                return null;
            }
            return _repoclient.UpdateRepoClient(repoClient, out errMsg);
        }
    }
}
