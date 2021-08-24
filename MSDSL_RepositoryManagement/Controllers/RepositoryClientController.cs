using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RepositoryClientController : ControllerBase
    {
        private readonly IRepoClientRepository _repoClientRepository;
        public RepositoryClientController(IRepoClientRepository repoClientRepository)
        {
            _repoClientRepository = repoClientRepository;
        }

        [HttpPost]
        public IActionResult CreateRepoClient([FromBody] RepoClient repoClient)
        {
            var obj = _repoClientRepository.CreateRepoClient(repoClient,out string err);
            return Ok(obj);
        }
    }
}
