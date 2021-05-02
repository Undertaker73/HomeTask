using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HomeTask.Data.Interfaces;

namespace HomeTask.Data.Models
{   /// <summary>
    /// 2. Класс описывающий читателя
    /// </summary>
    public class People : IPeople
    {
        //public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string patronymic { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime dateOfBirth { get; set; }

    }
}
