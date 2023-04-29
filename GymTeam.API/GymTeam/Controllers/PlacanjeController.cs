using GymTeam.Data;
using GymTeam.Models;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacanjeController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public PlacanjeController(ApplicationDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        [HttpPost]
        public Placanje Add([FromBody] PlacanjeAddVM r)
        {
            Placanje placanje = new Placanje
            {
                tip = r.tip,
                iznos = r.iznos,
            };
            _dbcontext.Add(placanje);
            _dbcontext.SaveChanges();
            return placanje;
        }
            [HttpGet]
            public ActionResult GetAll()
        {
            var podaci = _dbcontext.Placanje.OrderBy(g => g.tip).Select(g => new PlacanjeAddVM()
            {
                
                tip = g.tip,
                iznos = g.iznos,
            }).Take(100);
            return Ok(podaci.ToList());
        }


    }
}
