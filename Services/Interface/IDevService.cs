using CadastroDevs.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDevs.Services.Interface
{
    public interface IDevService
    {
        Task<List<DevResponseDto>>ObterTodosDevs();
        Task<DevResponseDto> ObterDevPorId(string id);
        Task<string> CadastrarDev(DevDto dadosDevCadastro);
        Task<string> AlterarDev(string id, DevDto dadosDevAlteracao);
    }
}
