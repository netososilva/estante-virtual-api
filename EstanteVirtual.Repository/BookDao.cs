using System.Collections.Generic;
using System.Linq;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Context;
using EstanteVirtual.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstanteVirtual.Repository
{
    public class BookDao : IBookDao
    {
        private readonly BaseContext _context;

        public BookDao(BaseContext context)
        {
            this._context = context;
        }

        public Book Get(int id)
        {
            return _context.Books
                .Include(book => book.Author)
                .FirstOrDefault(book => book.Id == id);
        }

        public void Insert(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public IList<Book> List(string search = null)
        {
            if (string.IsNullOrWhiteSpace(search)) return _context.Books.ToList();

            return _context.Books
                .Where(book => book.Name.Contains(search) || book.Author.Name.Contains(search))
                .ToList();
        }
    }
}
