using System.Collections.Generic;
using System.Linq;
using EstanteVirtual.Model;
using EstanteVirtual.Repository.Context;
using EstanteVirtual.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EstanteVirtual.Repository
{
    public class UserBookDao : IUserBookDao
    {
        private BaseContext _baseContext { get; set; }

        public UserBookDao(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }

        public List<Book> BooksOfUser(int idUser, string search = null)
        {
            var registeredUser = _baseContext.Users
                .Include(user => user.Books)
                .FirstOrDefault(user => user.Id == idUser);

            if (registeredUser == null)
                return new List<Book>();

            var books = _baseContext.Books
                .Where(book => registeredUser.Books
                    .Any(x => x.BookId == book.Id))
                .Include(x => x.Author)
                .ToList();

            if (!string.IsNullOrWhiteSpace(search))
                books = books
                    .Where(book => book.Name.ToUpper()
                        .Contains(search.ToUpper()) ||
                        book.Author.Name.ToUpper()
                        .Contains(search.ToUpper()))
                    .ToList();

            return books;
        }

        public List<Book> BooksOfUserIfNotExistsInLibrary(int idUser)
        {
            var registeredUser = _baseContext.Users
                .Include(user => user.Books)
                .FirstOrDefault(user => user.Id == idUser);

            if (registeredUser == null)
                return new List<Book>();

            var books = _baseContext.Books
                .Where(book => !registeredUser.Books
                    .Any(x => x.BookId == book.Id))
                .Include(x => x.Author)
                .ToList();

            return books;
        }

        public void Insert(int idUser, int idBook)
        {
            var user = _baseContext.Users.FirstOrDefault(x => x.Id == idUser);

            if (user == null) return;

            var book = _baseContext.Books.FirstOrDefault(x => x.Id == idBook);

            if (book == null) return;

            var userBook = new UserBook
            {
                Book = book,
                User = user,
                BookId = idBook,
                UserId = idUser
            };

            if (user.Books == null)
                user.Books = new List<UserBook>();

            user.Books.Add(userBook);
            _baseContext.SaveChanges();
        }

        public void Remove(int idUser, int idBook)
        {
            var user = _baseContext.Users
                .Include(x => x.Books)
                .FirstOrDefault(x => x.Id == idUser);

            if (user == null) return;

            var book = user.Books
                .FirstOrDefault(x => x.BookId == idBook);

            if (book == null) return;

            user.Books.Remove(book);
            _baseContext.SaveChanges();
        }
    }
}
