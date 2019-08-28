using System.Collections.Generic;
using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Interfaces;

namespace EstanteVirtual.Bo
{
    public class UserBookBo : IUserBookBo
    {
        private readonly IUserBookDao _userBookDao;

        public UserBookBo(IUserBookDao userBookDao)
        {
            _userBookDao = userBookDao;
        }

        public List<Book> BooksOfUser(int idUser, string search = null)
        {
            return _userBookDao.BooksOfUser(idUser, search);
        }

        public List<Book> BooksOfUserIfNotExistsInLibrary(int idUser)
        {
            return _userBookDao.BooksOfUserIfNotExistsInLibrary(idUser);
        }

        public void Insert(int idUser, int idBook)
        {
            _userBookDao.Insert(idUser, idBook);
        }

        public void Remove(int idUser, int idBook)
        {
            _userBookDao.Remove(idUser, idBook);
        }
    }
}
