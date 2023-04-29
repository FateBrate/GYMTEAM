using GymTeam.Data;
using GymTeam.Helper;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class KorisnikController : Controller
    {
        public readonly ApplicationDbContext _dbcontext;
        public KorisnikController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public Korisnik Add([FromBody]KorisnikAddVM x)
        {

            var korisnik = new Korisnik
            {
                ime = x.ime,
                prezime = x.prezime,
                email = x.email,
                lozinka=x.lozinka,
                datumRodjenja = x.datumRodjenja,
                brojTelefona=x.brojTelefona,
                lokacijaId=x.lokacijaId,
                roleId = x.roleID,
               
            };
            if (x.slika == null)
            {
                byte[] imageByte = x.slika.GetImage();
                korisnik.slika = imageByte;
            }

            if (korisnik.roleId!=2)
                {
                korisnik.lokacijaId = null;
                }
            
            _dbcontext.Add(korisnik);
            _dbcontext.SaveChanges();
            return korisnik;
        }
        [HttpGet]
        public ActionResult<List<Korisnik>> GetAll(string? ime_prezime)
        {

            var data = _dbcontext.Korisnik.Where(korisnik => (
             string.IsNullOrEmpty(ime_prezime) ||
             (korisnik.ime + " " + korisnik.prezime).ToLower().StartsWith(ime_prezime.ToLower()) ||
             (korisnik.prezime + " " + korisnik.ime).ToLower().StartsWith(ime_prezime.ToLower())))
              .OrderByDescending(k => k.id)
              .AsQueryable();

            return data.Take(50).ToList();

        }
        [HttpGet("GetById")]
        public ActionResult GetById(int id)
        {
            var korisnik = _dbcontext.Korisnik.Find(id);
            if (korisnik != null)
                return Ok(korisnik);
            else throw new Exception("Korisnik sa tim id-em ne postoji"); 
        }
        [HttpGet("GetSlikaById")]
        public ActionResult GetNewsImage(int id)
        {
            byte[]? slika = _dbcontext.Korisnik.Find(id)?.slika;

            if (slika == null)
                return BadRequest();

            return File(slika, "image/*");
        }
        [HttpPut("ChangePhoto")]
        public ActionResult<Korisnik> editPhoto(string  file,int id)
        {
            var thiskorisnik=_dbcontext.Korisnik.Find(id);
            if (thiskorisnik != null)
            {
                if (file != null)
                    thiskorisnik.slika = file.GetImage();
                else throw new Exception("Greška neispravan file");
            }
            else throw new Exception("Greska sa id-em korisnika");
            _dbcontext.Korisnik.Update(thiskorisnik);
            _dbcontext.SaveChanges();
            return Ok(thiskorisnik);
            

        }
        [HttpPut]
        public Korisnik Edit(KorisnikUVM korisnik,int id)
        {
            var thiskorisnik=_dbcontext.Korisnik.Find(id);
            if(thiskorisnik!=null)
            {
                thiskorisnik.ime = korisnik.ime;
                thiskorisnik.prezime = korisnik.prezime;
                thiskorisnik.email = korisnik.email;
                thiskorisnik.lozinka = korisnik.lozinka;
                thiskorisnik.datumRodjenja = korisnik.datumRodjenja;
                thiskorisnik.brojTelefona = korisnik.brojTelefona;              
                _dbcontext.Korisnik.Update(thiskorisnik);
                _dbcontext.SaveChanges();
                return thiskorisnik;
            }
            throw new Exception("Korisnik sa tim id-em ne postoji");
        }
        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            var thiskorisnik = _dbcontext.Korisnik.Find(id);
            if(thiskorisnik != null)
            {
                _dbcontext.Korisnik.Remove(thiskorisnik);
                _dbcontext.SaveChanges();
                return Ok(true);
            }
            throw new Exception("Korisnik sa tim id-em ne postoji");
        }


    }
}
