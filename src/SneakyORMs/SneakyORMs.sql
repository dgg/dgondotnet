SET QUOTED_IDENTIFIER OFF;
GO
USE [SneakyORMs];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ParentSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subjects] DROP CONSTRAINT [FK_ParentSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectAnotherChild]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OtherChildren] DROP CONSTRAINT [FK_SubjectAnotherChild];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectChild]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Children] DROP CONSTRAINT [FK_SubjectChild];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Children]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Children];
GO
IF OBJECT_ID(N'[dbo].[OtherChildren]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OtherChildren];
GO
IF OBJECT_ID(N'[dbo].[Parents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Children'
CREATE TABLE [dbo].[Children] (
    [Id] smallint  NOT NULL,
    [Data] nvarchar(128)  NULL,
    [SubjectId] bigint  NOT NULL
);
GO

-- Creating table 'OtherChildren'
CREATE TABLE [dbo].[OtherChildren] (
    [Id] smallint  NOT NULL,
    [Data] nvarchar(128)  NULL,
    [SubjectId] bigint  NOT NULL
);
GO

-- Creating table 'Parents'
CREATE TABLE [dbo].[Parents] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Id] bigint  NOT NULL,
    [Description] nvarchar(256)  NULL,
    [ParentId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [PK_Children]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OtherChildrens'
ALTER TABLE [dbo].[OtherChildren]
ADD CONSTRAINT [PK_OtherChildren]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [PK_Parents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SubjectId] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [FK_SubjectChild]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectChild'
CREATE INDEX [IX_FK_SubjectChild]
ON [dbo].[Children]
    ([SubjectId]);
GO

-- Creating foreign key on [SubjectId] in table 'OtherChildren'
ALTER TABLE [dbo].[OtherChildren]
ADD CONSTRAINT [FK_SubjectAnotherChild]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectAnotherChild'
CREATE INDEX [IX_FK_SubjectAnotherChild]
ON [dbo].[OtherChildren]
    ([SubjectId]);
GO

-- Creating foreign key on [ParentId] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_ParentSubject]
    FOREIGN KEY ([ParentId])
    REFERENCES [dbo].[Parents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ParentSubject'
CREATE INDEX [IX_FK_ParentSubject]
ON [dbo].[Subjects]
    ([ParentId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------