using GymTeam.Data;
using GymTeam.Models;
using GymTeam.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GymTeam.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class VideoZapisController : ControllerBase
    {
        public readonly ApplicationDbContext _dbcontext;
        public VideoZapisController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public Videozapis Add([FromBody] VideozapisAddVM x)
        {

            var korisnik = new Videozapis
            {
                opis = x.opis,
                trajanje = x.trajanje,
                videoTreningId = x.videoTreningId

            };
            _dbcontext.Add(korisnik);
            _dbcontext.SaveChanges();
            return korisnik;
        }
        [HttpGet]
        public ActionResult GetAll()
        {

            var data = _dbcontext.Videozapis.OrderBy(k => k.id).Select(k => new VideozapisGetAllVM()
            {
                id = k.id,
                opis = k.opis,
                trajanje = k.trajanje,
                videoTreningId = k.videoTreningId

            }).Take(100);
            return Ok(data.ToList());
        }

        [HttpPut]
        public Videozapis Edit(VideoZapisUVM video, int id)
        {
            var model = _dbcontext.Videozapis.Find(id);
            if (model != null)
            {
                model.opis = video.opis;
                model.trajanje = video.trajanje;
                model.videoTreningId = video.videoTreningId;
                _dbcontext.Videozapis.Update(model);
                _dbcontext.SaveChanges();
                return model;

            }
            throw new Exception("Korisnik sa tim id-em ne postoji");
        }

        [HttpDelete]
        public ActionResult DeleteById(int id)
        {
            var model = _dbcontext.Videozapis.Find(id);
            if (model != null)
            {
                _dbcontext.Videozapis.Remove(model);
                _dbcontext.SaveChanges();
                return Ok("Korisnik je obrisan");
            }
            throw new Exception("Videozapis sa tim id-em ne postoji");
        }
    }
}
    

