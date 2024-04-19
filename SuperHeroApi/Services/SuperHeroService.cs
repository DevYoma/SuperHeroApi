using Microsoft.EntityFrameworkCore;

namespace SuperHeroApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;  
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }
        public async Task<SuperHero?> GetSingleHero(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return null;
            }

            return hero;
        }
        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            if (id <= 0)
            {
                return null;
            }

            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync(); // returns the array/list
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }
        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                return null; // good time to use Custom Exception errors
            }

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
