CREATE TABLE [dbo].[Vacancies] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX)  NULL,
    [PublicationDate] DATETIME2 (7)   NOT NULL,
    [Location]        NVARCHAR (MAX)  NULL,
    [Company]         NVARCHAR (MAX)  NULL,
    [Payment]         DECIMAL (18, 2) NOT NULL,
    [Education]       NVARCHAR (MAX)  NULL,
    [Experience]      NVARCHAR (MAX)  NULL,
    [Schedule]        NVARCHAR (MAX)  NULL,
    [CategoryId]      INT             NULL,
    CONSTRAINT [PK_Vacancies] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Vacancies_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Vacancies_CategoryId]
    ON [dbo].[Vacancies]([CategoryId] ASC);

