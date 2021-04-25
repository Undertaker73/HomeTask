using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTask.Data.Models;
using HomeTask.Data.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> _books = new List<Book>() { new Book() { name = "Зов ктулху", genre = "ужасы", author = "Лавкрафт"},
                                                              new Book() { name = "Властелин колец", genre = "фэнтези", author = "Толкин"},
                                                              new Book() { name = "Дюна", genre = "фантастика", author = "Герберт"} };
        /// <summary>
        /// 2. Получить все книги
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> GetAll()
        {
            return _books;
        }

        /// <summary>
        /// 2.Получить книгу по автору
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        [HttpGet("{author}")]
        public List<Book> GetBookByAuthor(string author)
        {
            return _books.FindAll(b => (b.author == author));
        }

        /// <summary>
        /// 2. Добавить книгу
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public List<IBook> PostAddBook([FromBody] Book book)
        {
            _books.Add(book); 
            return _books.Cast<IBook>().ToList();
        }

        /// <summary>
        /// 2. Удалить книгу по авторуи названию
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteBook([FromBody]Book book)
        {
            if (_books.First(b => (b.name == book.name && b.author == book.author)) == null)
            {
                return NotFound();
            }
            _books.RemoveAll(b => (b.name == book.name && b.author == book.author));
            return Ok();
        }
    }
}
