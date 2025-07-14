using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentUP.Data;
using TalentUP.Models;
using TalentUP.Models.Colaborador;
using TalentUP.Models.Task;

namespace TalentUP.Services
{
    public class TaskService
    {
        private readonly AppDbContext _context;
        private readonly ColaboradorService _colaboradorService;

        private readonly BadgeService _badgeService;

        public TaskService(AppDbContext context, ColaboradorService colaboradorService, BadgeService badgeService)
        {
            _context = context;
            _colaboradorService = colaboradorService;
            _badgeService = badgeService;
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

            ajudante.Pontuacao += 10;

            if (ajudante.Pontuacao >= 250)
            {
                await _badgeService.addBadgesColaborador("Mago Lendário do Sistema", "Você atingiu 250 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 225)
            {
                await _badgeService.addBadgesColaborador("Dragão dos Algoritmos", "Você atingiu 225 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 200)
            {
                await _badgeService.addBadgesColaborador("Bruxo das Nuvens", "Você atingiu 200 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 175)
            {
                await _badgeService.addBadgesColaborador("Guardião dos Servidores", "Você atingiu 175 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 150)
            {
                await _badgeService.addBadgesColaborador("Conjurador de Scripts", "Você atingiu 150 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 125)
            {
                await _badgeService.addBadgesColaborador("Cavaleiro do Código", "Você atingiu 125 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 100)
            {
                await _badgeService.addBadgesColaborador("Sábio dos Dados", "Você atingiu 100 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 75)
            {
                await _badgeService.addBadgesColaborador("Arqueiro da Rede", "Você atingiu 75 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 50)
            {
                await _badgeService.addBadgesColaborador("Escudeiro do Debug", "Você atingiu 50 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 25)
            {
                await _badgeService.addBadgesColaborador("Aprendiz de Byte", "Você atingiu 25 pontos!", nomeAjudante);
            }
            else if (ajudante.Pontuacao >= 10)
            {
                await _badgeService.addBadgesColaborador("Iniciante da Matrix", "Você atingiu 10 pontos!", nomeAjudante);
            }

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