using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;
using SuperHeroAPI.Services;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet("AllSuperHeroes")]

        private readonly SuperHeroService _superHeroService;

        public SuperHeroController(SuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {
            var result = _superHeroService.GetAllHeroes();
            return Ok(SuperHeroService.SuperHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHeroById(int id)
        {
            var hero = SuperHeroService.SuperHeroes.Find(x => x.ID == id);

            var result = _superHeroService.GetSuperHeroById(id);
            return Ok(result);
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult<List<Superhero>>> AddSuperHero(Superhero hero)
        {
            var result = _superHeroService.AddHero(hero);
            return Ok(result);
        }

        [HttpPut("UpdateHero/{id}")]
        public async Task<ActionResult<List<Superhero>>> UpdateSuperHero(int id, Superhero hero)
        {
            var result = _superHeroService.UpdateHero(id, hero);
            return Ok(result);
        }

        [HttpDelete("deleteHero/{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHeroById(int id)
        {
            var result = _superHeroService.DeleteSuperHero(id);
            return Ok(result);
        }

    }
}
