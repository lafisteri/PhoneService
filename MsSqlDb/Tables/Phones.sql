CREATE TABLE [dbo].[Phones] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [Model]           NVARCHAR (50)    NOT NULL,
    [IsEsim]          BIT              NOT NULL,
    [DisplayDiagonal] FLOAT (53)       NOT NULL,
    [ColorId]         INT              NOT NULL,
    [PresentationDay] DATETIME2 (7)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Products_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id])
);


GO

