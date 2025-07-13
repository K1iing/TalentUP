using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentUP.Models.Badge
{
    public class BadgeEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int ColaboradorId { get; set; }
       
    }
}