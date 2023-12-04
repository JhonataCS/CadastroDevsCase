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
    [Route("api/obter/id")]
    [ApiController]
    public class ObterDadosPorIdController : ControllerBase
    {
        private readonly IDevService _devService;

        public ObterDadosPorIdController(IDevService devService)
        {
            _devService = devService;
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<DevDto>> Getid([FromRoute] string id)
        {
            var devs = _devService.ObterDevPorId(id);

            return Ok(devs);
        }
    }
}
