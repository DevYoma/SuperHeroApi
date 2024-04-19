using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Services;
//using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            /*await Task.Delay(5000);*/ // simulating a 5secs delay
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<List<SuperHero>>> GetSingleHero(int id)
        {
            var result = await _superHeroService.GetSingleHero(id);

            if(result == null)
            {
                return NotFound($"Hero with {id} not found");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            var result = await _superHeroService.AddHero(hero);

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<SuperHero>> UpdateHero(int id, [FromBody]SuperHero request)
        {
            var result = await _superHeroService.UpdateHero(id, request);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var result = await _superHeroService.DeleteHero(id);

            if (result is null)
            {
                return NotFound("Ooops, Hero not found");
            }
            return Ok(result);
        }
    }
}
