USE [LIBRARY]
GO
/****** Object:  StoredProcedure [dbo].[get_debtors]    Script Date: 10.05.2021 11:31:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Создать хранимую процедуру получение статистики по 
ALTER PROCEDURE [dbo].[get_statistics_book_debt]
-- Id пользователя
	@Id int
AS
BEGIN
  SELECT count(*) AS count_books,
  Sum(DATEDIFF(day, return_date, CAST(GETDATE() AS date))) AS [days_of_delay]
  FROM [LIBRARY].[dbo].[library_card]
  where [return_date]<=CAST(getdate() AS DATE) AND 	@Id=[library_card].[person_person_id]
END
