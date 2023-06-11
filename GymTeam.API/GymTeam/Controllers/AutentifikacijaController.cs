using GymTeam.Data;
using GymTeam.LoginModels;
using GymTeam.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static GymTeam.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;
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
}

