using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.Data.Repositories;
using Library.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorRepository _authorRepository;

        public AuthorController(LIBRARYContext context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        /// <summary>
        /// Возвращает всех авторов
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public IEnumerable<Author> GetAll()
        {
            return _authorRepository.GetAuthors();
        }

        /// <summary>
        /// Получить книги автора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("books/{id}")]
        public IEnumerator<Book> GetAuthorBooks(int id)
        {
            return _authorRepository.GetAuthorBooks(id);
        }

        /// <summary>
        /// Добавить автора
        /// </summary>
        /// <param name="author"></param>
        [HttpPost("postauthor")]
        public AuthorWithBooks Post([FromBody] Author author)
        {
            return _authorRepository.AddAuthor(author);
        }


        /// <summary>
        /// Удалить автора
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            switch (_authorRepository.DeleteAuthor(id))
            {
                case "Author is not found": 
                    return NotFound();
                case "Author with books can't be deleted": 
                    return BadRequest();
                case "Author has been deleted": 
                    return Ok();
                default:
                    return BadRequest();
            }
        }
    }
}
