


using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models.Colaborador;

namespace TalentUP.Services
{
    public class ColaboradorService
    {
        private readonly AppDbContext _context;
        private readonly BadgeService _badgeService;

        public ColaboradorService(AppDbContext context, BadgeService badgeService)
        {
            _context = context;
            _badgeService = badgeService;
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


        //Retorna uma lista com todos os colaboradores
        public async Task<List<Colaborador>> getColaboradores()
        {

            return await _context.Colaboradores
                         .Include(c => c.Badges)
                         .ToListAsync();

        }

        public async Task<Colaborador> updateColaborador(int id, String nome)
        {

            var entidade = await _context.Colaboradores.FindAsync(id);

            entidade.Nome = nome;

            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<Colaborador> deleteColaborador(int id)
        {

            var entidade = await _context.Colaboradores.FindAsync(id);

            _context.Colaboradores.Remove(entidade);

            await _context.SaveChangesAsync();

            return entidade;
        }


        public async Task<bool> adicionarPontosTotal(int colaboradorId, int pontos)
        {
            var colaborador = await _context.Colaboradores
                                   .Include(c => c.Badges)
                                   .FirstOrDefaultAsync(M => M.Id == colaboradorId);

            colaborador.Pontuacao += pontos;


            if (colaborador.Pontuacao >= 10)
            {
                bool jaTemBadge = colaborador.Badges.Any(b => b.Nome == "Pontual");
                
                if (!jaTemBadge)
                {
                    var badges = await _badgeService.addBadgesColaborador("Pontual", "Você alcançou 10 pontos", colaborador.Nome);
                    colaborador.Badges.Add(badges);
                    await _context.SaveChangesAsync();
                }

            }

            return true;
        }



    }
}