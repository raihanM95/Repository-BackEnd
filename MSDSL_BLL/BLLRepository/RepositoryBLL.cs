using AutoMapper;
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
    public class RepositoryBLL : IRepositoryBLL
    {
        private readonly IMapper _mapper;
        private readonly IRepositoriesRepository _repo;

        public RepositoryBLL(IMapper mapper, IRepositoriesRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public RepositoryListMap CreateRepository(RepositoryListMap repoList, out string errMessage)
        {

            bool isExist = _repo.isUniqueRepo(repoList.RepositoryName);
            if (isExist)
            {
                errMessage = "Repository already exist";
                return null;
            }
            RepositoryList Obj = _mapper.Map<RepositoryList>(repoList);
            var ObjData = _repo.CreateRepository(Obj, out errMessage);
            return _mapper.Map<RepositoryListMap>(ObjData);
        }

        public string DeleteRepository(int id, out string errMessage)
        {
            bool isExist = _repo.IsUniqueRepoID(id);
            if (!isExist)
            {
                errMessage = "Repository does not exist";
                return null;
            }
            return _repo.DeleteRepository(id, out errMessage);
        }

        public ICollection<RepositoryListMap> GetRepositories(out string errMsg)
        {
            errMsg = string.Empty;
            var ObjResult = _repo.GetRepositories();
            if (ObjResult == null)
            {
                errMsg = "No data found.";
                return null;
            }
            return _mapper.Map<List<RepositoryListMap>>(
               ObjResult);
        }

        public RepositoryListMap GetRepository(int id, out string errMessage)
        {
            return _mapper.Map<RepositoryListMap>(
              _repo.GetRepository(id, out errMessage));
        }


        public RepositoryListMap UpdateRepository(RepositoryListMap repoList, out string errMessage)
        {
            errMessage = string.Empty;
            bool isExist = _repo.IsUniqueRepoID(repoList.ID);
            if (isExist)
            {
                RepositoryList repository = _mapper.Map<RepositoryList>(repoList);
                var ObjData = _repo.UpdateRepository(repository, out errMessage);                
                return _mapper.Map<RepositoryListMap>(ObjData); ;
            }
            else
            {
                errMessage = "Repository does not exist";
                
            }

            return repoList;
        }
    }
}
