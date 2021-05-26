using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using Library.Data.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookRepository _book;

        public BookController(LIBRARYContext context)
        {
            _book = new BookRepository(context);
        }

        /// <summary>
        /// Получить книги по жанру
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerator<Book> GetBooksByGenre(int id)
        {
            return _book.GetBooksByGenre(id);
        }

        /// <summary>
        /// Получить книги по автору
        /// </summary>
        /// <returns></returns>
        [HttpGet("{author}")]
        public IEnumerator<Book> GetBooksByAuthor(Author author)
        {
            return _book.GetBooksByAuthor(author);
        }

        /// <summary>
        /// Изменить жанры у книги
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut]
        public Book AddGenres([FromBody] Book book)
        {
            return _book.UpdateGenresBook(book);
        }

        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public Book PostBook([FromBody] Book book)
        {
            return _book.AddBook(book);
        }

        /// <summary>
        /// Удалить книгу 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            switch (_book.DeleteBook(id))
            {
                case "The book isn't found":
                    return NotFound();
                case "The book is issued by reader":
                    return BadRequest();
                case "The book was deleted":
                    return Ok();
                default:
                    return BadRequest();
            }
        }
    }
}
