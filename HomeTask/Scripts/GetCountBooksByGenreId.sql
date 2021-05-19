Use [LIBRARY]
GO
-- Создать хранимую процедуру получение количества книг по Id жанра
Create PROCEDURE dbo.get_stats_by_genreId
-- Id жанра
	@Id int
AS
BEGIN
	SELECT count(*) AS [count books]
	FROM dbo.book_genre_lnk
	WHERE genre_id=@Id
END
GO
