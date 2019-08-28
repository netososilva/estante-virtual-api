using System.Collections.Generic;
using System.Linq;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Context;
using EstanteVirtual.Repository.Interfaces;

namespace EstanteVirtual.Repository
{
    public class AuthorDao : IAuthorDao
    {
        private readonly BaseContext _context;

        public AuthorDao(BaseContext context)
        {
            this._context = context;
        }

        public Author Get(int id)
        {
            return _context.Authors.FirstOrDefault(author => author.Id == id);
        }

        public List<Author> List(string search = null)
        {
            if (string.IsNullOrWhiteSpace(search)) return _context.Authors.ToList();

            return _context.Authors
                .Where(author => author.Name.Contains(search))
                .ToList();
        }
    }
}
