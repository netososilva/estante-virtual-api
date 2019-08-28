using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Interfaces;
using EstanteVirtual.Bo.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;

namespace EstanteVirtual.Bo
{
    public class LoginBo : ILoginBo
    {
        private readonly IUserDao _userDao;
        private readonly AppSettings _appSettings;

        public LoginBo(IUserDao userDao, IOptions<AppSettings> appSettings)
        {
            _userDao = userDao;
            _appSettings = appSettings.Value;
        }

        public User Authenticate(Login login)
        {
            var user = _userDao.Login(login);

            if (user == null)
                return null;

            user.Token = GetToken(user);

            return user;
        }

        private string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
