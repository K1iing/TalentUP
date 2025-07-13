using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TalentUP.Models.Pontuacao;
using TalentUP.Services;

namespace TalentUP.Controllers
{
    //Indica que é uma API Controller
    [ApiController]

    //Passa a rota é o controller é o nome da entidade
    [Route("[controller]")]

    public class PontuacaoController : ControllerBase
    {
        private readonly PontuacaoService _pontuacaoService;


        public PontuacaoController(PontuacaoService pontuacaoService)
        {
            _pontuacaoService = pontuacaoService;
        }

        //Adiciona uma pontuação para o colaborador
        [HttpPost]
        public async Task<IActionResult> adicionarPontos(PontuacaoCreateDTO dto)
        {

            if (String.IsNullOrWhiteSpace(dto.nome))
            {
                return NotFound("Nenhum nome foi passado");
            }
            var dados = await _pontuacaoService.adicionarPontuacao(dto.nome, dto.tipo, dto.descricao, dto.pontos);
            return Ok(dados);
            
        }
       
    }
}