using GymTeam.Data;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivatniTrenerController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public PrivatniTrenerController(ApplicationDbContext dbContext)
        {
            this._dbcontext= dbContext;
        }
        [HttpPost]
        public PrivatniTrener Add([FromBody]PrivatniTrenerAddVM z)
        {
            var privatniTrener = new PrivatniTrener
            {
                ime = z.ime,
                prezime = z.prezime,
                slika = z.slika,
                email = z.email,
                brojTelefona = z.brojTelefona,
                adresa = z.adresa,
            };
            _dbcontext.Add(privatniTrener);
            _dbcontext.SaveChanges();
            return privatniTrener;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = _dbcontext.PrivatniTrener.OrderBy(g => g.ime).Select(g => new PrivatniTrenerAddVM()
            {
                
                ime= g.ime,
                prezime= g.prezime,
                slika= g.slika,
                email= g.email,
                brojTelefona= g.brojTelefona,
                adresa= g.adresa,
            }).Take(100);
            return Ok(podaci.ToList());
        }
    }
}
