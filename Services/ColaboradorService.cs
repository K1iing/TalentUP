

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models.Colaborador;

namespace TalentUP.Services
{
    public class ColaboradorService
    {
        private readonly AppDbContext _context;

        public ColaboradorService(AppDbContext context)
        {
            _context = context;
        }


        //Cria um novo colaborador com pontuação 0 passando os dados do DTO
        public async Task<Colaborador> addColaborador(ColaboradorCreateDTO dto)
        {
            var colaborador = new Colaborador
            {
                Nome = dto.nome,
                Pontuacao = 0

            };

            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
            return colaborador;
        }

        public async Task<List<Colaborador>> getColaboradores() {

            return await _context.Colaboradores.ToListAsync();

        }
    }
}