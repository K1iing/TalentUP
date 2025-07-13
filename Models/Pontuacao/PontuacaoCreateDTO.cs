using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentUP.Models.Pontuacao
{
    public record PontuacaoCreateDTO
    {
        public string nome { get; set; }
        public string tipo { get; set; }

        public string descricao { get; set; }

        public int pontos { get; set; }

    }
}