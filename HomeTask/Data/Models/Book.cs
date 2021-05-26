using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

#nullable disable

namespace Library
{
    public partial class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Name { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<DimGenre> Genres { get; set; }
    }
}
