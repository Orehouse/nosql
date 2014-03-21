DROP	TABLE [dbo].[messages]
CREATE TABLE [dbo].[messages] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [userName]   VARCHAR (100)    NULL,
    [text]       VARCHAR (1000)   NULL,
    [createDate] DATETIME         NULL,
    [version]    ROWVERSION       NOT NULL,
	CONSTRAINT PK_Tmp1 PRIMARY KEY ([Id]),
);

DROP TABLE [dbo].[likes]
CREATE TABLE [dbo].[likes] (
    [userName]   VARCHAR (100)    NOT NULL,
    [messageId]  UNIQUEIDENTIFIER NOT NULL,
    [createDate] DATETIME         NULL,
	CONSTRAINT PK_Tmp PRIMARY KEY ([userName], [messageId]),
	CONSTRAINT FK_Tmp2 FOREIGN KEY ([messageId]) REFERENCES [dbo].[messages] (Id)
)
select * from [dbo].messages