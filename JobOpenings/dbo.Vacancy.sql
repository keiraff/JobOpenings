CREATE TABLE [dbo].[Vacancy] (
    [Id]       INT             NOT NULL,
    [Name]            NVARCHAR (MAX)  NULL,
    [PublicationDate] DATETIME2 (7)   NOT NULL,
    [Location]        NVARCHAR (MAX)  NULL,
    [Company]         NVARCHAR (MAX)  NULL,
    [Payment]         DECIMAL (18, 2) NOT NULL,
    [Education]       NVARCHAR (MAX)  NULL,
    [Experience]      NVARCHAR (MAX)  NULL,
    [Schedule]        NVARCHAR (MAX)  NULL,
    [Category]        NVARCHAR (MAX)  NULL
);

