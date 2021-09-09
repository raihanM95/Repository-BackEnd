using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_BLL.BLLContract;
using MSDSL_RepoModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RepoDevController : ControllerBase
    {
        private readonly IRepoDevBLL _repoDevBLL;

        public RepoDevController(IRepoDevBLL repoDevBLL)
        {
            _repoDevBLL = repoDevBLL;
        }

        [HttpGet]
        public IActionResult GetAllRepoDevs()
        {
            var response = _repoDevBLL.GetAllRepoDevs();
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        [HttpPost]
        public IActionResult DeleteRepoDev(int id)
        {
            var response = _repoDevBLL.DeleteRepoDev(id, out string errMsg);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateRepoDev([FromBody] RepoDevMap repoDevMap)
        {
            var response = _repoDevBLL.CreateRepoDev(repoDevMap, out string errMsg);
            if (response == null && !string.IsNullOrEmpty(errMsg))
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult UpdateRepoDev([FromBody] RepoDevMap repoDevMap)
        {
            var response = _repoDevBLL.UpdateRepoDev(repoDevMap, out string errMsg);

            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
