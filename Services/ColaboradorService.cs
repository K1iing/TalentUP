


using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models.Badge;
using TalentUP.Models.Colaborador;
using TalentUP.Models.Colaborador.ColaboradorBadge;
using TalentUP.Models.Task;

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
        public async Task<List<ColaboradorDTO>> getColaboradores()
        {

            var colaboradores = await _context.Colaboradores
                                     .Include(c => c.Badges)
                                     .Include(c => c.TasksCriadas)
                                     .Include(c => c.TasksAjudadas)
                                     .ToListAsync();

            return colaboradores.Select(c => new ColaboradorDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Pontuacao = c.Pontuacao,
                Badges = c.Badges.Select(b => new BadgeDTO
                {
                    Id = b.Id,
                    Nome = b.Nome,
                    Descricao = b.Descricao,
                    ColaboradorId = b.ColaboradorId
                }).ToList(),
                TasksCriadas = c.TasksCriadas.Select(t => new TaskDTO
                {
                    Id = t.Id,
                    DescricaoTask = t.DescricaoTask,
                    Status = t.Status
                }).ToList(),
                TasksAjudadas = c.TasksAjudadas.Select(t => new TaskDTO
                {
                    Id = t.Id,
                    DescricaoTask = t.DescricaoTask,
                    Status = t.Status
                }).ToList()
            }).ToList();

        }


        public async Task<ColaboradorDTO?> getColaboradorById(string nome)
        {
            var colaborador = await _context.Colaboradores
                .Where(c => c.Nome == nome)  
                .Include(c => c.Badges)
                .Include(c => c.TasksCriadas)
                .Include(c => c.TasksAjudadas)
                .FirstOrDefaultAsync();

            if (colaborador == null)
                return null;

            return new ColaboradorDTO
            {
                Id = colaborador.Id,
                Nome = colaborador.Nome,
                Pontuacao = colaborador.Pontuacao,
                Badges = colaborador.Badges.Select(b => new BadgeDTO
                {
                    Id = b.Id,
                    Nome = b.Nome,
                    Descricao = b.Descricao,
                    ColaboradorId = b.ColaboradorId
                }).ToList(),
                TasksCriadas = colaborador.TasksCriadas.Select(t => new TaskDTO
                {
                    Id = t.Id,
                    DescricaoTask = t.DescricaoTask,
                    Status = t.Status
                }).ToList(),
                TasksAjudadas = colaborador.TasksAjudadas.Select(t => new TaskDTO
                {
                    Id = t.Id,
                    DescricaoTask = t.DescricaoTask,
                    Status = t.Status
                }).ToList()
            };
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