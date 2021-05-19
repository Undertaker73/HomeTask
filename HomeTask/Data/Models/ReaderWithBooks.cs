using System.Collections.Generic;

namespace Library.Data.Models
{
    public class ReaderWithBooks
    {
        public Person Reader { get; set; }

        public List<Book> Books { get; set; }
    }
}
