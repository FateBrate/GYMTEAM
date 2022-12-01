using GymTeam.Data;
using GymTeam.Moduls;
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
      
        public IActionResult Post(Adresa adresa)
        {
            return Ok(_dbcontext.Adresa.Add(adresa));
        }
    }
}
