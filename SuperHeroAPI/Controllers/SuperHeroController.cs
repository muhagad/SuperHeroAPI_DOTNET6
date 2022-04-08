using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        //private static List<SuperHero> heroes = new List<SuperHero>
        //    {
        //        new SuperHero {
        //            Id = 1,
        //            Name = "Spider man",
        //            FirestName="Peter",
        //            LastName="Parker",
        //            Place="Detroit",
        //        },
        //        new SuperHero {
        //            Id=2, 
        //            Name="Iron man", 
        //            FirestName="Tony", 
        //            LastName="Stark", 
        //            Place="Long Island"
        //        }
        //    };

        private readonly SuperHeroDbContext _context;

        public SuperHeroController(SuperHeroDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            //var hero = heroes[id];
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("hero not found");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await  _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> updateHero(SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(request.Id);
            if (hero == null)
                return BadRequest("Hero not found");
            hero.Name = request.Name;
            hero.FirestName = request.FirestName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found");
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
