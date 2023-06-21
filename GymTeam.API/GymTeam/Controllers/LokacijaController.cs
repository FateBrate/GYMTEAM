using GymTeam.Data;
using GymTeam.Helper;
using GymTeam.Moduls;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokacijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
     public LokacijaController(ApplicationDbContext dbContext)
        {
            this._dbcontext = dbContext;
        }
        [HttpPost]
        public Lokacija Add([FromBody]LokacijaAddVM x)
        {
            Lokacija lokacija = new Lokacija
            {
                naziv = x.naziv,
                adresaId = x.adresaId,
                latitude= x.latitude,   
                longitude=x.longitude
            };
               if(x.slika!=null)
            {
                byte[] imageByte = x.slika.GetImage();
                lokacija.slika = imageByte;
            }
            _dbcontext.Add(lokacija);
            _dbcontext.SaveChanges();
            return lokacija;
        
        }
        [HttpGet]
        public ActionResult<IEnumerable<LokacijaGetVM>> GetAll()
        {
            var data = _dbcontext.Lokacija
                .Where(s => s.slika != null)
                .OrderBy(s => s.naziv)
                .Select(s => new LokacijaGetVM
                {
                    id = s.id,
                    naziv = s.naziv,
                    latitude = s.latitude,
                    longitude = s.longitude,
                    slika = Convert.ToBase64String(s.slika),
                    adresaId = s.adresaId
                })
                .Take(10)
                .ToList();

            return Ok(data);
        }
        [HttpGet("GetbyId")]
        public ActionResult GetById(int id)
        {
            var lokacija = _dbcontext.Lokacija.Find(id);
            if (lokacija != null)
                return Ok(lokacija);
            else throw new Exception("Lokacija sa tim id-em ne postoji");
        }
        [HttpGet("GetSlikaById")]
        public ActionResult GetNewsImage(int id)
        {
            byte[]? slika = _dbcontext.Lokacija.Find(id)?.slika;

            if (slika == null)
                return BadRequest();

            return File(slika, "image/*");
        }
        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            var lokacija = _dbcontext.Lokacija.Find(id);
            if (lokacija != null)
            {
                _dbcontext.Lokacija.Remove(lokacija);
                _dbcontext.SaveChanges();
                return Ok(true);
            }
            throw new Exception("Lokacija sa tim id-em ne postoji");
        }
    }
}
