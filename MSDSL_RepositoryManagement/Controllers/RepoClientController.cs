using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_BLL.BLLContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RepoClientController : ControllerBase
    {
        private readonly IRepoClientBLL _repoclientBLL;

        public RepoClientController(IRepoClientBLL repoclientBLL)
        {
            _repoclientBLL = repoclientBLL;
        }
    }
}
