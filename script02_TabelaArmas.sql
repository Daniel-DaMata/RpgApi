BEGIN TRANSACTION;
GO

DELETE FROM [Personagens]
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

DELETE FROM [Personagens]
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

CREATE TABLE [Armas] (
    [Id] int NOT NULL IDENTITY,
    [Dano] int NOT NULL,
    [Nome] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Armas] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] ON;
INSERT INTO [Armas] ([Id], [Dano], [Nome])
VALUES (1, 10, N'Ak'),
(2, 4, N'Facao'),
(3, 5, N'Machado'),
(4, 8, N'Espada'),
(5, 2, N'Estilingue'),
(6, 7, N'Enxada'),
(7, 100, N'Cerrinha de Pao');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Armas]'))
    SET IDENTITY_INSERT [Armas] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220927002228_MigracaoArma', N'6.0.9');
GO

COMMIT;
GO

