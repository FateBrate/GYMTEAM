//using GymTeam.Data;
//using GymTeam.Helper.AutentifikacijaAutorizacija;
//using GymTeam.Helper;
//using GymTeam.LoginModels;
//using Microsoft.AspNetCore.Mvc;
//using static GymTeam.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
//using GymTeam.Models;

//namespace GymTeam.Controllers
//{
//    [Route("[controller]/[action]")]

//    [ApiController]
//    public class AutentifikacijaController : ControllerBase
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public AutentifikacijaController(ApplicationDbContext dbContext)
//        {
//            this._dbContext = dbContext;   
//        }

//        [HttpPost]
//        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
//        {

//            Korisnik logiraniKorisnik = _dbContext.Korisnik
//                    .FirstOrDefault(k =>
//                    k.email != null && k.email == x.email && k.lozinka == x.lozinka);

//            if (logiraniKorisnik == null)
//            {

//                return new LoginInformacije(null);
//            }


//            string randomString = TokenGenerator.Generate(10);


//            var noviToken = new AutentifikacijaToken()
//            {
//                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
//                vrijednost = randomString,
//                korisnik = logiraniKorisnik,
//                vrijemeEvidentiranja = DateTime.Now
//            };

//            _dbContext.Add(noviToken);
//            _dbContext.SaveChanges();


//            return new LoginInformacije(noviToken);
//        }

//        [HttpPost]
//        public ActionResult Logout()
//        {
//            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

//            if (autentifikacijaToken == null)
//                return Ok();

//            _dbContext.Remove(autentifikacijaToken);
//            _dbContext.SaveChanges();
//            return Ok();

//        }

//        [HttpGet]
//        public ActionResult<AutentifikacijaToken> Get()
//        {
//            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

//            return autentifikacijaToken;
//        }
//    }
//}
using GymTeam.Data;
using GymTeam.LoginModels;
using GymTeam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static GymTeam.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using GymTeam.Helper.AutentifikacijaAutorizacija;
using GymTeam.Helper;

[Route("[controller]/[action]")]
[ApiController]
public class AutentifikacijaController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public AutentifikacijaController(ApplicationDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    [HttpPost]
    public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
    {
        Korisnik logiraniKorisnik = _dbContext.Korisnik
            .FirstOrDefault(k =>
                k.email != null && k.email == x.email && k.lozinka == x.lozinka);

        if (logiraniKorisnik == null)
        {
            return new LoginInformacije(null);
        }
        string randomString = TokenGenerator.Generate(10);
        var noviToken = new AutentifikacijaToken()
        {
            ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            vrijednost = randomString,
            korisnik = logiraniKorisnik,
            vrijemeEvidentiranja = DateTime.Now
        };

        _dbContext.Add(noviToken);
        _dbContext.SaveChanges();


        return new LoginInformacije(noviToken);
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
    //[HttpGet]
    //[Authorize] // Protect this endpoint with JWT authentication
    //public ActionResult<AutentifikacijaToken> Get()
    //{
    //    string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
    //    // Access the token value from the request headers and remove the "Bearer " prefix

    //    AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

    //    return autentifikacijaToken;
    //}


    //private string GenerateJwtToken(Korisnik korisnik)
    //{
    //    // Generate a secure random key with 128 bits (16 bytes)
    //    byte[] keyBytes = new byte[16];
    //    using (var rng = new RNGCryptoServiceProvider())
    //    {
    //        rng.GetBytes(keyBytes);
    //    }

    //    // Convert the key to Base64 string
    //    string jwtSecret = Convert.ToBase64String(keyBytes);

    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var claims = new[]
    //    {
    //    new Claim(ClaimTypes.NameIdentifier, korisnik.id.ToString()),
    //    new Claim(ClaimTypes.Name, korisnik.email),
    //};

    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(claims),
    //        Expires = DateTime.UtcNow.AddDays(7), // Set the token expiration
    //        SigningCredentials = creds
    //    };

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    var tokenString = tokenHandler.WriteToken(token);

    //    return tokenString;
    //}

    //private string GenerateJwtToken(Korisnik korisnik)
    //{
    //    string jwtSecret = _configuration["JwtSecret"]; // Get the JWT secret from configuration
    //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var claims = new[]
    //    {
    //        new Claim(ClaimTypes.NameIdentifier, korisnik.id.ToString()),
    //        new Claim(ClaimTypes.Name, korisnik.email),
    //    };

    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(claims),
    //        Expires = DateTime.UtcNow.AddDays(7), // Set the token expiration
    //        SigningCredentials = creds
    //    };

    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    var tokenString = tokenHandler.WriteToken(token);

    //    return tokenString;
    //}
}

