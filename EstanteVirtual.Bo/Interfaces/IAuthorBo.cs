using System.Collections.Generic;
using EstanteVirtual.Model;

namespace EstanteVirtual.Bo.Interfaces
{
    public interface IAuthorBo
    {
        Author Get(int id);
        List<Author> List(string search = null);
    }
}
