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
    [Route("api/alterar")]
    [ApiController]
    public class AlterarController : ControllerBase
    {
        private readonly IDevService _devService;

        public AlterarController(IDevService devService)
        {
            _devService = devService;
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult<IEnumerable<DevDto>> AlterarUsuario([FromBody] DevDto dadosParaCadastrar, [FromRoute] string id)
        {
            var devs = _devService.AlterarDev(id, dadosParaCadastrar);

            return Ok(devs);
        }
    }
}
