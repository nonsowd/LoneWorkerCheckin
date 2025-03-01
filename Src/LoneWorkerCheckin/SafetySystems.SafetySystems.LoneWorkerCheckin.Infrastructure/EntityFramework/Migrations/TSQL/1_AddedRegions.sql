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

BEGIN TRANSACTION;
GO

DELETE FROM [Regions]
WHERE [RegionId] = '0b6ddb7e-af14-4662-86c6-82b60ea2e442';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '1440eec7-5c8b-47d8-a56b-e14cd8ba721f';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '52c20088-e5aa-4b48-8be5-6f646b4d985c';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '789166b2-eb77-4c7e-8536-cf173afc9936';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '78d78dcc-9361-42d4-b00d-5b9b3ccc413e';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = 'ee11b5ba-cc38-4bae-99b4-ae91324e5178';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = 'f00995d7-97f5-42ff-b4ad-a0bc58f67d2d';
SELECT @@ROWCOUNT;

GO

CREATE TABLE [Sites] (
    [SiteId] uniqueidentifier NOT NULL,
    [RegionId] uniqueidentifier NOT NULL,
    [SiteName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Sites] PRIMARY KEY ([SiteId]),
    CONSTRAINT [FK_Sites_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [Regions] ([RegionId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] ON;
INSERT INTO [Regions] ([RegionId], [RegionName])
VALUES ('135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e', N'Wales'),
('278ad6af-b008-403d-a25f-a249cd6e6351', N'Southern'),
('45d2fd15-f2c7-4eb0-adf9-87ef939d17fe', N'Middle England'),
('566c89af-b5fd-4aeb-a93c-1f942c80d33b', N'Northern'),
('810411d4-5f2f-46af-9400-972e50a77281', N'Scotland'),
('c56db57a-e902-45bf-a56c-b38143fa80d2', N'South East'),
('eb1057b5-8255-43c0-9796-02bbe47c1d45', N'South West');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SiteId', N'RegionId', N'SiteName') AND [object_id] = OBJECT_ID(N'[Sites]'))
    SET IDENTITY_INSERT [Sites] ON;
INSERT INTO [Sites] ([SiteId], [RegionId], [SiteName])
VALUES ('01ff832c-6f4f-4750-9065-0539bb380505', 'c56db57a-e902-45bf-a56c-b38143fa80d2', N'Brighton'),
('1be49094-cfed-4743-9d29-df49d3d924b5', '135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e', N'Bangor'),
('b4200663-b5d1-40f2-8603-d5a2f6e2cf1a', 'c56db57a-e902-45bf-a56c-b38143fa80d2', N'Horsham'),
('c1870ae7-fe5a-4c9b-8c0e-fb2d874aabab', '135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e', N'Cardiff');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SiteId', N'RegionId', N'SiteName') AND [object_id] = OBJECT_ID(N'[Sites]'))
    SET IDENTITY_INSERT [Sites] OFF;
GO

CREATE UNIQUE INDEX [IX_Regions_RegionName] ON [Regions] ([RegionName]);
GO

CREATE INDEX [IX_Sites_RegionId] ON [Sites] ([RegionId]);
GO

CREATE UNIQUE INDEX [IX_Sites_SiteName] ON [Sites] ([SiteName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240718201253_AddedRegions', N'8.0.4');
GO

COMMIT;
GO

