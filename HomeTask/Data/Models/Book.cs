using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.Data.Models
{
    public class Book
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
