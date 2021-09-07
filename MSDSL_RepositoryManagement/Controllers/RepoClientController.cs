using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_BLL.BLLContract;
using MSDSL_RepoModel.Dtos;
using MSDSL_RepoModel.Entities;
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

        [HttpGet]
        public IActionResult GetRepoClients()
        {
            var response = _repoclientBLL.GetAllRepoClients();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetRepoClient(int id)
        {
            var response = _repoclientBLL.GetRepoClient(id);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult DeleteRepoClient(int id)
        {
            var response = _repoclientBLL.DeleteRepoClient(id, out string errMsg);
            if (response == null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(response);

        }
        [HttpPost]
        public IActionResult CreateRepoClient([FromBody] RepoClientMap repoClient)
        {
            var response = _repoclientBLL.CreateRepoClient(repoClient, out string errMsg);
            if (response == null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(response);

        }
        [HttpPost]
        public IActionResult UpdateRepoClient([FromBody] RepoClientMap repoClient)
         {
            var response = _repoclientBLL.UpdateRepoClient(repoClient, out string errMsg);
            if (response == null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(response);

        }
    }
}
