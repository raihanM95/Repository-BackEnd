using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_BLL.BLLContract;
using MSDSL_DbAccessor.IRepository;
using MSDSL_RepoModel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSDSL_RepositoryManagement.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RepositoriesController : ControllerBase
    {
        private readonly IRepositoryBLL _repoAcces;

        public RepositoriesController(IRepositoryBLL repoAcces)
        {
            _repoAcces = repoAcces;
        }

        [HttpGet]
        public IActionResult GetRepositories()
        {
            var ObjList = _repoAcces.GetRepositories(out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(ObjList);
        }
        [HttpGet]
        public IActionResult GetRepository(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest("Invalid ID");
            }
            var obj = _repoAcces.GetRepository(id, out string errmsg);
            if (!string.IsNullOrEmpty(errmsg))
            {
                return BadRequest(errmsg);
            }
            return Ok(obj);
        }
        [HttpPost]
        public IActionResult CreateRepository([FromBody] RepositoryListMap repositoryList)
        {
            var objResult = _repoAcces.CreateRepository(repositoryList, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(objResult);
        }

        [HttpPost]
        public IActionResult UpdateRepository([FromBody] RepositoryListMap repositoryList)
        {
            var ObjResult = _repoAcces.UpdateRepository(repositoryList, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            if (ObjResult == null)
            {
                return BadRequest();
            }
            return Ok(ObjResult);
        }
        [HttpPost]
        public IActionResult RemoveRepository(int Id)
        {
            var Obj = _repoAcces.DeleteRepository(Id, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }
    }
}
