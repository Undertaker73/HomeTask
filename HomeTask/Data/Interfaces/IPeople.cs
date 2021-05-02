using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.Data.Interfaces
{
    /// <summary>
    /// 2.2.2 Интерфейс для ФИО People
    /// </summary>
    public interface IPeople
    {
        //public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string patronymic { get; set; }
    }
}
