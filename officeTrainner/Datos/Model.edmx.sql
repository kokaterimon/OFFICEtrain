
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/30/2018 14:10:38
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
    [Avance] int  NULL,
    [AlumnoIdAlumno] int  NOT NULL,
    [NumeroDePreguntas] nvarchar(max)  NOT NULL,
    [DetalleExaman_IdDetalleExamen] int  NOT NULL
);
GO

-- Creating table 'DetalleExamenes'
CREATE TABLE [dbo].[DetalleExamenes] (
    [IdDetalleExamen] int IDENTITY(1,1) NOT NULL,
    [Pregunta1] nvarchar(max)  NOT NULL,
    [Pregunta2] nvarchar(max)  NOT NULL,
    [Pregunta3] nvarchar(max)  NOT NULL,
    [Pregunta4] nvarchar(max)  NOT NULL,
    [Pregunta5] nvarchar(max)  NOT NULL,
    [Pregunta6] nvarchar(max)  NOT NULL,
    [Pregunta7] nvarchar(max)  NOT NULL,
    [Pregunta8] nvarchar(max)  NOT NULL,
    [Pregunta9] nvarchar(max)  NOT NULL,
    [Pregunta10] nvarchar(max)  NOT NULL,
    [Pregunta11] nvarchar(max)  NOT NULL,
    [Pregunta12] nvarchar(max)  NOT NULL,
    [Pregunta13] nvarchar(max)  NOT NULL,
    [Pregunta14] nvarchar(max)  NOT NULL,
    [Pregunta15] nvarchar(max)  NOT NULL,
    [Pregunta16] nvarchar(max)  NOT NULL,
    [Pregunta17] nvarchar(max)  NOT NULL,
    [Pregunta18] nvarchar(max)  NOT NULL,
    [Pregunta19] nvarchar(max)  NOT NULL,
    [Pregunta20] nvarchar(max)  NOT NULL,
    [Pregunta21] nvarchar(max)  NOT NULL,
    [Pregunta22] nvarchar(max)  NOT NULL,
    [Pregunta23] nvarchar(max)  NOT NULL,
    [Pregunta24] nvarchar(max)  NOT NULL,
    [Pregunta25] nvarchar(max)  NOT NULL,
    [Pregunta26] nvarchar(max)  NOT NULL,
    [Pregunta27] nvarchar(max)  NOT NULL,
    [Pregunta28] nvarchar(max)  NOT NULL,
    [Pregunta29] nvarchar(max)  NOT NULL,
    [Pregunta30] nvarchar(max)  NOT NULL,
    [Pregunta31] nvarchar(max)  NOT NULL,
    [Pregunta32] nvarchar(max)  NOT NULL,
    [Pregunta33] nvarchar(max)  NOT NULL,
    [Pregunta34] nvarchar(max)  NOT NULL,
    [Pregunta35] nvarchar(max)  NOT NULL,
    [Pregunta36] nvarchar(max)  NOT NULL,
    [Pregunta37] nvarchar(max)  NOT NULL,
    [Pregunta38] nvarchar(max)  NOT NULL,
    [Pregunta39] nvarchar(max)  NOT NULL,
    [Pregunta40] nvarchar(max)  NOT NULL
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

-- Creating foreign key on [DetalleExaman_IdDetalleExamen] in table 'Examenes'
ALTER TABLE [dbo].[Examenes]
ADD CONSTRAINT [FK_ExamenDetalleExamen]
    FOREIGN KEY ([DetalleExaman_IdDetalleExamen])
    REFERENCES [dbo].[DetalleExamenes]
        ([IdDetalleExamen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamenDetalleExamen'
CREATE INDEX [IX_FK_ExamenDetalleExamen]
ON [dbo].[Examenes]
    ([DetalleExaman_IdDetalleExamen]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------