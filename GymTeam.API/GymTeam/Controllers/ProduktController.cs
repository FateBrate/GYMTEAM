using GymTeam.Data;
using GymTeam.Models;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public ProduktController(ApplicationDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        [HttpPost]
        public Produkt Add([FromBody] ProduktAddVM z)
        {
            Produkt produkt = new Produkt
            {
                sifraProdukta = z.sifraProdukta,
                naziv = z.naziv,
                kategorija = z.kategorija,
                cijena = z.cijena,
                zemljaPorijekla = z.zemljaPorijekla,
                masa = z.masa
            };
            _dbcontext.Add(produkt);
            _dbcontext.SaveChanges();
            return produkt;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = _dbcontext.Produkt.OrderBy(z => z.naziv).Select(z => new ProduktGetVM()
            {
                id = z.id,
                sifraProdukta = z.sifraProdukta,
                naziv = z.naziv,
                kategorija = z.kategorija,
                cijena = z.cijena,
                zemljaPorijekla = z.zemljaPorijekla,
                masa = z.masa
            }).Take(100);
            return Ok(podaci.ToList());
        }

    }
}
