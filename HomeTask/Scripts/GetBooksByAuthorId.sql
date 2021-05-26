Use [LIBRARY]
GO
-- Создать хранимую процедуру Получение книги по Id автора
Create PROCEDURE dbo.get_books_by_authorId
-- Id автора
	@Id int
AS
BEGIN
	SELECT author.first_name,
	       author.middle_name,
	       author.last_name,
		   book.[name],
	       genre_name
    FROM dbo.author
    LEFT JOIN dbo.book On book.author_id=author.author_id
    LEFT JOIN dbo.book_genre_lnk On book_genre_lnk.book_id=book.book_id
    LEFT JOIN dbo.dim_genre On dim_genre.genre_id=book_genre_lnk.genre_id
    WHERE author.author_id=@Id
END
GO
