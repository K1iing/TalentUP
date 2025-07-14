using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models;
using TalentUP.Models.Task;

namespace TalentUP.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;
        private readonly ColaboradorService _colaboradorService;

        public TaskService(AppDbContext context, ColaboradorService colaboradorService)
        {
            _context = context;
            _colaboradorService = colaboradorService;
        }

        public async Task<TaskResponseDTO> addNewTask(TaskCreateDTO dto)
        {
            var colaborador = await _context.Colaboradores.Include(c => c.TasksCriadas).FirstOrDefaultAsync(m => m.Nome == dto.NomeCriador);

            if (colaborador == null)
                throw new Exception("Colaborador não encontrado");

            var entidade = new TaskEntity
            {
                DescricaoTask = dto.DescricaoTask,
                Status = dto.Status,
                CriadorId = colaborador.Id
            };
            colaborador.TasksCriadas.Add(entidade);
            _context.taskEntities.Add(entidade);
            await _context.SaveChangesAsync();

            return new TaskResponseDTO
            {
                Id = entidade.Id,
                DescricaoTask = entidade.DescricaoTask,
                Status = entidade.Status,
                NomeCriador = colaborador.Nome
            };


        }

        public async Task<TaskResponseDTO> helpTask(int taskId, string nomeAjudante)
        {
            var task = await _context.taskEntities
            .Include(t => t.Criador)
            .Include(t => t.Ajudante)
            .FirstOrDefaultAsync(t => t.Id == taskId);

            if (task == null)
                throw new Exception("Task não encontrada");

            var ajudante = await _context.Colaboradores.FirstOrDefaultAsync(c => c.Nome == nomeAjudante);

            if (ajudante == null)
                throw new Exception("Ajudante não encontrado");

            task.AjudanteId = ajudante.Id;
            task.Ajudante = ajudante;

            await _context.SaveChangesAsync();

            return new TaskResponseDTO
            {
                Id = task.Id,
                DescricaoTask = task.DescricaoTask,
                Status = task.Status,
                NomeCriador = task.Criador.Nome,
                NomeAjudante = ajudante.Nome
            };
        }

    }


}