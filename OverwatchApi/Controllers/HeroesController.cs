using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OverwatchApi.Models;
using OverwatchApi.Models.RepositoryInterfaces;

namespace OverwatchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroRepository _heroRepo;

        public HeroesController(IHeroRepository repo)
        {
            _heroRepo = repo;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IEnumerable<Hero> GetHeroes()
        {
            return _heroRepo.GetAll().OrderBy(t => t.Name);
        }

        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Hero> GetHero(int id)
        {
            Hero hero = _heroRepo.GetHeroBy(id);
            if (hero == null)
                return NotFound();
            return hero;
        }
    }
}