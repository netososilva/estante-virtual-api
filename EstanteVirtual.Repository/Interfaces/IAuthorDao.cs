using System.Collections.Generic;
using EstanteVirtual.Model;

namespace EstanteVirtual.Repository.Interfaces
{
    public interface IAuthorDao
    {
        Author Get(int id);
        List<Author> List(string search = null);
    }
}
