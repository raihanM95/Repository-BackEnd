using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL.BLLContract
{
    public interface IRepoDevBLL
    {
        List<RepoDev> GetAllRepoDevs();
        RepoDev GetRepoDev(int id);
        string DeleteRepoDev(int id, out string errMsg);
        RepoDevMap CreateRepoDev(RepoDevMap repoDevMap, out string errMsg);
        RepoDevMap UpdateRepoDev(RepoDevMap repoDevMap, out string errMsg);
    }
}
