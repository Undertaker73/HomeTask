using System.ComponentModel.DataAnnotations;


namespace Library
{
    public partial class BookGenreLnk
    {
        [Required]
        public int BookBookId { get; set; }
        [Required]
        public int GenreGenreId { get; set; }

        public virtual Book BookBook { get; set; }
        public virtual DimGenre GenreGenre { get; set; }
    }
}
