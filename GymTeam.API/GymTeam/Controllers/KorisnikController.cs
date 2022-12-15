using GymTeam.Data;
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
                putanjaSlike=x.putanjaSlike
            };
        
                if(korisnik.roleId!=2)
                {
                korisnik.lokacijaId = null;
                }
            
            _dbcontext.Add(korisnik);
            _dbcontext.SaveChanges();
            return korisnik;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _dbcontext.Korisnik.OrderBy(k => k.id).Select(k => new KorisnikGetVM()
            {
                id = k.id,
                ime = k.ime,
                prezime = k.prezime,
                email = k.email,
                brojTelefona = k.brojTelefona,              
                lokacijaId= k.lokacijaId,
                roleId=k.roleId,
                role=k.role.ToString()

            }).Take(100);
            return Ok(data.ToList());

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
                thiskorisnik.roleId = korisnik.roleID;
                thiskorisnik.putanjaSlike = korisnik.putanjaSlike;
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
                return Ok("Korisnik je obrisan");
            }
            throw new Exception("Korisnik sa tim id-em ne postoji");
        }


    }
}
