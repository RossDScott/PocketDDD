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

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [EventDetailId] int NOT NULL,
    [GivenName] nvarchar(max) NOT NULL,
    [FamilyName] nvarchar(max) NOT NULL,
    [Token] nvarchar(max) NOT NULL,
    [EventScore] int NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220508191851_init', N'6.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [EventDetail] (
    [Id] int NOT NULL IDENTITY,
    [Version] int NOT NULL,
    CONSTRAINT [PK_EventDetail] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TimeSlots] (
    [Id] int NOT NULL IDENTITY,
    [EventDetailId] int NOT NULL,
    [From] datetimeoffset NOT NULL,
    [To] datetimeoffset NOT NULL,
    [Info] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_TimeSlots] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TimeSlots_EventDetail_EventDetailId] FOREIGN KEY ([EventDetailId]) REFERENCES [EventDetail] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Tracks] (
    [Id] int NOT NULL IDENTITY,
    [EventDetailId] int NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [RoomName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Tracks] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tracks_EventDetail_EventDetailId] FOREIGN KEY ([EventDetailId]) REFERENCES [EventDetail] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserEventFeedback] (
    [Id] int NOT NULL IDENTITY,
    [DateTimestamp] datetimeoffset NOT NULL,
    [EventDetailId] int NOT NULL,
    [Refreshments] int NULL,
    [Venue] int NULL,
    [Overall] int NULL,
    [UserId] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UserEventFeedback] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserEventFeedback_EventDetail_EventDetailId] FOREIGN KEY ([EventDetailId]) REFERENCES [EventDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserEventFeedback_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Sessions] (
    [Id] int NOT NULL IDENTITY,
    [EventDetailId] int NOT NULL,
    [Title] nvarchar(max) NOT NULL,
    [ShortDescription] nvarchar(max) NOT NULL,
    [FullDescription] nvarchar(max) NOT NULL,
    [Speaker] nvarchar(max) NOT NULL,
    [TrackId] int NOT NULL,
    [TimeSlotId] int NOT NULL,
    [SpeakerToken] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Sessions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sessions_EventDetail_EventDetailId] FOREIGN KEY ([EventDetailId]) REFERENCES [EventDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sessions_TimeSlots_TimeSlotId] FOREIGN KEY ([TimeSlotId]) REFERENCES [TimeSlots] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sessions_Tracks_TrackId] FOREIGN KEY ([TrackId]) REFERENCES [Tracks] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserSessionFeedback] (
    [Id] int NOT NULL IDENTITY,
    [DateTimestamp] datetimeoffset NOT NULL,
    [EventDetailId] int NOT NULL,
    [SessionId] int NOT NULL,
    [SpeakerKnowledgeRating] int NULL,
    [SpeakerSkillsRating] int NULL,
    [UserId] int NOT NULL,
    [Comment] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_UserSessionFeedback] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserSessionFeedback_EventDetail_EventDetailId] FOREIGN KEY ([EventDetailId]) REFERENCES [EventDetail] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserSessionFeedback_Sessions_SessionId] FOREIGN KEY ([SessionId]) REFERENCES [Sessions] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserSessionFeedback_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Sessions_EventDetailId] ON [Sessions] ([EventDetailId]);
GO

CREATE INDEX [IX_Sessions_TimeSlotId] ON [Sessions] ([TimeSlotId]);
GO

CREATE INDEX [IX_Sessions_TrackId] ON [Sessions] ([TrackId]);
GO

CREATE INDEX [IX_TimeSlots_EventDetailId] ON [TimeSlots] ([EventDetailId]);
GO

CREATE INDEX [IX_Tracks_EventDetailId] ON [Tracks] ([EventDetailId]);
GO

CREATE INDEX [IX_UserEventFeedback_EventDetailId] ON [UserEventFeedback] ([EventDetailId]);
GO

CREATE INDEX [IX_UserEventFeedback_UserId] ON [UserEventFeedback] ([UserId]);
GO

CREATE INDEX [IX_UserSessionFeedback_EventDetailId] ON [UserSessionFeedback] ([EventDetailId]);
GO

CREATE INDEX [IX_UserSessionFeedback_SessionId] ON [UserSessionFeedback] ([SessionId]);
GO

CREATE INDEX [IX_UserSessionFeedback_UserId] ON [UserSessionFeedback] ([UserId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220508195301_CoreEvent', N'6.0.4');
GO

COMMIT;
GO

