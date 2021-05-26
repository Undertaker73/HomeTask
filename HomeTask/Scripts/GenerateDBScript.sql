-- Создание Базы данных "Библиотека"
CREATE DATABASE [LIBRARY]
USE [LIBRARY]
GO
-- Создание таблицы "Автор"
CREATE TABLE [dbo].[author](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NOT NULL,
	[last_name] [varchar](255) NOT NULL,
	[middle_name] [varchar](255) NULL,
 CONSTRAINT [PK_author] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Создание таблицы "Книга"
CREATE TABLE [dbo].[book](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_book] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Создание таблицы "Книга-жанр" для связи ManyToMany таблиц "Книга" и "Жанр"
CREATE TABLE [dbo].[book_genre_lnk](
	[book_id] [int] NOT NULL,
	[genre_id] [int] NULL
) ON [PRIMARY]
GO

-- Создание таблицы "Жанр"
CREATE TABLE [dbo].[dim_genre](
	[genre_id] [int] IDENTITY(1,1) NOT NULL,
	[genre_name] [varchar](255) NOT NULL,
 CONSTRAINT [PK_dim_genre] PRIMARY KEY CLUSTERED 
(
	[genre_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Создание таблицы "Библиотечная карта" для связи ManyToMany таблиц "Книга" и "Человек"
CREATE TABLE [dbo].[library_card](
	[book_book_id] [int] NOT NULL,
	[person_person_id] [int] NOT NULL,
	[return_date] [date] NOT NULL
) ON [PRIMARY]
GO

-- Создание таблицы "Человек"
CREATE TABLE [dbo].[person](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[birth_date] [date] NULL,
	[first_name] [varchar](255) NOT NULL,
	[last_name] [varchar](255) NOT NULL,
	[middle_name] [varchar](255) NULL,
 CONSTRAINT [PK_person] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- Добавление внешнего ключа author_id в таблицу "Книга"
ALTER TABLE [dbo].[book]  WITH CHECK ADD  CONSTRAINT [FK_book_author] FOREIGN KEY([author_id])
REFERENCES [dbo].[author] ([author_id])
GO
ALTER TABLE [dbo].[book] CHECK CONSTRAINT [FK_book_author]
GO

-- Добавление внешнего ключа book_id в таблицу "Книга"
ALTER TABLE [dbo].[book_genre_lnk]  WITH CHECK ADD  CONSTRAINT [FK_book_genre_lnk_book] FOREIGN KEY([book_id])
REFERENCES [dbo].[book] ([book_id])
GO
ALTER TABLE [dbo].[book_genre_lnk] CHECK CONSTRAINT [FK_book_genre_lnk_book]
GO

-- Добавление внешнего ключа genre_id в таблицу "Книга"
ALTER TABLE [dbo].[book_genre_lnk]  WITH CHECK ADD  CONSTRAINT [FK_book_genre_lnk_dim_genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[dim_genre] ([genre_id])
GO
ALTER TABLE [dbo].[book_genre_lnk] CHECK CONSTRAINT [FK_book_genre_lnk_dim_genre]
GO

-- Добавление внешнего ключа book_id в таблицу "Библиотечная карта"
ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_book] FOREIGN KEY([book_book_id])
REFERENCES [dbo].[book] ([book_id])
GO
ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_book]
GO

-- Добавление внешнего ключа person_id в таблицу "Библиотечная карта"
ALTER TABLE [dbo].[library_card]  WITH CHECK ADD  CONSTRAINT [FK_library_card_person] FOREIGN KEY([person_person_id])
REFERENCES [dbo].[person] ([person_id])
GO
ALTER TABLE [dbo].[library_card] CHECK CONSTRAINT [FK_library_card_person]
GO

USE [master]
GO
ALTER DATABASE [LIBRARY] SET  READ_WRITE 
GO
