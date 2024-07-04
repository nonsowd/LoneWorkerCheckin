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

CREATE TABLE [Regions] (
    [RegionId] uniqueidentifier NOT NULL,
    [RegionName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY ([RegionId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] ON;
INSERT INTO [Regions] ([RegionId], [RegionName])
VALUES ('0b6ddb7e-af14-4662-86c6-82b60ea2e442', N'South East'),
('1440eec7-5c8b-47d8-a56b-e14cd8ba721f', N'South West'),
('52c20088-e5aa-4b48-8be5-6f646b4d985c', N'Middle England'),
('789166b2-eb77-4c7e-8536-cf173afc9936', N'Wales'),
('78d78dcc-9361-42d4-b00d-5b9b3ccc413e', N'Southern'),
('ee11b5ba-cc38-4bae-99b4-ae91324e5178', N'Scotland'),
('f00995d7-97f5-42ff-b4ad-a0bc58f67d2d', N'Northern');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240704191430_Initial', N'8.0.4');
GO

COMMIT;
GO

