using System.Collections.Generic;
using EstanteVirtual.Model;

namespace EstanteVirtual.Bo.Interfaces
{
    public interface IUserBookBo
    {
        void Remove(int idUser, int idBook);
        void Insert(int idUser, int idBook);
        List<Book> BooksOfUser(int idUser, string search = null);
        List<Book> BooksOfUserIfNotExistsInLibrary(int idUser);
    }
}
