using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models.Badge;

namespace TalentUP.Services
{
    public class BadgeService
    {

        public readonly AppDbContext _context;
        public BadgeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BadgeEntity> addBadgesColaborador(String nomeBadges, String descricao, String nomeColaborador)
        {

            var colaborador = await _context.Colaboradores.FirstOrDefaultAsync(M => M.Nome == nomeColaborador);

            int id = colaborador.Id;

            var badges = new BadgeEntity
            {
                Nome = nomeBadges,
                Descricao = descricao,
                ColaboradorId = id

            };

            _context.BadgeEntities.Add(badges);

            await _context.SaveChangesAsync();

            return badges;
        }


    }
}