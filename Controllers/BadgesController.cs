using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TalentUP.Models.Badge;
using TalentUP.Services;

namespace TalentUP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadgesController : ControllerBase
    {
        private readonly BadgeService _badgeservice;

        public BadgesController(BadgeService badgeService)
        {
            _badgeservice = badgeService;
        }

        [HttpPost]
        public async Task<IActionResult> addBadges(BadgeCreateDTO dto)
        {
            if (String.IsNullOrWhiteSpace(dto.NomeBadges))
            {
                return BadRequest("Está nulo ou vazio");
            }

            
            
            return Ok("entidade");
        }
        
    }
}