using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TalentUP.Models.Colaborador;

namespace TalentUP.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }
        public string DescricaoTask { get; set; }

        public string Status { get; set; }

         // 🔵 Quem criou a task
        public int CriadorId { get; set; }

        [ForeignKey("CriadorId")]
        public Colaborador.Colaborador Criador { get; set; }

        // 🟢 Quem ajudou na task
        public int AjudanteId { get; set; }

        [ForeignKey("AjudanteId")]
        public Colaborador.Colaborador Ajudante { get; set; }



        
    }
}