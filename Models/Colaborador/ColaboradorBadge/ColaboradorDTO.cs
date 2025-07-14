using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentUP.Models.Badge;
using TalentUP.Models.Task;

namespace TalentUP.Models.Colaborador.ColaboradorBadge
{
    public record ColaboradorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Pontuacao { get; set; }

        public List<BadgeDTO> Badges { get; set; } = new List<BadgeDTO>();
        public List<TaskDTO> TasksCriadas { get; set; } = new List<TaskDTO>();
        public List<TaskDTO> TasksAjudadas { get; set; } = new List<TaskDTO>();
    }
}