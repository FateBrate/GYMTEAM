using GymTeam.Data;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CjenovnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CjenovnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Cjenovnik Add([FromBody] CjenovnikAddVM x ) 
        {
            var cjenovnik = new Cjenovnik
            {
                nazivStavke = x.nazivStavke,
                opis = x.opis,
                cijena = x.cijena,
                korisnikId = x.korisnikId,

            };
            _dbContext.Add( cjenovnik );
            _dbContext.SaveChanges();
            return cjenovnik;
        }
        [HttpPut]
        public Cjenovnik Update([FromBody] CjenovnikAddVM x,int id)
        {
            var plan = _dbContext.Cjenovnik.Find(id);
            if (plan != null)
            {
                plan.nazivStavke=x.nazivStavke;
                plan.opis = x.opis;
                plan.cijena= x.cijena;
                _dbContext.Update( plan );
                _dbContext.SaveChanges();
                return plan;
            }
            else 
            throw new  Exception("Nevazeci id");
        }
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var data = _dbContext.Cjenovnik.OrderBy(k=>k.cijena).ToList();
            return Ok(data);
        }
        [HttpGet("GetById")]
        public Cjenovnik GetbyId(int id)
        {
            if (id == null)
                throw new Exception("Nevazeci id");
            
                var plan = _dbContext.Cjenovnik.Find(id);
            return plan;
        }
        
    }
}
