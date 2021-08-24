using AutoMapper;
using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDSL_BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientMap>().ReverseMap();
            CreateMap<Developer, DeveloperMap>().ReverseMap();
            CreateMap<RepositoryList, RepositoryListMap>().ReverseMap();
        }
    }
}
