namespace SuperHeroApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName="Clark", LastName="Kent", Name="SuperMan", Place="Metropolis"},
            new SuperHero {Id = 2, FirstName="Peter", LastName="Parker", Name="SpiderMan", Place="NYC"},
            new SuperHero {Id = 3, FirstName="Bruce", LastName="Wayne", Name="Batman", Place="Gotham"},
            new SuperHero {Id = 4, FirstName="Tony", LastName="Stark", Name="IronMan", Place="Malibu"},
        };

        public List<SuperHero> AddHero(SuperHero hero)
        {
            superHeroes.Add(hero);
            return superHeroes;
        }

        public List<SuperHero>? DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero == null)
            {
                return null; // good time to use Custom Exception errors
            }

            superHeroes.Remove(hero);
            return superHeroes;
        }

        public List<SuperHero> GetAllHeroes()
        {
            return superHeroes;
        }

        public SuperHero? GetSingleHero(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var hero = superHeroes.Find(hero => hero.Id == id);

            if (hero == null || hero.Id > superHeroes.Count)
            {
                return null;
            }

            return hero;
        }

        public List<SuperHero>? UpdateHero(int id, SuperHero request)
        {
            if (id <= 0)
            {
                return null;
            }

            var hero = superHeroes.Find(hero => hero.Id == id);
            if (hero is null)
            {
                return null;
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            return superHeroes;
        }
    }
}
