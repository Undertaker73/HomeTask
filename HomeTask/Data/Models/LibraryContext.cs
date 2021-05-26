using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

#nullable disable

namespace Library
{
    public partial class LIBRARYContext : DbContext
    {
        public LIBRARYContext()
        {
        }

        public LIBRARYContext(DbContextOptions<LIBRARYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<DimGenre> DimGenres { get; set; }
        public virtual DbSet<LibraryCard> LibraryCards { get; set; }
        public virtual DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("author");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("middle_name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("book");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_book_author");
                entity.HasMany(g => g.Genres) // has many Books
                      .WithMany(b => b.Books) // with many Genres
                      .UsingEntity<Dictionary<string, object>>("book_genre_lnk",
                        y => y.HasOne<DimGenre>().WithMany().HasForeignKey(nameof(DimGenre.GenreId)),
                        x => x.HasOne<Book>().WithMany().HasForeignKey(nameof(Book.BookId)),
                        z => z.ToTable("book_genre_lnk"));
            });

           

            modelBuilder.Entity<DimGenre>(entity =>
            {
                entity.HasKey(e => e.GenreId);

                entity.ToTable("dim_genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("genre_name");

                entity.HasMany(b => b.Books) // has many Books
                      .WithMany(g => g.Genres) // with many Genres
                      .UsingEntity<Dictionary<string, object>>("book_genre_lnk",
                        x => x.HasOne<Book>().WithMany().HasForeignKey(nameof(Book.BookId)),
                        y => y.HasOne<DimGenre>().WithMany().HasForeignKey(nameof(DimGenre.GenreId)),
                        z => z.ToTable("book_genre_lnk"));
            });

            modelBuilder.Entity<LibraryCard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("library_card");

                entity.Property(e => e.BookBookId).HasColumnName("book_book_id");

                entity.Property(e => e.PersonPersonId).HasColumnName("person_person_id");

                entity.Property(e => e.ReturnDate)
                    .HasColumnType("date")
                    .HasColumnName("return_date");

                entity.HasOne(d => d.BookBook)
                    .WithMany()
                    .HasForeignKey(d => d.BookBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_library_card_book");

                entity.HasOne(d => d.PersonPerson)
                    .WithMany()
                    .HasForeignKey(d => d.PersonPersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_library_card_person");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("middle_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
