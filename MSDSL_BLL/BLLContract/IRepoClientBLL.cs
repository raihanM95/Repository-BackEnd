using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLContract
{
    public interface IRepoClientBLL
    {
        RepoClient CreateRepoClient(RepoClient repoClient, out string errMsg);
        List<RepoClient> GetAllRepoClients();
        RepoClient GetRepoClient(int ID);
        string DeleteRepoClient(int ID, out string errMsg);
        public RepoClient UpdateRepoClient(RepoClient repoClient, out string errMessage);
    }
}
