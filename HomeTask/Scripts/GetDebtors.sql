USE [LIBRARY]
GO
/****** Object:  StoredProcedure [dbo].[get_books_by_personId]    Script Date: 09.05.2021 18:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Создать хранимую процедуру Получение книги по Id читателя
CREATE PROCEDURE [dbo].[get_debtors]
AS
BEGIN
	SELECT person.first_name,
	   person.middle_name,
	   person.last_name,
       book.[name],
       DATEDIFF(day,return_date,CAST(GETDATE() AS date)) AS [days_of_delay]
  FROM dbo.library_card
  JOIN person on person.person_id=library_card.person_person_id
  JOIN book on book.book_id=library_card.book_book_id
  where [return_date]<=CAST(getdate() AS DATE)
END
