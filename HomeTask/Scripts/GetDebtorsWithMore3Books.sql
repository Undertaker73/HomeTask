USE [LIBRARY]
GO
/****** Object:  StoredProcedure [dbo].[get_books_by_personId]    Script Date: 09.05.2021 18:13:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Создать хранимую процедуру Получение книги по Id читателя
CREATE PROCEDURE [dbo].[get_debtors_with_more_3_books]
AS
BEGIN
	SELECT person.first_name,
		   person.middle_name,
		   person.last_name,
	       debtors.number_of_books
	FROM person
	JOIN (SELECT person_person_id,
	   Count(person_person_id) as [number_of_books]
	FROM dbo.library_card
	where [return_date]<=CAST(getdate() AS DATE)
	group by person_person_id
	having Count(person_person_id)>3) debtors ON debtors.person_person_id=person_id
END
