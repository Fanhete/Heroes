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
    public class HeroesController : ControllerBase
    {
        private readonly IHeroesService _heroService;

        public HeroesController(IHeroesService heroService)
        {
            _heroService = heroService;
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var result = await _heroService.GetbyIdAsync(id);

            if (result == null) 
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HeroisModel hero)
        {
            var result = await _heroService.AddAsync(hero);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HeroisModel hero)
        {
            var result = await _heroService.UpdateAsync(hero);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _heroService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _heroService.GetAllAsync();
            return Ok(result);

        }

    }
}
