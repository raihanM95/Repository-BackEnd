using MSDSL_BLL.BLLContract;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Dtos;
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

        public RepoDevMap CreateRepoDev(RepoDevMap repoDevMap, out string errMsg)
        {
            return _repoDev.CreateRepoDev(repoDevMap, out errMsg);

        }

        public string DeleteRepoDev(int id, out string errMsg)
        {
            var response = _repoDev.DeleteRepoDev(id, out errMsg);
            if(string.IsNullOrEmpty(response.ToString()))
            {
                return errMsg = "Response Null";
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return errMsg = "Response Null";
            }
            return response;
        }

        public List<RepoDev> GetAllRepoDevs()
        {
            return _repoDev.GetAllRepoDevs();
        }
        public RepoDev GetRepoDev(int id)
        {
            return _repoDev.GetRepoDev(id);
        }

        public RepoDevMap UpdateRepoDev(RepoDevMap repoDevMap, out string errMsg)
        {
            var isExist = _repoDev.IsExist(repoDevMap.ID);
            if (isExist)
            {
                errMsg = "No data found.";
                return null;
            }
            return _repoDev.UpdateRepoDev(repoDevMap, out errMsg);
        }
    }
}
