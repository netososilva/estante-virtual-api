using System.Linq;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Context;
using EstanteVirtual.Repository.Interfaces;

namespace EstanteVirtual.Repository
{
    public class UserDao : IUserDao
    {
        private readonly BaseContext _baseContext;

        public UserDao(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public User Login(Login login)
        {
            var registeredLogin = _baseContext.Logins
                .FirstOrDefault(l => l.Email.Equals(login.Email));

            if (registeredLogin == null ||
                !IsPasswordCorrect(login.Password, registeredLogin.Password))
                return null;

            var registeredUser = _baseContext.Users
                .FirstOrDefault(user => user.Login.Id == registeredLogin.Id);

            return registeredUser;            
        }

        private bool IsPasswordCorrect(string password, string registeredPassword)
        {
            return password.Equals(registeredPassword);
        }
    }
}
