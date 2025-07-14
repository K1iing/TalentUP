using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentUP.Models.Task
{
    public record TaskResponseDTO
    {
        public int Id { get; set; }
        public string DescricaoTask { get; set; }
        public string Status { get; set; }
        public string NomeCriador { get; set; }

        public string NomeAjudante { get; set; }
    }   
}