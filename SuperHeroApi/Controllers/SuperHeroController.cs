using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName="Clark", LastName="Kent", Name="SuperMan", Place="Metropolis"},
            new SuperHero {Id = 2, FirstName="Peter", LastName="Parker", Name="SpiderMan", Place="NYC"},
            new SuperHero {Id = 3, FirstName="Bruce", LastName="Wayne", Name="Batman", Place="Gotham"},
            new SuperHero {Id = 4, FirstName="Tony", LastName="Stark", Name="IronMan", Place="Malibu"},
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            await Task.Delay(5000); // simulating a 5secs delay
            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var hero = superHeroes.Find(hero => hero.Id == id);

            if(hero == null || hero.Id > superHeroes.Count)
            {
                return NotFound($"The id with the value {id} does not exist");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            superHeroes.Add(hero);
            return Ok(superHeroes);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, [FromBody]SuperHero request)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var hero = superHeroes.Find(hero => hero.Id == id); 
            if(hero is null)
            {
                return NotFound("Sorry, but this hero doesn't exist");
            }

            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            hero.Name = request.Name;

            return Ok(hero);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if(hero == null)
            {
                return NotFound("Sorry, but this hero does not exist");
            }

            superHeroes.Remove(hero);
            return Ok(hero);
        }
    }
}
