using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TalentUP.Models;
using TalentUP.Models.Task;
using TalentUP.Services;

namespace TalentUP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }


        [HttpPost]
        public async Task<IActionResult> addTask(TaskCreateDTO dto)
        {
            if (String.IsNullOrWhiteSpace(dto.DescricaoTask))
            {
                return BadRequest("Está nulo ou vazio");
            }
            var dados = await _taskService.addNewTask(dto);

            return Ok(dados);
        }


        [HttpPut("{taskId}/helper")]
        public async Task<IActionResult> AssignHelperToTask(int taskId, [FromBody] HelperDTO dto)
        {
            try
            {
                var updatedTask = await _taskService.helpTask(taskId, dto.NomeAjudante);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{taskId}/finishTask")]
        public async Task<IActionResult> finishTask(int taskId, [FromBody] FinishDTO dto)
        {
            try
            {
                var updatedTask = await _taskService.finishTask(taskId, dto.NomeCriador);
                return Ok(updatedTask);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}