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
    public class HandoverController : ControllerBase
    {
        private readonly IHandoverBLL _handoverBLL;

        public HandoverController(IHandoverBLL handoverBLL)
        {
            _handoverBLL = handoverBLL;
        }

        [HttpGet]
        public IActionResult GetHandOver()
        {
            var response = _handoverBLL.GetHandoverList();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult UpdateHandOver([FromBody] HandoverMap handover)
        {
            var response = _handoverBLL.UpdateHandOver(handover,  out string errMsg);

            if(response==null)
            {
                return BadRequest(response);
            }
            if(!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(response);
        }
    }
}
