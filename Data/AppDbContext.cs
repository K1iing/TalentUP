using Microsoft.EntityFrameworkCore;
using TalentUP.Models.Badge;
using TalentUP.Models.Colaborador;
using TalentUP.Models.Pontuacao;

namespace TalentUP.Data
{
    //Herda as configurações do DbContext
    public class AppDbContext : DbContext
    {
        //Cria um construtor com as opções do DbContext
        public AppDbContext(DbContextOptions options) : base(options) { }

        //Seta a entidade no DbContext criando o construtor
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<PontuacaoEntity> PontuacaoEntities { get; set; }

        public DbSet<BadgeEntity> BadgeEntities { get; set; }
    }
}