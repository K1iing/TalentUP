using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentUP.Models.Badge
{
    public record BadgeCreateDTO
    {
        public string NomeBadges { get; set; }
        public string Descricao { get; set; }
        public string NomeColaborador { get; set; }
    }
}