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
    public class PeopleController : ControllerBase
    {
        private static List<People> _readers = new List<People>() { new People() { name = "Гжегож", surname = "Бженчишчикевич", patronymic = "Якубович", dateOfBirth = new DateTime(2003, 1, 20)},
                                                                    new People() { name = "Джон", surname = "Доу", patronymic = "Томас", dateOfBirth = new DateTime(2001, 2, 15)},
                                                                    new People() { name = "Василий", surname = "Пупкин", patronymic = "Иванович", dateOfBirth = new DateTime(1993, 12, 2)}};

        /// <summary>
        /// 2 Получить всех читателей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<People> GetAll()
        {
            return _readers;
        }

        /// <summary>
        /// 2 Получить читателя по имени
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public List<People> GetByName(string name)
        {
            return _readers.FindAll(r=>r.name==name);
        }

        /// <summary>
        /// 2. Добавить читателя
        /// </summary>
        /// <param name="newReader"></param>
        /// <returns></returns>
        [HttpPost]
        public List<IPeople> PostAddReader([FromBody] People newReader)
        {
            _readers.Add(newReader);
            return _readers.Cast<IPeople>().ToList();
        }

        /// <summary>
        /// 2 Удалить читателя
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteReader([FromBody] People reader)
        {
             if (_readers.First(r=>(r.name == reader.name && r.surname == reader.surname && r.patronymic == reader.patronymic)) == null)
             {
                 return NotFound();
             }
             _readers.RemoveAll(r => (r.name == reader.name && r.surname == reader.surname && r.patronymic == reader.patronymic));
             return Ok();
        }
    }
}
