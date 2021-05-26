using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data.Repositories;
using Library.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private GenreRepository _genre;

        public GenreController(LIBRARYContext context)
        {
            _genre = new GenreRepository(context);
        }
        /// <summary>
        /// Получить жанры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerator<Genre> GetGenre()
        {
            return _genre.GetGenres();
        }

        /// <summary>
        /// Получить статистику по жанру
        /// </summary>
        /// <param name="id"> id жанра</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public int Get(int id)
        {
            return _genre.GetStatistics(id);
        }

        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genre">жанр который надо добавить</param>
        [HttpPost]
        public Genre PostGenre([FromBody] Genre genre)
        {
            return _genre.AddGenre(genre);
        }
    }
}
