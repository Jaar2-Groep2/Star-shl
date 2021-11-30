select * from locations

CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[Name] varchar(50) not null,
	[Password] varchar(200) not null,
	[StoredHash] VarBinary(max) not null
)

--sp_rename 'Table','Users';