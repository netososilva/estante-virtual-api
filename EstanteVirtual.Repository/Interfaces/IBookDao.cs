using System.Collections.Generic;
using EstanteVirtual.Model;

namespace EstanteVirtual.Repository.Interfaces
{
    public interface IBookDao
    {
        void Insert(Book book);
        Book Get(int id);
        IList<Book> List(string search = null);
    }
}
