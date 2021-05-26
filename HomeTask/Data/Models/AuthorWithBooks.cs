using System.Collections.Generic;

namespace Library.Data.Models
{
    public class AuthorWithBooks
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
