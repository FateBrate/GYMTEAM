using GymTeam.Data;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{

    [Route("api/[controller]")]

    [ApiController]

    public class AdresaControler : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public AdresaControler(ApplicationDbContext dbcontext)
        {
            this._dbcontext= dbcontext;
        }
        [HttpPost]
     public Adresa Add([FromBody]AdresaAddVM x)
        {
            var adresa = new Adresa
            {
                NazivUlice= x.NazivUlice,
                nazivGrada= x.nazivGrada,
                postanskiBroj= x.postanskiBroj,
            };
            _dbcontext.Add(adresa);
            _dbcontext.SaveChanges();
            return adresa;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbcontext.Adresa.OrderBy(a => a.id).Select(a => new AdresaGetVM()
            {
                id = a.id,
                nazivGrada = a.nazivGrada,
                NazivUlice = a.NazivUlice,
                postanskiBroj = a.postanskiBroj
            }).Take(100);
            return Ok(data.ToList());
        }
 
    }
}
