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
    public class DeveloperBLL : IDeveloperBLL
    {
        private readonly IMapper _mapper;
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperBLL(IMapper mapper, IDeveloperRepository developerRepository)
        {
            _mapper = mapper;
            _developerRepository = developerRepository;
        }
        public DeveloperMap CreateDeveloper(DeveloperMap developer, out string msg)
        {
            bool isExist = _developerRepository.IsUniqueDeveloper(developer.DeveloperName);
            if (isExist)
            {
                msg = "Developer already exist";
                return null;
            }
            Developer developerObj = _mapper.Map<Developer>(developer);
            var ObjData = _developerRepository.CreateDeveloper(developerObj, out msg);
            return _mapper.Map<DeveloperMap>(ObjData);
        }

        public int DeleteDeveloper(int developerID, out string errMsg)
        {
            return _developerRepository.DeleteDeveloper(developerID, out errMsg);
        }

        public DeveloperMap GetDeveloper(string developerName, out string errMsg)
        {
            return _mapper.Map<DeveloperMap>(
               _developerRepository.GetDeveloper(developerName, out errMsg));
        }

        public DeveloperMap GetDeveloperById(int developerId, out string errMsg)
        {
            return _mapper.Map<DeveloperMap>(
              _developerRepository.GetDeveloperById(developerId, out errMsg));
        }

        public ICollection<DeveloperMap> GetDevelopers(out string errMsg)
        {
            errMsg = string.Empty;
            var ObjResult = _developerRepository.GetDevelopers();
            if (ObjResult == null)
            {
                errMsg = "No data found.";
                return null;
            }
            return _mapper.Map<List<DeveloperMap>>(
               ObjResult);
        }

        public bool IsUniqueDeveloper(string DeveloperName)
        {
            return _developerRepository.IsUniqueDeveloper(DeveloperName);
        }

        public DeveloperMap UpdateDeveloper(DeveloperMap developer)
        {
            Developer developerObj = _mapper.Map<Developer>(developer);
            var ObjData = _developerRepository.UpdateDeveloper(developerObj);
            return _mapper.Map<DeveloperMap>(ObjData);
        }
    }
}
