using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreSuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName="Clark", LastName="Kent", Name="SuperMan", Place="Metropolis"},
            new SuperHero {Id = 2, FirstName="Peter", LastName="Parker", Name="SpiderMan", Place="NYC"},
            new SuperHero {Id = 3, FirstName="Bruce", LastName="Wayne", Name="Batman", Place="Gotham"}
        };

        [HttpGet]
        public ActionResult<List<SuperHero>> GetAllPreSuperHeroes()
        {
            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroById(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            return Ok(hero);
        }
    }
}
