using GymTeam.Data;
using GymTeam.Models;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
  
       

        public class PlanIshraneControler : ControllerBase
        {
            private readonly ApplicationDbContext _dbcontext;
            public PlanIshraneControler(ApplicationDbContext dbcontext)
            {
                this._dbcontext = dbcontext;
            }
            [HttpPost]
            public PlanIshrane Add([FromBody] PlanIshraneAddVM z)
            {
                var planIshrane = new PlanIshrane
                {
                    naziv = z.naziv,
                    ukupanBrojKalorija = z.ukupanBrojKalorija
                };
                _dbcontext.Add(planIshrane);
                _dbcontext.SaveChanges();
                return planIshrane;
            }
            [HttpGet]
            public ActionResult GetAll()
            {
                var podaci = _dbcontext.PlanIshrane.OrderBy(z => z.id).Select(z => new PlanIshraneGetVM()
                {
                    id = z.id,
                    naziv = z.naziv,
                    ukupanBrojKalorija = z.ukupanBrojKalorija
                }).Take(100);
                return Ok(podaci.ToList());
            }
        }
    }

