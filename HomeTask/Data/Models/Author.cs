using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Library
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int AuthorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
