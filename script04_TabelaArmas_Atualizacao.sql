BEGIN TRANSACTION;
GO

ALTER TABLE [Armas] ADD [PersonagemId] int NOT NULL DEFAULT 0;
GO

UPDATE [Armas] SET [PersonagemId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 2
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 3
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 4
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 5
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 6
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [Armas] SET [PersonagemId] = 7
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [Usuario] SET [Foto] = 0xF39005D7C4465BF23EB05FFD98B834CC513F518F92D18803B7470C1FE0DA5AF40D9918D02782ABE8A404DBB8FFE381092340974830914BD5D96F979ECD56783C, [PasswordHash] = 0xF39005D7C4465BF23EB05FFD98B834CC513F518F92D18803B7470C1FE0DA5AF40D9918D02782ABE8A404DBB8FFE381092340974830914BD5D96F979ECD56783C, [PasswordSalt] = 0xEEDE288568CC852BB7CE817EC3F2E9E7F3F444D02F7BF8FB1F44CB70F3000F37EAA87B0925EC495126ADBA89BE406F206988EB736798AEDF26A133703A80D5DD7C60D97AE4AE7E32799CDCFB37D2323523DAA04A15C647E9C09F9DB459B3334F9685A47C44B133A219D96F5619D28326A155C33F7E4DD1025036F0558146E5BB
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

CREATE UNIQUE INDEX [IX_Armas_PersonagemId] ON [Armas] ([PersonagemId]);
GO

ALTER TABLE [Armas] ADD CONSTRAINT [FK_Armas_Personagens_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagens] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221004013845_MigracaoUmParaUm', N'6.0.9');
GO

COMMIT;
GO

