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
    public class RepoDevBLL : IRepoDevBLL
    {
        private readonly IRepoDevRepository _repoDev;
        public RepoDevBLL(IRepoDevRepository repoDev)
        {
            _repoDev = repoDev;
        }
        public List<RepoDev> GetAllRepoDevs()
        {
            return _repoDev.GetAllRepoDevs();
        }
        public RepoDev GetRepoDev(int id)
        {
            return _repoDev.GetRepoDev(id);
        }
    }
}
