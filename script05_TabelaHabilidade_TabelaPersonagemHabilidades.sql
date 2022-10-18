BEGIN TRANSACTION;
GO

ALTER TABLE [Personagens] ADD [Derrotas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Disputas] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [Personagens] ADD [Vitorias] int NOT NULL DEFAULT 0;
GO

CREATE TABLE [Habilidades] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [Dano] int NOT NULL,
    CONSTRAINT [PK_Habilidades] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [PersonagemHabilidades] (
    [PersonagemId] int NOT NULL,
    [HabilidadeId] int NOT NULL,
    CONSTRAINT [PK_PersonagemHabilidades] PRIMARY KEY ([PersonagemId], [HabilidadeId]),
    CONSTRAINT [FK_PersonagemHabilidades_Habilidades_HabilidadeId] FOREIGN KEY ([HabilidadeId]) REFERENCES [Habilidades] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemHabilidades_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] ON;
INSERT INTO [Habilidades] ([Id], [Dano], [Nome])
VALUES (1, 39, N'Adormecer'),
(2, 41, N'Congelar'),
(3, 37, N'Hipnotizar');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Dano', N'Nome') AND [object_id] = OBJECT_ID(N'[Habilidades]'))
    SET IDENTITY_INSERT [Habilidades] OFF;
GO

UPDATE [Usuario] SET [Foto] = 0x4EE8024EDBB92F141A1429A1F9F3E0AC1D10D5B60BD3576AE1F1B90827DD4A1CD0521111A62A92C926FD262F812B8DB1A536C6908315F0CFA0B772D8D914B4B2, [PasswordHash] = 0x4EE8024EDBB92F141A1429A1F9F3E0AC1D10D5B60BD3576AE1F1B90827DD4A1CD0521111A62A92C926FD262F812B8DB1A536C6908315F0CFA0B772D8D914B4B2, [PasswordSalt] = 0x92F609177E82A9C53B1FFC6FD71EC91FDBA2E0587CE1720B0C4E8906055BA79968294B0F190CFAC90AC191317C90E5307C5CCA9201E38D0AFBF712E5CB5264C215445001B8E9936B8427B0BEE3C41CB8DC08D23BBBA7AF6A11E2E345867619C7F602DC52852298295A4A0819B03044AEB100584DEB28A0A806DE87CDEC7887C3
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] ON;
INSERT INTO [PersonagemHabilidades] ([HabilidadeId], [PersonagemId])
VALUES (1, 1),
(2, 1),
(2, 2),
(2, 3),
(3, 3),
(3, 4),
(1, 5),
(2, 6),
(3, 7);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'HabilidadeId', N'PersonagemId') AND [object_id] = OBJECT_ID(N'[PersonagemHabilidades]'))
    SET IDENTITY_INSERT [PersonagemHabilidades] OFF;
GO

CREATE INDEX [IX_PersonagemHabilidades_HabilidadeId] ON [PersonagemHabilidades] ([HabilidadeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221017232636_MigracaoMuitosParaMuitos', N'6.0.9');
GO

COMMIT;
GO

