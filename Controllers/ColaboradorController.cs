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

        [HttpGet]
        public async Task<IActionResult> getColaboradores()
        {
            var lista = await _colaboradorService.getColaboradores();

            if (lista == null || !lista.Any())
            {
                return NoContent();
            }

            return Ok(lista);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateColaboradores(int id, String nome)
        {
            var update = await _colaboradorService.updateColaborador(id, nome);

            if (update == null)
            {
                return BadRequest();
            }

            return Ok(update);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> updateColaboradores(int id)
        {
            var update = await _colaboradorService.deleteColaborador(id);

            if (update == null)
            {
                return BadRequest();
            }

            return Ok("Usuario removido com sucesso!");
        }
    }
}