using System.Collections.Generic;
using EstanteVirtual.Model;

namespace EstanteVirtual.Bo.Interfaces
{
    public interface IBookBo
    {
        void Insert(Book book);
        Book Get(int id);
        IList<Book> List(string search = null);
    }
}
