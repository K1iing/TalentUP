using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentUP.Models.Pontuacao
{
    public class PontuacaoEntity
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }

        public String Tipo { get; set; }

        public String Descricao { get; set; }

        public int ValorPontos { get; set; }

     
    }
}