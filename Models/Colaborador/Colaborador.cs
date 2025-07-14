using TalentUP.Models.Badge;

namespace TalentUP.Models.Colaborador
{
    public class Colaborador
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Pontuacao { get; set; } = 0;

        public List<BadgeEntity> Badges { get; set; } = new List<BadgeEntity>();

        public List<TaskEntity> TasksCriadas { get; set; } = new List<TaskEntity>();
        public List<TaskEntity> TasksAjudadas { get; set; } = new List<TaskEntity>();


    }
}