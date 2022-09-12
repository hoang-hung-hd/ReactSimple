 using Backend_Web.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend_Web.Services
{
    public class Authentication : TokenService
    {
        protected AppDbContext _appDbContext;
        private readonly IConfiguration _iconfiguration;
        public Authentication(AppDbContext appDbContext, IConfiguration iconfiguration)
        {
            _appDbContext = appDbContext;
            _iconfiguration = iconfiguration;
        }

        Dictionary<string, string> UsersRecords = new Dictionary<string, string>
        {
            { "user1","password1"},
            { "user2","password2"},
            { "user3","password3"},
        };



        public Tokens Authenticate(Login loginModel)
        {
            IEnumerable<User> usersRecord = _appDbContext.Users;
            /*if (!usersRecord.Any(x => x.Email == loginModel.Email && x.Password == loginModel.Password))
            {
                return null;
            }*/
            if (!UsersRecords.Any(x => x.Key == loginModel.Name && x.Value == loginModel.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            string key = _iconfiguration.GetValue<string>("JWT:Key");
            var tokenKey = Encoding.UTF8.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, loginModel.Name)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
