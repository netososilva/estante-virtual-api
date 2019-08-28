using EstanteVirtual.Model;

namespace EstanteVirtual.Repository.Interfaces
{
    public interface IUserDao
    {
        User Login(Login login);
    }
}
