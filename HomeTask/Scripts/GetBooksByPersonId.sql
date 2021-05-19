Use [LIBRARY]
GO
-- Создать хранимую процедуру Получение книги по Id читателя
Alter PROCEDURE dbo.get_books_by_personId
-- Id пользователя
	@Id int
AS
BEGIN
	SELECT [book].[name], 
		   author.first_name,
	       author.middle_name,
	       author.last_name,
	       genre_name
    From [dbo].[library_card]
    JOIN dbo.book On book.book_id=[library_card].book_book_id
    JOIN dbo.author On author.author_id=[book].author_id
    JOIN dbo.book_genre_lnk On book_genre_lnk.book_id=[book].book_id
    JOIN dbo.dim_genre On dim_genre.genre_id=book_genre_lnk.genre_id
    Where [library_card].[person_person_id]=@Id
END
GO
