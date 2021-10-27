CREATE TABLE [dbo].[Colors] (
    [Id]    INT           IDENTITY (0, 1) NOT NULL,
    [Title] NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Title] ASC)
);


GO

