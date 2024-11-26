using HeroesAPI.Data;
using HeroesAPI.Models.Entities;
using HeroesAPI.Repositories.Interfaces;
using HeroesAPI.Services;
using HeroesAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderController : ControllerBase
    {
        private readonly ISuperpoderService _superpoderService;

        public SuperpoderController(ISuperpoderService superpoderService)
        {
            _superpoderService = superpoderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Superpoderes>>> GetAllSuperpoderes()
        {
            
            var superpoderes = _superpoderService.GetAllSuperpoderes();

            return Ok(superpoderes);                     
        }
    }
}
