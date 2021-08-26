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
    }
}
