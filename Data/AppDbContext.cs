using Microsoft.EntityFrameworkCore;
using TalentUP.Models;
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

        public DbSet<TaskEntity> taskEntities { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔵 Relacionamento: Criador → TasksCriadas
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Criador)
                .WithMany(c => c.TasksCriadas)
                .HasForeignKey(t => t.CriadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🟢 Relacionamento: Ajudante → TasksAjudadas
            modelBuilder.Entity<TaskEntity>()
                .HasOne(t => t.Ajudante)
                .WithMany(c => c.TasksAjudadas)
                .HasForeignKey(t => t.AjudanteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}