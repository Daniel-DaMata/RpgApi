BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personagens]') AND [c].[name] = N'Nome');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Personagens] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Personagens] ALTER COLUMN [Nome] nvarchar(max) NULL;
GO

ALTER TABLE [Personagens] ADD [FotoPersonagem] varbinary(max) NULL;
GO

ALTER TABLE [Personagens] ADD [UsuarioId] int NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Armas]') AND [c].[name] = N'Nome');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Armas] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Armas] ALTER COLUMN [Nome] nvarchar(max) NULL;
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [Foto] varbinary(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [DataAcesso] datetime2 NULL,
    [Perfil] nvarchar(max) NULL DEFAULT N'Jogador',
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'FotoPersonagem', N'Inteligencia', N'Nome', N'PontosVida', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] ON;
INSERT INTO [Personagens] ([Id], [Classe], [Defesa], [Forca], [FotoPersonagem], [Inteligencia], [Nome], [PontosVida], [UsuarioId])
VALUES (1, 1, 23, 17, NULL, 33, N'Frodo', 100, NULL),
(2, 1, 25, 15, NULL, 30, N'Sam', 100, NULL),
(3, 3, 21, 18, NULL, 35, N'Galadriel', 100, NULL),
(4, 2, 18, 18, NULL, 37, N'Gandalf', 100, NULL),
(5, 1, 17, 20, NULL, 31, N'Hobbit', 100, NULL),
(6, 3, 13, 21, NULL, 34, N'Celeborn', 100, NULL),
(7, 2, 11, 25, NULL, 35, N'Radagast', 100, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Classe', N'Defesa', N'Forca', N'FotoPersonagem', N'Inteligencia', N'Nome', N'PontosVida', N'UsuarioId') AND [object_id] = OBJECT_ID(N'[Personagens]'))
    SET IDENTITY_INSERT [Personagens] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] ON;
INSERT INTO [Usuario] ([Id], [DataAcesso], [Email], [Foto], [Latitude], [Longitude], [PasswordHash], [PasswordSalt], [Perfil], [Username])
VALUES (1, NULL, N'usuario@gmail.com', 0xC0104EE2BF4686F3BA4E2CC9C29041EB489B1B4DF4AAED8D69DBBFCD87ECDA3A15B95B5BDA6A0842E27B83B3261967136B68DEEF3371CD63A236F2F16E8E1F05, NULL, NULL, 0xC0104EE2BF4686F3BA4E2CC9C29041EB489B1B4DF4AAED8D69DBBFCD87ECDA3A15B95B5BDA6A0842E27B83B3261967136B68DEEF3371CD63A236F2F16E8E1F05, 0x8471B50F1EBEEADD13A960171903F951236A3133C74BD0615549010F34D0DA70E2329B1027D3CAFB5572B598B7660C1E37B175CDA42EE0B56AB593C6AD73244684E79DDB13906AE28A83465A7565399E558BF6FB6BF11AA1DAFC0916339725C10BE836144FAB0CF7F7032628FE6F33949CEFFD9013FA02F9B87EF75A709B9836, N'Admin', N'UsuarioAdmin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Email', N'Foto', N'Latitude', N'Longitude', N'PasswordHash', N'PasswordSalt', N'Perfil', N'Username') AND [object_id] = OBJECT_ID(N'[Usuario]'))
    SET IDENTITY_INSERT [Usuario] OFF;
GO

CREATE INDEX [IX_Personagens_UsuarioId] ON [Personagens] ([UsuarioId]);
GO

ALTER TABLE [Personagens] ADD CONSTRAINT [FK_Personagens_Usuario_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221004011735_MigracaoUsuario', N'6.0.9');
GO

COMMIT;
GO

