using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Repositories;
using Library.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonRepository _personRepository;

        public PersonController(LIBRARYContext context)
        {
            _personRepository = new PersonRepository(context);
        }

        /// <summary>
        /// Получить книги читателя
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerator<Book> GetBooks(int id)
        {
            return _personRepository.GetReaderBooks(id);
        }

        /// <summary>
        /// Изменить информацию про пользователя
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public Person UpdateReader([FromBody]Person reader)
        {
            return _personRepository.UpdateReader(reader);
        }

        /// <summary>
        /// Добавить книгу 
        /// </summary>
        /// <param name="newReader"></param>
        /// <returns></returns>
        [HttpPost("takebook")]
        public ReaderWithBooks TakeBook([FromBody]LibraryCard libraryCard)
        {
            return _personRepository.TakeBook(libraryCard);
        }

        /// <summary>
        /// Добавить читателя
        /// </summary>
        /// <param name="newReader"></param>
        /// <returns></returns>
        [HttpPost("postreader")]
        public Person PostReader([FromBody]Person newReader)
        {
            return _personRepository.AddReader(newReader);
        }

        /// <summary>
        /// Удалить читателя по Id
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteReaderById(int id)
        {
            switch (_personRepository.DeleteReaderById(id))
            {
                case "Reader isn't found":
                    return NotFound();
                case "Reader was deleted":
                    return Ok();
                default:
                    return BadRequest();
            }
        }

        /// <summary>
        /// Удалить читателя по ФИО
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpDelete("deletereaderbyfio")]
        public IActionResult DeleteReaderByFIO([FromBody] Person reader)
        {
            switch (_personRepository.DeleteReaderByFIO(reader))
            {
                case "Reader isn't found":
                    return NotFound();
                case "Reader was deleted":
                    return Ok();
                default:
                    return BadRequest();
            }
        }

        /// <summary>
        /// Возврат книги
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpDelete("returnbook")]
        public ReaderWithBooks ReturnBook([FromBody] LibraryCard libraryCard)
        {
            return _personRepository.ReturnBook(libraryCard);
        }
    }
}
