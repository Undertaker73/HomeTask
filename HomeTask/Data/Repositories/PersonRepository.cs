using System.Collections.Generic;
using System.Linq;
using Library.Data.Models;


namespace Library.Data.Repositories
{

    public class PersonRepository
    {
        private readonly LIBRARYContext _library;

        public PersonRepository(LIBRARYContext context)
        {
            _library = context;
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Person AddReader(Person reader) {
            var p = _library.People.Add(reader);
            _library.SaveChanges();
            return p.Entity;
        }

        /// <summary>
        /// Изменить информацию у пользователя
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public IEnumerator<Book> GetReaderBooks(int id)
        {
            return _library.LibraryCards.Where(p => p.PersonPersonId == id).Select(b => b.BookBook).GetEnumerator();
        }

        /// <summary>
        /// Изменить информацию у пользователя
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public Person UpdateReader(Person reader)
        {
            var updateReader = _library.People.Find(reader.PersonId);
            if (updateReader == null)
            {
                return null;
            }
            updateReader.BirthDate = reader.BirthDate;
            updateReader.FirstName = reader.FirstName;
            updateReader.LastName = reader.LastName;
            updateReader.MiddleName = reader.MiddleName;
            _library.SaveChanges();
            return updateReader;
        }

        /// <summary>
        /// Удалить пользователя по Id
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public string DeleteReaderById(int id)
        {
            var deleteReader = _library.People.Find(id);
            if (deleteReader == null)
            {
                return "Reader isn't found";
            }
            _library.LibraryCards.ToList().RemoveAll(r => r.PersonPersonId == id);
            _library.People.Remove(deleteReader);
            _library.SaveChanges();
            return "Reader was deleted";
        }

        /// <summary>
        /// Удалить пользователя по ФИО
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public string DeleteReaderByFIO(Person reader)
        {
            var deleteReader =_library.People.Find(reader.FirstName, reader.LastName, reader.MiddleName);
            if (deleteReader == null)
            {
                return "Reader isn't found";
            }
            _library.LibraryCards.ToList().RemoveAll(r => r.PersonPersonId == deleteReader.PersonId);
            _library.People.Remove(deleteReader);
            _library.SaveChanges();
            return "Reader was deleted";
        }

        /// <summary>
        /// Пользователь берет книгу
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public ReaderWithBooks TakeBook(LibraryCard card)
        {
            Person reader = _library.People.Find(card.PersonPersonId);
            Book book = _library.Books.Find(card.BookBookId);
            if (reader == null || book == null)
            {
                return null;
            }
            _library.LibraryCards.Add(card);
            _library.SaveChanges();
            ReaderWithBooks readerBooks = new ReaderWithBooks
            {
                Reader = reader,
                Books = _library.LibraryCards.Where(lc => lc.PersonPersonId == card.PersonPersonId).Select(b => b.BookBook).ToList()
            };
            return readerBooks;
        }

        /// <summary>
        /// Пользователь вернул книгу
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public ReaderWithBooks ReturnBook(LibraryCard card)
        {
            var returnBook = _library.LibraryCards.Find(card.BookBookId, card.PersonPersonId);
            if (returnBook == null)
            {
                return null;
            }
            _library.LibraryCards.Remove(returnBook);
            _library.SaveChanges();
            ReaderWithBooks reader = new ReaderWithBooks 
            {
                Reader = returnBook.PersonPerson,
                Books = _library.LibraryCards.Where(lc => lc.PersonPersonId == card.PersonPersonId).Select(b=>b.BookBook).ToList()
            };
            return reader;
        }
    }
}
