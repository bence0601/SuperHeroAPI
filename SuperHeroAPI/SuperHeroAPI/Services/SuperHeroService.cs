using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;


namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        public DataContext _context;
        public static List<Superhero> SuperHeroes = new List<Superhero>
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

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Superhero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }


        public Superhero GetSuperHeroById(int id)
        {
            return SuperHeroes.Find(x => x.ID == id);
        }

        public List<Superhero> AddHero(Superhero hero)
        {
            SuperHeroes.Add(hero);
            return SuperHeroes;
        }

        public List<Superhero> UpdateHero(int id, Superhero newHero)
        {
            var oldHero = SuperHeroService.SuperHeroes.Find(x => x.ID == id);
            oldHero.ID = newHero.ID;
            oldHero.Name = newHero.Name;
            oldHero.FirstName = newHero.FirstName;
            oldHero.LastName = newHero.LastName;
            oldHero.Place = newHero.Place;

            return SuperHeroes;
        }

        public List<Superhero> DeleteSuperHero(int id)
        {
            var HeroToDelete = SuperHeroService.SuperHeroes.Find(x => x.ID == id);
            if (HeroToDelete == null)
            {
                return null;
            }
            SuperHeroes.Remove(HeroToDelete);
            return SuperHeroes;
        }
    }
}
