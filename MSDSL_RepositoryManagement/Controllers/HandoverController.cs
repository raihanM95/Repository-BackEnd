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
    }
}
