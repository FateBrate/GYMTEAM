using GymTeam.Data;
using GymTeam.LoginModels;
using GymTeam.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace GymTeam.Helper.AutentifikacijaAutorizacija
{
    public static class MyAuthTokenExtension
    {
        public class LoginInformacije
        {

            [JsonIgnore]
            public Korisnik korisnickiNalog => autentifikacijaToken?.korisnik;
            public AutentifikacijaToken autentifikacijaToken { get; set; }

            public bool isLogiran => korisnickiNalog != null;
            public LoginInformacije(AutentifikacijaToken autentifikacijaToken)
            {
                this.autentifikacijaToken = autentifikacijaToken;
            }

        }


        public static LoginInformacije GetLoginInfo(this HttpContext httpContext)
        {
            var token = httpContext.GetAuthToken();

            return new LoginInformacije(token);
        }

        public static AutentifikacijaToken GetAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.GetMyAuthToken();
            ApplicationDbContext db = httpContext.RequestServices.GetService<ApplicationDbContext>();

            AutentifikacijaToken korisnickiNalog = db.AutentifikacijaToken
                .Include(s => s.korisnik)
                .SingleOrDefault(x => token != null && x.vrijednost == token);

            return korisnickiNalog;
        }


        public static string GetMyAuthToken(this HttpContext httpContext)
        {
            string token = httpContext.Request.Headers["autentifikacija-token"];
            return token;
        }
    }
}

