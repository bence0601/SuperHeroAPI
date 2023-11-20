using SuperHeroAPI.Models;

namespace SuperHeroAPI.Services
{
    public interface ISuperHeroService
    {
        Task<List<Superhero>> GetAllHeroes();
        Task<Superhero> GetSuperHeroById(int id);
        Task<List<Superhero>> AddHero(Superhero hero);
        Task<List<Superhero>> UpdateHero(int id, Superhero newHero);

        Task<List<Superhero>> DeleteSuperHero(int id);
    }
}
