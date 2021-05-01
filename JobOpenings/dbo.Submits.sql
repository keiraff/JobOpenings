CREATE TABLE [dbo].[Submits] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Surname]     NVARCHAR (MAX) NULL,
    [MobilePhone] NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Submits] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_Submits_Vacancies] FOREIGN KEY ([Id]) REFERENCES [dbo].[Vacancies]([Id])
);

