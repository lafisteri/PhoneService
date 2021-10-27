CREATE TABLE [dbo].[Users] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [Login]     NVARCHAR (50)    NOT NULL,
    [FirstName] NVARCHAR (50)    NOT NULL,
    [LastName]  NVARCHAR (50)    NOT NULL,
    [Password]  NVARCHAR (50)    NOT NULL,
    [RoleId]    INT              DEFAULT ((0)) NOT NULL,
    [EmailId]   INT              NULL,
    [IsActive]  BIT              DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmailId] FOREIGN KEY ([EmailId]) REFERENCES [dbo].[Emails] ([Id]),
    CONSTRAINT [FK_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);


GO

