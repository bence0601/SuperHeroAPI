using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<Superhero> SuperHeroes = new List<Superhero>
        {
            new Superhero
                {   ID = 1,
                    Name = "Spider Man",
                    FirstName = "Peter",
                    LastName = "Parker",
                    Place = "New York" },

            new Superhero
            {   ID = 2,
            Name = "Iron Man",
            FirstName = "Tony",
            LastName = "Stark",
            Place = "Malibu" }

        };

        [HttpGet("AllSuperHeroes")]
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes()
        {

            return Ok(SuperHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHeroById(int id)
        {
            var hero = SuperHeroes.Find(x => x.ID == id);

            if (hero == null)
            {
                return NotFound("Sorry, this superhero does not exist");
            }

            return Ok(hero);
        }

        [HttpPost("AddHero")]
        public async Task<ActionResult<Superhero>> AddSuperHero(Superhero hero)
        {

            SuperHeroes.Add(hero);
            return Ok(hero);
        }

        [HttpPut("UpdateHero")]
        public async Task<ActionResult<List<Superhero>>> UpdateSuperHero(int id, Superhero hero)
        {
            var oldHero = SuperHeroes.Find(x => x.ID == id);
            oldHero = hero;
            //oldHero.ID = hero.ID;
            //oldHero.Name = hero.Name;
            //oldHero.FirstName = hero.FirstName;
            //oldHero.LastName = hero.LastName;
            //oldHero.Place = hero.Place;

            return Ok(SuperHeroes);
        }
    }
}
