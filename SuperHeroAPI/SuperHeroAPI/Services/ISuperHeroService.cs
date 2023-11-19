using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        List<Superhero> GetAllHeroes();
        Superhero GetSuperHeroById(int id);
        List<Superhero> AddHero(Superhero hero);
        List<Superhero> UpdateHero(int id, Superhero newHero);

        List<Superhero> DeleteSuperHero(int id);
    }
}
