using System.Collections.Generic;
using System.Linq;
using Library.Data.Models;

namespace Library.Data.Repositories
{
    public class AuthorRepository
    {
        private readonly LIBRARYContext _library;

        public AuthorRepository(LIBRARYContext context)
        {
            _library = context;
        }


        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public AuthorWithBooks AddAuthor(Author author)
        {
            var a =_library.Authors.Add(author);
            _library.SaveChanges();
            AuthorWithBooks newAuthor = new AuthorWithBooks
            {
                AuthorId = a.Entity.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName,
                MiddleName = author.MiddleName,
                Books = author.Books
            };
            return newAuthor;
        }

        /// <summary>
        /// Получить всех авторов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Author> GetAuthors()
        {
            return _library.Authors;
        }

        /// <summary>
        /// Функция возвращает книги автора (знаю она не совсем правильная, просьба помочь свести 3 таблицы бд с помощью linq)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerator<Book> GetAuthorBooks(int id)
        {
            Author author = _library.Authors.Find(id);
            if (author == null)
            {
                return null;
            }
            return _library.Books.Where(b=>b.AuthorId == id).GetEnumerator();
        }

        /// <summary>
        /// Функция удаляет автора и на выход получает сообщение об успешности или ошибке
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteAuthor(int id)
        {
            var deleteAuthor = _library.Authors.Find(id);
            if (deleteAuthor == null) {
                return "Author is not found";
            }
            if (deleteAuthor.Books.Count()>0)
            {
                return "Author with books can't be deleted";
            }
            _library.Authors.Remove(deleteAuthor);
            _library.SaveChanges();
            return "Author has been deleted";
        }
    }
}
