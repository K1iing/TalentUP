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

            var colaborador = await _context.Colaboradores
            .Include(c => c.Badges)
            .FirstOrDefaultAsync(m => m.Nome == nomeColaborador);

            if (colaborador == null)
                throw new Exception("Colaborador não encontrado");


            if (colaborador.Badges.Any(b => b.Nome == nomeBadges))
                return null;

            var badge = new BadgeEntity
            {
                Nome = nomeBadges,
                Descricao = descricao,
                ColaboradorId = colaborador.Id
            };

            _context.BadgeEntities.Add(badge);
            await _context.SaveChangesAsync();

            return badge;
        }


    }
}