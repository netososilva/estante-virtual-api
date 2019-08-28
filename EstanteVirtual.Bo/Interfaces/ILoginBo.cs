using System;
using EstanteVirtual.Model;

namespace EstanteVirtual.Bo.Interfaces
{
    public interface ILoginBo
    {
        User Authenticate(Login login);
    }
}
