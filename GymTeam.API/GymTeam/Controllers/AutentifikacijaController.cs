using GymTeam.Data;
using GymTeam.Helper.AutentifikacijaAutorizacija;
using GymTeam.Helper;
using GymTeam.LoginModels;
using Microsoft.AspNetCore.Mvc;
using static GymTeam.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
using GymTeam.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymTeam.Controllers
{
    [Route("[controller]/[action]")]

    [ApiController]
    public class AutentifikacijaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AutentifikacijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            Korisnik logiraniKorisnik = _dbContext.Korisnik
        .FirstOrDefault(k =>
        k.email != null && k.email == x.email && k.lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, logiraniKorisnik.email),
        
             };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-secret-key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration date
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(tokenString);
            //Korisnik logiraniKorisnik = _dbContext.Korisnik
            //    .FirstOrDefault(k =>
            //    k.email != null && k.email == x.email && k.lozinka == x.lozinka);

            //if (logiraniKorisnik == null)
            //{

            //    return new LoginInformacije(null);
            //}


            //string randomString = TokenGenerator.Generate(10);


            //var noviToken = new AutentifikacijaToken()
            //{
            //    ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            //    vrijednost = randomString,
            //    korisnik = logiraniKorisnik,
            //    vrijemeEvidentiranja = DateTime.Now
            //};

            //_dbContext.Add(noviToken);
            //_dbContext.SaveChanges();


            //return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }
    }
}

