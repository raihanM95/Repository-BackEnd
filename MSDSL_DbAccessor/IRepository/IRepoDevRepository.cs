using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_DbAccessor.IRepository
{
    public interface IRepoDevRepository
    {
        List<RepoDev> GetAllRepoDevs();
        RepoDev GetRepoDev(int id);
        RepoDevMap CreateRepoDev(RepoDevMap repoDevMap, out string errMsg);
        RepoDevMap UpdateRepoDev(RepoDevMap repoDevMap, out string errMessage);
        string DeleteRepoDev(int id,out string errMsg);
        bool IsExist(int id);
    }
}
