﻿using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul2.Models;
using FIT_Api_Example.Modul2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class OpstinaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public OpstinaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public Opstina Add([FromBody] OpstinaAddVM x)
        {
            var newEmployee = new Opstina
            {
                description = x.opis,
                drzava_id = x.drzava_id,
            };

            _dbContext.Add(newEmployee);
            _dbContext.SaveChanges();
            return newEmployee;
        }

        [HttpGet]
        public List<CmbStavke> GetByDrzava(int drzava_id)
        {
            var data = _dbContext.Opstina.Where(x => x.drzava_id == drzava_id)
                .OrderBy(s => s.description)
                .Select(s => new CmbStavke()
                {
                    id = s.id,
                    opis = s.drzava.naziv + " - " + s.description,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }

        [HttpGet]
        public List<CmbStavke> GetByAll()
        {
            var data = _dbContext.Opstina
                .OrderBy(s => s.description)
                .Select(s => new CmbStavke()
                {
                    id = s.id,
                    opis = s.drzava.naziv + " - " + s.description,
                })
                .AsQueryable();
            return data.Take(100).ToList();
        }
    }
}
