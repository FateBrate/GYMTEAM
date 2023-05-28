using GymTeam.Data;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AdresaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<Adresa> Add([FromBody] AdresaAddVM x)
        {
            var adresa = new Adresa
            {
                NazivUlice = x.NazivUlice,
                nazivGrada = x.nazivGrada,
                postanskiBroj = x.postanskiBroj
            };

            _dbContext.Add(adresa);
            _dbContext.SaveChanges();

            return adresa;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Adresa
                .OrderBy(a => a.id)
                .Select(a => new AdresaGetVM
                {
                    id = a.id,
                    nazivGrada = a.nazivGrada,
                    NazivUlice = a.NazivUlice,
                    postanskiBroj = a.postanskiBroj
                })
                .Take(100)
                .ToList();

            return Ok(data);
        }
    }
}
