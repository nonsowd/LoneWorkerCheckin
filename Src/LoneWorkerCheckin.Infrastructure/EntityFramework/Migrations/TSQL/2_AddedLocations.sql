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

BEGIN TRANSACTION;
GO

DELETE FROM [Regions]
WHERE [RegionId] = '278ad6af-b008-403d-a25f-a249cd6e6351';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '45d2fd15-f2c7-4eb0-adf9-87ef939d17fe';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '566c89af-b5fd-4aeb-a93c-1f942c80d33b';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '810411d4-5f2f-46af-9400-972e50a77281';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = 'eb1057b5-8255-43c0-9796-02bbe47c1d45';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Sites]
WHERE [SiteId] = '01ff832c-6f4f-4750-9065-0539bb380505';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Sites]
WHERE [SiteId] = '1be49094-cfed-4743-9d29-df49d3d924b5';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Sites]
WHERE [SiteId] = 'b4200663-b5d1-40f2-8603-d5a2f6e2cf1a';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Sites]
WHERE [SiteId] = 'c1870ae7-fe5a-4c9b-8c0e-fb2d874aabab';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = '135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e';
SELECT @@ROWCOUNT;

GO

DELETE FROM [Regions]
WHERE [RegionId] = 'c56db57a-e902-45bf-a56c-b38143fa80d2';
SELECT @@ROWCOUNT;

GO

CREATE TABLE [Locations] (
    [LocationId] uniqueidentifier NOT NULL,
    [LocationName] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([LocationId])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'LocationName') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] ON;
INSERT INTO [Locations] ([LocationId], [LocationName])
VALUES ('2ac4032b-240f-4029-9d64-d20848c8d694', N'Reception'),
('6d55a9ed-e128-4366-97d0-eddcb6fa7c58', N'Dinning room'),
('774e9499-fb15-4995-8dc8-43610a5f5b53', N'Kitchen');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'LocationId', N'LocationName') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] ON;
INSERT INTO [Regions] ([RegionId], [RegionName])
VALUES ('04d82d36-3c9a-4b57-94f0-509574eb1523', N'Wales'),
('0e817f5c-e063-4d2a-aca5-0e40b52dd0ce', N'Northern'),
('6cc76f4a-5c6d-4f25-b898-0ffeaec0af1f', N'Scotland'),
('7736d6df-d93d-42c8-82c3-639bfd7b326f', N'South East'),
('7d45913f-2062-41e6-8da5-2d9f3b259552', N'South West'),
('c5b96f86-2305-4a90-b3cf-cd8300c28017', N'Middle England'),
('cd5aa765-ace1-4cf0-bd8d-141eca83a8e1', N'Southern');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RegionId', N'RegionName') AND [object_id] = OBJECT_ID(N'[Regions]'))
    SET IDENTITY_INSERT [Regions] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SiteId', N'RegionId', N'SiteName') AND [object_id] = OBJECT_ID(N'[Sites]'))
    SET IDENTITY_INSERT [Sites] ON;
INSERT INTO [Sites] ([SiteId], [RegionId], [SiteName])
VALUES ('bfde935e-abe4-4d64-9c36-2cfb172fae99', '7736d6df-d93d-42c8-82c3-639bfd7b326f', N'Horsham'),
('c9ab9a01-b18f-4fbb-8acd-27359fd52c0d', '7736d6df-d93d-42c8-82c3-639bfd7b326f', N'Brighton'),
('cc53d272-23e7-436d-b5a5-c3a235cdb2fd', '04d82d36-3c9a-4b57-94f0-509574eb1523', N'Bangor'),
('e961b53c-e82b-453e-b814-ecddc031e953', '04d82d36-3c9a-4b57-94f0-509574eb1523', N'Cardiff');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SiteId', N'RegionId', N'SiteName') AND [object_id] = OBJECT_ID(N'[Sites]'))
    SET IDENTITY_INSERT [Sites] OFF;
GO

CREATE UNIQUE INDEX [IX_Locations_LocationName] ON [Locations] ([LocationName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240828192223_AddedLocations', N'8.0.4');
GO

COMMIT;
GO

