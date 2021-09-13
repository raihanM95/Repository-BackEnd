using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSDSL_BLL;
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
    public class ClientController : ControllerBase
    {
        private readonly IClientBLL _clientBLL;
        public ClientController(IClientBLL clientBLL)
        {
            _clientBLL = clientBLL;
        }

        [HttpGet]
        public IActionResult GetClientList()
        {
            var ObjList = _clientBLL.GetClients(out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(ObjList);
        }

        [HttpGet]
        public IActionResult GetClientByName(string name)
        {
            var Obj = _clientBLL.GetClient(name, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }
        [HttpGet]
        public IActionResult GetClientById(int Id)
        {
            var Obj = _clientBLL.GetClientById(Id, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }
        [HttpPost]
        public IActionResult RemoveClient(int Id)
        {
            var Obj = _clientBLL.DeleteClient(Id, out string errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                return BadRequest(errMsg);
            }
            return Ok(Obj);

        }

        [HttpPost]
        public IActionResult ClientSave([FromBody] ClientMap clientMap)
        {
            var ObjResult = _clientBLL.CreateClient(clientMap, out string errMsg);
            if (ObjResult == null)
            {
                return BadRequest(errMsg);
            }
            return Ok(ObjResult);

        }
        [HttpPost]
        public IActionResult UpdateClient([FromBody] ClientMap clientMap)
        {
            var ObjResult = _clientBLL.UpdateClient(clientMap);
            if (ObjResult == null)
            {
                return BadRequest();
            }
            return Ok(ObjResult);

        }

    }

}
