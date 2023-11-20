using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;


namespace SuperHeroAPI.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        public DataContext _context;
        public static List<Superhero> SuperHeroes = new List<Superhero>();


        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Superhero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }


        public async Task<Superhero> GetSuperHeroById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<List<Superhero>> AddHero(Superhero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<Superhero>> UpdateHero(int id, Superhero newHero)
        {
            var oldHero = await _context.SuperHeroes.FindAsync(id);
            oldHero.ID = newHero.ID;
            oldHero.Name = newHero.Name;
            oldHero.FirstName = newHero.FirstName;
            oldHero.LastName = newHero.LastName;
            oldHero.Place = newHero.Place;

            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<Superhero>> DeleteSuperHero(int id)
        {
            var HeroToDelete = await _context.SuperHeroes.FindAsync(id);
            if (HeroToDelete == null)
            {
                return null;
            }
            _context.SuperHeroes.Remove(HeroToDelete);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
