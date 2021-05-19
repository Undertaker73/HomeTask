using System.Collections.Generic;
using System.Linq;

namespace Library.Data.Repositories
{
    public class BookRepository
    {
        private readonly LIBRARYContext _library;

        public BookRepository(LIBRARYContext context)
        {
            _library = context;
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book AddBook(Book book)
        {
            var b = _library.Books.Add(book);
            _library.SaveChanges();
            return b.Entity;
        }

        /// <summary>
        /// Изменить жанры книги
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public Book UpdateGenresBook(Book book)
        {
            Book updatebook = _library.Books.Find(book.BookId);
            if (updatebook == null)
            {
                return null;
            }
            updatebook.Genres = book.Genres;
            _library.SaveChanges();
            return updatebook;
        }



        /// <summary>
        /// Удалить книгу по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteBook(int id)
        {
            var deleteBook = _library.Books.Find(id);
            if (deleteBook == null)
            {
                return "The book isn't found";
            }
            int countBooks = _library.LibraryCards.Where(b => b.BookBookId == id).Count();
            if (countBooks > 0)
            {
                return "The book is issued by reader";
            }
            _library.Books.Remove(deleteBook);
            _library.SaveChanges();
            return "The book was deleted";
        }

        /// <summary>
        /// Удалить книгу по жанру
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public IEnumerator<Book> GetBooksByGenre(int id)
        {
            return _library.DimGenres.Find(id).Books.GetEnumerator();
        }
        /// <summary>
        /// Получить книги по автору
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public IEnumerator<Book> GetBooksByAuthor(Author author)
        {
            var authors = _library.Authors.Where(b => (b.LastName == author.LastName && author.LastName != null) || (b.MiddleName == author.MiddleName && author.MiddleName != null) || (b.FirstName == author.FirstName && author.FirstName != null));
            if (authors == null)
            {
                return null;
            }
            return authors.FirstOrDefault().Books.GetEnumerator();
        }
    }
}
