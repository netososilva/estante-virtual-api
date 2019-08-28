using System.Collections.Generic;
using EstanteVirtual.Bo.Interfaces;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Interfaces;

namespace EstanteVirtual.Bo
{
    public class AuthorBo : IAuthorBo
    {
        private readonly IAuthorDao _authorDao;

        public AuthorBo(IAuthorDao authorDao)
        {
            _authorDao = authorDao;
        }

        public Author Get(int id)
        {
            return _authorDao.Get(id);
        }

        public List<Author> List(string search = null)
        {
            return _authorDao.List(search);
        }
    }
}
