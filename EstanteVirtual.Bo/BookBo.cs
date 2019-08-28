using System.Collections.Generic;
using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Interfaces;

namespace EstanteVirtual.Bo
{
    public class BookBo : IBookBo
    {
        private readonly IBookDao _bookDao;

        public BookBo(IBookDao bookDao)
        {
            this._bookDao = bookDao;
        }

        public Book Get(int id)
        {
            return _bookDao.Get(id);
        }

        public void Insert(Book book)
        {
            _bookDao.Insert(book);
        }

        public IList<Book> List(string search = null)
        {
            return _bookDao.List();
        }
    }
}
