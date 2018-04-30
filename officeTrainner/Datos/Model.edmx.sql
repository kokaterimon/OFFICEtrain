
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2018 17:04:34
-- Generated from EDMX file: C:\OFFICEtrainer\officeTrainner\Datos\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [OfficeTrainner];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AlumnoExamen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examenes] DROP CONSTRAINT [FK_AlumnoExamen];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamenDetalleExamen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Examenes] DROP CONSTRAINT [FK_ExamenDetalleExamen];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Alumnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Alumnos];
GO
IF OBJECT_ID(N'[dbo].[Examenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Examenes];
GO
IF OBJECT_ID(N'[dbo].[DetalleExamenes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleExamenes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Alumnos'
CREATE TABLE [dbo].[Alumnos] (
    [IdAlumno] int IDENTITY(1,1) NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Examenes'
CREATE TABLE [dbo].[Examenes] (
    [IdExamen] int IDENTITY(1,1) NOT NULL,
    [NombreExamen] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [Avance] int  NOT NULL,
    [AlumnoIdAlumno] int  NOT NULL,
    [NumeroDePreguntas] int  NOT NULL
);
GO

-- Creating table 'DetalleExamenes'
CREATE TABLE [dbo].[DetalleExamenes] (
    [IdDetalleExamen] int IDENTITY(1,1) NOT NULL,
    [Pregunta1] nvarchar(max)  NULL,
    [Pregunta2] nvarchar(max)  NULL,
    [Pregunta3] nvarchar(max)  NULL,
    [Pregunta4] nvarchar(max)  NULL,
    [Pregunta5] nvarchar(max)  NULL,
    [Pregunta6] nvarchar(max)  NULL,
    [Pregunta7] nvarchar(max)  NULL,
    [Pregunta8] nvarchar(max)  NULL,
    [Pregunta9] nvarchar(max)  NULL,
    [Pregunta10] nvarchar(max)  NULL,
    [Pregunta11] nvarchar(max)  NULL,
    [Pregunta12] nvarchar(max)  NULL,
    [Pregunta13] nvarchar(max)  NULL,
    [Pregunta14] nvarchar(max)  NULL,
    [Pregunta15] nvarchar(max)  NULL,
    [Pregunta16] nvarchar(max)  NULL,
    [Pregunta17] nvarchar(max)  NULL,
    [Pregunta18] nvarchar(max)  NULL,
    [Pregunta19] nvarchar(max)  NULL,
    [Pregunta20] nvarchar(max)  NULL,
    [Pregunta21] nvarchar(max)  NULL,
    [Pregunta22] nvarchar(max)  NULL,
    [Pregunta23] nvarchar(max)  NULL,
    [Pregunta24] nvarchar(max)  NULL,
    [Pregunta25] nvarchar(max)  NULL,
    [Pregunta26] nvarchar(max)  NULL,
    [Pregunta27] nvarchar(max)  NULL,
    [Pregunta28] nvarchar(max)  NULL,
    [Pregunta29] nvarchar(max)  NULL,
    [Pregunta30] nvarchar(max)  NULL,
    [Pregunta31] nvarchar(max)  NULL,
    [Pregunta32] nvarchar(max)  NULL,
    [Pregunta33] nvarchar(max)  NULL,
    [Pregunta34] nvarchar(max)  NULL,
    [Pregunta35] nvarchar(max)  NULL,
    [Pregunta36] nvarchar(max)  NULL,
    [Pregunta37] nvarchar(max)  NULL,
    [Pregunta38] nvarchar(max)  NULL,
    [Pregunta39] nvarchar(max)  NULL,
    [Pregunta40] nvarchar(max)  NULL,
    [ExamenIdExamen] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAlumno] in table 'Alumnos'
ALTER TABLE [dbo].[Alumnos]
ADD CONSTRAINT [PK_Alumnos]
    PRIMARY KEY CLUSTERED ([IdAlumno] ASC);
GO

-- Creating primary key on [IdExamen] in table 'Examenes'
ALTER TABLE [dbo].[Examenes]
ADD CONSTRAINT [PK_Examenes]
    PRIMARY KEY CLUSTERED ([IdExamen] ASC);
GO

-- Creating primary key on [IdDetalleExamen] in table 'DetalleExamenes'
ALTER TABLE [dbo].[DetalleExamenes]
ADD CONSTRAINT [PK_DetalleExamenes]
    PRIMARY KEY CLUSTERED ([IdDetalleExamen] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlumnoIdAlumno] in table 'Examenes'
ALTER TABLE [dbo].[Examenes]
ADD CONSTRAINT [FK_AlumnoExamen]
    FOREIGN KEY ([AlumnoIdAlumno])
    REFERENCES [dbo].[Alumnos]
        ([IdAlumno])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlumnoExamen'
CREATE INDEX [IX_FK_AlumnoExamen]
ON [dbo].[Examenes]
    ([AlumnoIdAlumno]);
GO

-- Creating foreign key on [ExamenIdExamen] in table 'DetalleExamenes'
ALTER TABLE [dbo].[DetalleExamenes]
ADD CONSTRAINT [FK_ExamenDetalleExamen]
    FOREIGN KEY ([ExamenIdExamen])
    REFERENCES [dbo].[Examenes]
        ([IdExamen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamenDetalleExamen'
CREATE INDEX [IX_FK_ExamenDetalleExamen]
ON [dbo].[DetalleExamenes]
    ([ExamenIdExamen]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------