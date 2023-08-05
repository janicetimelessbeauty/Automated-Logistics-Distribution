IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [Customers] (
        [CustomerId] uniqueidentifier NOT NULL,
        [name] nvarchar(max) NOT NULL,
        [dateofBirth] datetime2 NOT NULL,
        [email] nvarchar(max) NOT NULL,
        [address] nvarchar(max) NOT NULL,
        [city] nvarchar(max) NOT NULL,
        [mobilePhone] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [Products] (
        [ProductId] uniqueidentifier NOT NULL,
        [ProductName] nvarchar(max) NOT NULL,
        [ProductDescription] nvarchar(80) NOT NULL,
        [ProductCategory] nvarchar(max) NOT NULL,
        [Distributor] int NOT NULL,
        [ProductPrice] int NOT NULL,
        [ProductImgUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [Warehouses] (
        [WarehouseId] uniqueidentifier NOT NULL,
        [WareName] nvarchar(max) NOT NULL,
        [License] nvarchar(max) NOT NULL,
        [CentralDistance] nvarchar(max) NOT NULL,
        [EstimatedTime] int NOT NULL,
        CONSTRAINT [PK_Warehouses] PRIMARY KEY ([WarehouseId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [NewOrder] (
        [NewOrderId] uniqueidentifier NOT NULL,
        [CustomerId] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        CONSTRAINT [PK_NewOrder] PRIMARY KEY ([NewOrderId]),
        CONSTRAINT [FK_NewOrder_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([CustomerId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [Orders] (
        [NewOrderId] uniqueidentifier NOT NULL,
        [ProductId] uniqueidentifier NOT NULL,
        [Quantity] int NOT NULL,
        [Discount] int NOT NULL,
        CONSTRAINT [FK_Orders_NewOrder_NewOrderId] FOREIGN KEY ([NewOrderId]) REFERENCES [NewOrder] ([NewOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE TABLE [OrderWares] (
        [Id] uniqueidentifier NOT NULL,
        [NewOrderId] uniqueidentifier NOT NULL,
        [totalAmount] int NOT NULL,
        [WarehouseId] uniqueidentifier NOT NULL,
        [Created] datetime2 NOT NULL,
        CONSTRAINT [PK_OrderWares] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_OrderWares_NewOrder_NewOrderId] FOREIGN KEY ([NewOrderId]) REFERENCES [NewOrder] ([NewOrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderWares_Warehouses_WarehouseId] FOREIGN KEY ([WarehouseId]) REFERENCES [Warehouses] ([WarehouseId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Distributor', N'ProductCategory', N'ProductDescription', N'ProductImgUrl', N'ProductName', N'ProductPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] ON;
    EXEC(N'INSERT INTO [Products] ([ProductId], [Distributor], [ProductCategory], [ProductDescription], [ProductImgUrl], [ProductName], [ProductPrice])
    VALUES (''53dc9e8c-c3dd-4b5a-8ef0-80535bf66bbb'', 22, N''Detox'', N''Healthy with a rich source of vitamins C'', N''https://drivemehungry.com/wp-content/uploads/2022/08/korean-banana-milk-5.jpg'', N''Banana Milk'', 20),
    (''569289df-6346-4e75-a15d-923f97cac8ac'', 25, N''Dessert'', N''Perfect for ending your meal with some sweet treats'', N''https://leitesculinaria.com/wp-content/uploads/2020/01/panna-cotta.jpg'', N''Panna Cotta'', 30),
    (''d048f7ab-5b75-4d37-8f4e-ad939e8dba0a'', 12, N''Electric'', N''Good for your night sleep with coziness and comfort'', N''https://tamhome.vn/wp-content/uploads/2017/07/IMG_4969.jpg'', N''Mickey Mouse'', 500)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductId', N'Distributor', N'ProductCategory', N'ProductDescription', N'ProductImgUrl', N'ProductName', N'ProductPrice') AND [object_id] = OBJECT_ID(N'[Products]'))
        SET IDENTITY_INSERT [Products] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'WarehouseId', N'CentralDistance', N'EstimatedTime', N'License', N'WareName') AND [object_id] = OBJECT_ID(N'[Warehouses]'))
        SET IDENTITY_INSERT [Warehouses] ON;
    EXEC(N'INSERT INTO [Warehouses] ([WarehouseId], [CentralDistance], [EstimatedTime], [License], [WareName])
    VALUES (''a64608dc-8140-47f2-b886-e3948926ff1a'', N''12'', 4, N''2014'', N''AUPost''),
    (''b7f822ef-493b-4f15-802a-5c75de666e8d'', N''21'', 3, N''2012'', N''Felix''),
    (''e5e31796-666d-4d99-9805-c25ab4343098'', N''15'', 2, N''2005'', N''FedX'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'WarehouseId', N'CentralDistance', N'EstimatedTime', N'License', N'WareName') AND [object_id] = OBJECT_ID(N'[Warehouses]'))
        SET IDENTITY_INSERT [Warehouses] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE INDEX [IX_NewOrder_CustomerId] ON [NewOrder] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE INDEX [IX_Orders_NewOrderId] ON [Orders] ([NewOrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE INDEX [IX_Orders_ProductId] ON [Orders] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE INDEX [IX_OrderWares_NewOrderId] ON [OrderWares] ([NewOrderId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    CREATE INDEX [IX_OrderWares_WarehouseId] ON [OrderWares] ([WarehouseId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625062342_Models')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230625062342_Models', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625082439_key')
BEGIN
    ALTER TABLE [Orders] ADD [Id] uniqueidentifier NOT NULL DEFAULT '00000000-0000-0000-0000-000000000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625082439_key')
BEGIN
    ALTER TABLE [Orders] ADD CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625082439_key')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230625082439_key', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703114329_Image')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Products]') AND [c].[name] = N'ProductDescription');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Products] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Products] ALTER COLUMN [ProductDescription] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703114329_Image')
BEGIN
    CREATE TABLE [ImageUploads] (
        [Id] uniqueidentifier NOT NULL,
        [fileName] nvarchar(max) NOT NULL,
        [fileExtension] nvarchar(max) NOT NULL,
        [filePath] nvarchar(max) NOT NULL,
        [fileSize] bigint NOT NULL,
        [fileDescription] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_ImageUploads] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703114329_Image')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230703114329_Image', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727060248_distance')
BEGIN
    ALTER TABLE [Customers] ADD [dist] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727060248_distance')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230727060248_distance', N'7.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727060814_distanc')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Customers]') AND [c].[name] = N'dist');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Customers] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Customers] ALTER COLUMN [dist] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727060814_distanc')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230727060814_distanc', N'7.0.8');
END;
GO

COMMIT;
GO

