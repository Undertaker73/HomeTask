using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data.Models;

namespace Library.Data.Repositories
{
    public class GenreRepository
    {
        private readonly LIBRARYContext _library;

        public GenreRepository(LIBRARYContext context)
        {
            _library = context;
        }
        /// <summary>
        /// Добавить жанр
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public Genre AddGenre(Genre genre)
        {
            DimGenre newGenre = new DimGenre {GenreName = genre.GenreName};
            var l = _library.DimGenres.Add(newGenre);
            _library.SaveChanges();
            genre.GenreId = l.Entity.GenreId;
            return genre;
        }

        /// <summary>
        /// Получить все жанры
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Genre> GetGenres()
        {
            return _library.DimGenres.Select(g => new Genre {GenreId = g.GenreId, GenreName = g.GenreName}).GetEnumerator();
        }

        /// <summary>
        /// Возврат статистики по жанру
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetStatistics(int id)
        {
            return _library.DimGenres.Find(id).Books.Count;
        }
    }
}
