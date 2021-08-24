using MSDSL_RepoModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLContract
{
    public interface IRepositoryBLL
    {
        ICollection<RepositoryListMap> GetRepositories(out string errMsg);
        RepositoryListMap GetRepository(int id, out string errMessage);
        RepositoryListMap CreateRepository(RepositoryListMap repoList, out string errMessage);
        RepositoryListMap UpdateRepository(RepositoryListMap repoList, out string errMessage);
        string DeleteRepository(int id, out string errMessage);
    }
}
