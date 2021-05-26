using System;
using System.ComponentModel.DataAnnotations;


namespace Library
{
    public partial class LibraryCard
    {
        [Required]
        public int BookBookId { get; set; }
        [Required]
        public int PersonPersonId { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual Book BookBook { get; set; }
        public virtual Person PersonPerson { get; set; }
    }
}
