using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
