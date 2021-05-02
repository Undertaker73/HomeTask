using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace HomeTask.Data.Models
{
    public class BookOnHands
    {
        [Required]
        public Book book { get; set;}
        [Required]
        public People reader {get; set;}
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddTHH:mm:ss.fffzzz")]
        public DateTimeOffset dateOfTaking {get; set;}
    }
}
