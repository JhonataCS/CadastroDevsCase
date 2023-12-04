using CadastroDevs.Dto;
using CadastroDevs.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDevs.Controllers
{
    [Route("api/cadastrar")]
    [ApiController]
    public class CadastrarController : ControllerBase
    {
        private readonly IDevService _devService;

        public CadastrarController(IDevService devService)
        {
            _devService = devService;
        }

        [HttpPost]
        public ActionResult<IEnumerable<DevDto>> CadastrarUsuario([FromBody] DevDto dadosParaCadastrar)
        {
            var devs = _devService.CadastrarDev(dadosParaCadastrar);

            return Ok(devs);
        }

    }
}
