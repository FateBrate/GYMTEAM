﻿using GymTeam.Data;
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
            };
            _dbcontext.Add(lokacija);
            _dbcontext.SaveChanges();
            return lokacija;
        
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = _dbcontext.Lokacija.OrderBy(s => s.naziv).Select(s => new LokacijaGetVM()
            {
                id = s.id,
                naziv = s.naziv,
                adresaId = s.adresaId,
            }).Take(10);
            return Ok(data.ToList());
        }
    }
}
