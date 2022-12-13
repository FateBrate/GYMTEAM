using GymTeam.Data;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    public class NarudzbaControler : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public NarudzbaControler(ApplicationDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        [HttpPost]
        public Narudzba Add([FromBody]NarduzbaAddVM z)
        {
            var narudzba = new Narudzba
            {
                brojNarudzbe = z.brojNarudzbe,
                datumNarudzbe = z.datumNarudzbe,
                popust=z.popust,
                cijena=z.cijena,
                korisnikID=z.korisnikID,
            };
            _dbcontext.Add(narudzba);
            _dbcontext.SaveChanges();
            return narudzba;
        }
    }
}
