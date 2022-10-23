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

CREATE TABLE [Buses] (
    [Id] uniqueidentifier NOT NULL,
    [LicensePlate] varchar(7) NOT NULL,
    [BusColor] int NOT NULL,
    [BusSize] int NOT NULL,
    [IsActive] bit NOT NULL,
    [ActivatedAt] datetime2 NOT NULL,
    [DeactivatedAt] datetime2 NULL,
    CONSTRAINT [PK_Buses] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Drivers] (
    [Id] uniqueidentifier NOT NULL,
    [DriverLicense] varchar(11) NOT NULL,
    [Name] varchar(200) NOT NULL,
    [Document] varchar(8) NOT NULL,
    [BirthDate] date NOT NULL,
    [IsActive] bit NOT NULL,
    [ActivatedAt] datetime2 NOT NULL,
    [DeactivatedAt] datetime2 NULL,
    CONSTRAINT [PK_Drivers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Locals] (
    [Id] uniqueidentifier NOT NULL,
    [Country] varchar(100) NOT NULL,
    [City] varchar(100) NOT NULL,
    [District] varchar(100) NOT NULL,
    [Street] varchar(100) NOT NULL,
    [Number] varchar(100) NOT NULL,
    [Code] varchar(100) NOT NULL,
    CONSTRAINT [PK_Locals] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Routes] (
    [Id] uniqueidentifier NOT NULL,
    [StartPointId] uniqueidentifier NOT NULL,
    [EndPointId] uniqueidentifier NOT NULL,
    [IsActive] bit NOT NULL,
    [ActivatedAt] datetime2 NOT NULL,
    [DeactivatedAt] datetime2 NULL,
    CONSTRAINT [PK_Routes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EndPointId] FOREIGN KEY ([EndPointId]) REFERENCES [Locals] ([Id]),
    CONSTRAINT [FK_StartPointId] FOREIGN KEY ([StartPointId]) REFERENCES [Locals] ([Id])
);
GO

CREATE TABLE [Travels] (
    [Id] uniqueidentifier NOT NULL,
    [DriverId] uniqueidentifier NOT NULL,
    [BusId] uniqueidentifier NOT NULL,
    [RouteId] uniqueidentifier NOT NULL,
    [StartedAt] datetime2 NOT NULL,
    [FinishedAt] datetime2 NULL,
    [DeletedAt] datetime2 NULL,
    CONSTRAINT [PK_Travels] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BusId] FOREIGN KEY ([BusId]) REFERENCES [Buses] ([Id]),
    CONSTRAINT [FK_DriverId] FOREIGN KEY ([DriverId]) REFERENCES [Drivers] ([Id]),
    CONSTRAINT [FK_RouteId] FOREIGN KEY ([RouteId]) REFERENCES [Routes] ([Id])
);
GO

CREATE INDEX [IX_Routes_EndPointId] ON [Routes] ([EndPointId]);
GO

CREATE INDEX [IX_Routes_StartPointId] ON [Routes] ([StartPointId]);
GO

CREATE INDEX [IX_Travels_BusId] ON [Travels] ([BusId]);
GO

CREATE INDEX [IX_Travels_DriverId] ON [Travels] ([DriverId]);
GO

CREATE INDEX [IX_Travels_RouteId] ON [Travels] ([RouteId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220828162828_InitialMigrationEntitiesTables', N'6.0.8');
GO

COMMIT;
GO

