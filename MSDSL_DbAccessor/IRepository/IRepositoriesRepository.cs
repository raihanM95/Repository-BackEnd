using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IRepositoriesRepository
    {
        ICollection<RepositoryList> GetRepositories();
        RepositoryList GetRepository(int id, out string errMessage);
        RepositoryList CreateRepository(RepositoryList repoList, out string errMessage);
        RepositoryList UpdateRepository(RepositoryList repoList, out string errMessage);
        string DeleteRepository(int id, out string errMessage);
        bool isUniqueRepo(string name);
        bool IsUniqueRepoID(int ID);

    }
}
