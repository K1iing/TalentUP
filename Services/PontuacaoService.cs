using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Migrations;
using TalentUP.Models.Colaborador;
using TalentUP.Models.Pontuacao;

namespace TalentUP.Services
{
    public class PontuacaoService
    {
        private readonly AppDbContext _context;
        private readonly ColaboradorService _colaboradorService;

        public PontuacaoService(AppDbContext context, ColaboradorService colaboradorService)
        {
            _context = context;
             _colaboradorService = colaboradorService;
        }

        


        public async Task<PontuacaoEntity> adicionarPontuacao(String nome, String tipo, String descricao, int pontos)
        {
            var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(m => m.Nome == nome);

            int id = colaborador.Id;

            var entidade = new PontuacaoEntity
            {
                ColaboradorId = id,
                Tipo = tipo,
                Descricao = descricao,
                ValorPontos = pontos
            };

            await _colaboradorService.adicionarPontosTotal(id, pontos);
            



                _context.PontuacaoEntities.Add(entidade);

                await _context.SaveChangesAsync();

                return entidade;
            
        }
    }
}