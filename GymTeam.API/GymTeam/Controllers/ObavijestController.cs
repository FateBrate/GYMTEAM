using GymTeam.Data;
using GymTeam.Helper;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObavijestController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public ObavijestController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        
        [HttpPost]
        public  Obavijest Add([FromBody]ObavijestVM x)
        {
            if (ModelState.IsValid)
            {
                Obavijest obavijest = new Obavijest
                {
                    datumObjave = DateTime.Now,
                    tip = x.tip,
                    sadrzaj = x.sadrzaj,
                    korisnikId = x.korisnikId,
                    naslov = x.naslov,
                    
                };    
                if(x.slika!=null)
                {
                    byte[] imageByte = x.slika.GetImage();
                    obavijest.slika = imageByte;
                }
                _dbContext.Add(obavijest);
                _dbContext.SaveChanges();
                return obavijest;
            }
            else throw new Exception("Greska");
         
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbContext.Obavijest.ToList();
            return Ok(data);
        }

        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var obavijest = _dbContext.Obavijest.Find(id);
            if (obavijest != null)
                return Ok(obavijest);
            else
                throw new Exception("Greska");
        }
        [HttpGet("GetSlikaById")]
        public ActionResult GetNewsImage(int id)
        {
            byte[]? slika = _dbContext.Obavijest.Find(id)?.slika;

            if (slika == null)
                return BadRequest();

            return File(slika, "image/*");
        }

        [HttpDelete]
        public ActionResult RemovebyId(int id)
            
        {
            var obavijest=_dbContext.Obavijest.Find(id);
            if (obavijest != null)
            {
                _dbContext.Obavijest.Remove(obavijest);
                _dbContext.SaveChanges();
                return Ok();
            }
            throw new Exception("Greska");

        }
    }
}
