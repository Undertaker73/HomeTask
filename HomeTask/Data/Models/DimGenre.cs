using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Library
{
    public partial class DimGenre
    {
        public int GenreId { get; set; }
        [Required]
        public string GenreName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
