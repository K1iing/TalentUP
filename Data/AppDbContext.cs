using Microsoft.EntityFrameworkCore;
using TalentUP.Models.Colaborador;

namespace TalentUP.Data
{
    //Herda as configurações do DbContext
    public class AppDbContext : DbContext
    {
        //Cria um construtor com as opções do DbContext
        public AppDbContext(DbContextOptions options) : base(options) { }

        //Seta a entidade no DbContext criando o construtor
        public DbSet<Colaborador> Colaboradores { get; set; }
    }
}