CREATE TABLE [dbo].[Posts]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,0),
	[Title] nvarchar(100) Not null,
	[Text] Text Not null
)
