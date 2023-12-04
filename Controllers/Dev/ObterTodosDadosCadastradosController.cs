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
    [Route("api/obter")]
    [ApiController]
    public class ObterTodosDadosCadastradosController : ControllerBase
    {
        private readonly IDevService _devService;

        public ObterTodosDadosCadastradosController(IDevService devService)
        {
            _devService = devService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DevDto>> Obter()
        {
            var devs = _devService.ObterTodosDevs();

            return Ok(devs);
        }


    }
}
