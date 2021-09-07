using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperBLL _developerBLL;

        public DeveloperController(IDeveloperBLL developerBLL)
        {
            _developerBLL = developerBLL;
        }

        [HttpGet]
        public IActionResult GetDeveloperList()
        {
            var ObjList = _developerBLL.GetDevelopers(out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(ObjList);

        }
        [HttpGet]
        public IActionResult GetDeveloperByName(string name)
        {
            var Obj = _developerBLL.GetDeveloper(name, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }
        [HttpGet]
        public IActionResult GetDeveloperById(int Id)
        {
            var Obj = _developerBLL.GetDeveloperById(Id, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }
        [HttpPost]
        public IActionResult RemoveDeveloper(int Id)
        {
            var Obj = _developerBLL.DeleteDeveloper(Id, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }

        [HttpPost]
        public IActionResult CreateDeveloper([FromBody] DeveloperMap developerMap)
        {
            var ObjResult = _developerBLL.CreateDeveloper(developerMap, out string errMsg);
            if (ObjResult == null)
            {
                return BadRequest(errMsg);
            }
            return Ok(ObjResult);

        }
        [HttpPost]
        public IActionResult UpdateDeveloper([FromBody] DeveloperMap developerMap)
        {
            var ObjResult = _developerBLL.UpdateDeveloper(developerMap);
            if (ObjResult == null)
            {
                return BadRequest();
            }
            return Ok(ObjResult);

        }

    }
}
