using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using HomeTask.Data.Interfaces;

namespace HomeTask.Data.Models
{
    /// <summary>
    /// 2 Класс описывающий книгу
    /// </summary>
    public class Book : IBook
    {
        //public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string author { get; set; }
        [Required]
        public string genre { get; set; }

    }
}
