using Microsoft.AspNetCore.Mvc;
using TalentUP.Models.Colaborador;
using TalentUP.Services;

namespace TalentUP.Controllers
{
    //Indica que é uma API Controller
    [ApiController]

    //Passa a rota é o controller é o nome da entidade
    [Route("[controller]")]

    //Traz as configurações do ControllerBase
    public class ColaboradorController : ControllerBase
    {
        //Faz a injeção de dependencia trazendo o Services
        private readonly ColaboradorService _colaboradorService;

        public ColaboradorController(ColaboradorService colaboradorService)
        {
            _colaboradorService = colaboradorService;
        }


        //Cria um novo colaborador
        [HttpPost]
        public async Task<IActionResult> addColaborador(ColaboradorCreateDTO dto)
        {
            if (String.IsNullOrWhiteSpace(dto.nome) || dto.nome == "string")
            {
                return BadRequest("Colaborador está nulo ou vazio");
            }

            var criado = await _colaboradorService.addColaborador(dto);

            return Ok(criado);
        }
    }
}