using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeTask.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookOnHandsController : ControllerBase
    {
        private static List<BookOnHands> _books = new List<BookOnHands>();

        /// <summary>
        /// 2.1 Добавить запись о получении книги
        /// </summary>
        /// <param name="book"></param>
        [HttpPost]
        public List<BookOnHands> PostBookOnHands([FromBody] BookOnHands book)
        {
            _books.Add(book);
            return _books;
        }
    }
}
