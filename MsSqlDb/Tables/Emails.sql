CREATE TABLE [dbo].[Emails] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [PostName]           NVARCHAR (50)  NOT NULL,
    [ConfirmationString] NVARCHAR (150) NOT NULL,
    [IsConfirmed]        BIT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([PostName] ASC)
);


GO

