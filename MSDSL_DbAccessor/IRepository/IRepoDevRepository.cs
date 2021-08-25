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
        bool IsExist(int id);
    }
}
