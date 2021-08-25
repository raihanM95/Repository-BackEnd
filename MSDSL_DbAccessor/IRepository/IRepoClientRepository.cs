using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IRepoClientRepository
    {
        RepoClient CreateRepoClient(RepoClient repoClient,out string errMsg);
        List<RepoClient> GetAllRepoClients();
        RepoClient GetRepoClient(int ID);
        string DeleteRepoClient(int ID, out string errMsg);
        public RepoClient UpdateRepoClient(RepoClient repoClient, out string errMessage);
        bool IsExist(int id);
    }
}
