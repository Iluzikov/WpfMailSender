
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2020 14:38:55
-- Generated from EDMX file: D:\GEEKBrains\HomeWorks\Cs_3\WpfMailSender\WpfMailSender\EFData\EmailEDM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EFMailSenderDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EFEmailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EFEmailSet];
GO
IF OBJECT_ID(N'[dbo].[EFSmtpSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EFSmtpSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EFEmailSet'
CREATE TABLE [dbo].[EFEmailSet] (
    [EmailId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EFSmtpSet'
CREATE TABLE [dbo].[EFSmtpSet] (
    [SmtpId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Server] nvarchar(max)  NOT NULL,
    [Port] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [EmailId] in table 'EFEmailSet'
ALTER TABLE [dbo].[EFEmailSet]
ADD CONSTRAINT [PK_EFEmailSet]
    PRIMARY KEY CLUSTERED ([EmailId] ASC);
GO

-- Creating primary key on [SmtpId] in table 'EFSmtpSet'
ALTER TABLE [dbo].[EFSmtpSet]
ADD CONSTRAINT [PK_EFSmtpSet]
    PRIMARY KEY CLUSTERED ([SmtpId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------