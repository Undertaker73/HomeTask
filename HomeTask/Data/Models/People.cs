using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.Data.Models
{
    public class People
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
