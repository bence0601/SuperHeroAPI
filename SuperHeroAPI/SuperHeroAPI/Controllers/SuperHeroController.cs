using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly ISuperHeroService _IsuperHeroService;

        public SuperHeroController(ISuperHeroService IsuperHeroService)
        {
            _IsuperHeroService = IsuperHeroService;
        }
        [HttpGet("AllSuperHeroes")]
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {
            return await _IsuperHeroService.GetAllHeroes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHeroById(int id)
        {


            var result = await _IsuperHeroService.GetSuperHeroById(id);
            return Ok(result);
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult<List<Superhero>>> AddSuperHero(Superhero hero)
        {
            var result = await _IsuperHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("UpdateHero/{id}")]
        public async Task<ActionResult<List<Superhero>>> UpdateSuperHero(int id, Superhero hero)
        {
            var result = await _IsuperHeroService.UpdateHero(id, hero);
            return Ok(result);
        }

        [HttpDelete("deleteHero/{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHeroById(int id)
        {
            var result = await _IsuperHeroService.DeleteSuperHero(id);
            return Ok(result);
        }

    }
}
