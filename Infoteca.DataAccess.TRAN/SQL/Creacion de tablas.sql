/**
create database Infoteca;
use Infoteca;
drop table [dbo].TInfoteca_Bitacora;
drop table [dbo].TInfoteca_Noticia_Imagen;
drop table [dbo].[TInfoteca_Noticia_Juridica];
drop table [dbo].[TInfoteca_Noticia_Persona];
drop table [dbo].[TInfoteca_Noticia_Propiedad];
drop table [dbo].[TInfoteca_Noticia_Vehiculo]
drop table [dbo].[TInfoteca_Noticia];
drop table [dbo].[TInfoteca_Persona];
drop table [dbo].[TInfoteca_Persona_Juridica];
drop table [dbo].[TInfoteca_Imagen];
drop table [dbo].[TInfoteca_Fuente];
drop table [dbo].[TInfoteca_Propiedad];
drop table [dbo].[TInfoteca_Tipo_Delito];
drop table [dbo].[TInfoteca_Tipo_Fuente];
drop table [dbo].[TInfoteca_Vehiculo];
drop table [dbo].[TInfoteca_Mensaje]
*/
USE [Infoteca]
GO
/****** Object:  Table [dbo].[TInfoteca_Vehiculo]    Script Date: 10/20/2018 21:09:24 ******/
/******T + Tipo de dato + “_” + Nombre Significativo + “_” + Nombre Tabla***/
CREATE TABLE [dbo].[TInfoteca_Vehiculo](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Placa] [varchar](50) NULL,
	[TC_Marca] [varchar](50) NULL,
	[TC_Modelo] [varchar](50) NULL,
	[TC_Color] [varchar](50) NULL,
	[TN_Id_Estilo] [varchar](50) NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Tipo_Fuente]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Tipo_Fuente](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Nombre] [varchar](50) NOT NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Tipo_Delito]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Tipo_Delito](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Nombre] [varchar](50) NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Propiedad]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Propiedad](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_TipoPropiedad] [varchar](200) NULL,
	[TC_Ubicacion] [varchar](200) NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
	
/****** Object:  Table [dbo].[TInfoteca_Persona_Juridica]    Script Date: 10/20/2018 21:09:24 ******/
CREATE TABLE [dbo].[TInfoteca_Persona_Juridica](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Nombre] [varchar](50) NULL,
	[TC_Nombre_Fantasia] [varchar](50) NULL,
	[TC_Cedula] [varchar](50) NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Persona]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Persona](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Nombre] [varchar](50) NULL,
	[TC_Apellido] [varchar](50) NULL,
	[TC_Alias] [varchar](50) NULL,
	[TC_TipoIdentificacion] [varchar](50) NULL,
	[TC_Identificacion] [varchar](50) NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Imagen]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Imagen](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TC_Nombre] [varchar](150) NOT NULL,
	[TI_Imagen] [image] NOT NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Noticia]    Script Date: 10/20/2018 21:09:24 ******/
CREATE TABLE [dbo].[TInfoteca_Noticia](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TF_Fecha_Evento] [datetime] NOT NULL,
	[TC_Descripcion] [varchar](200) NOT NULL,
	[TC_Sub_Delito] [varchar](200) NULL,
	[TC_Palabras_Clave] [varchar](max) NOT NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TN_Id_Tipo_Delito] [int] NOT NULL,
	[TN_Id_Fuente] [int] NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Fuente]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Fuente](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TN_Tipo_Fuente] [int] NOT NULL,
	[TC_Nombre] [varchar](50) NOT NULL,
	[TC_Titulo] [varchar](200) NULL,
	[TC_Sub_Titulo] [varchar](200) NULL,
	[TF_Fecha_Creacion] [datetime] NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
/****** Object:  Table [dbo].[TInfoteca_Noticia_Imagen]    Script Date: 10/20/2018 21:09:24 ******/

CREATE TABLE [dbo].[TInfoteca_Noticia_Imagen](
	[TN_Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[TN_Id_Noticia] [int] NOT NULL,
	[TN_Id_Imagen] [int] NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE dbo.TInfoteca_Noticia_Persona(
	TN_Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TN_Noticia int NOT NULL,
	TN_Persona int NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));
	

CREATE TABLE dbo.TInfoteca_Noticia_Vehiculo(
	
	TN_Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TN_Noticia int NOT NULL,
	TN_Vehiculo int NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE dbo.TInfoteca_Noticia_Propiedad(
	TN_Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TN_Noticia int NOT NULL,
	TN_Propiedad int NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE dbo.TInfoteca_Noticia_Juridica	(
	TN_Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TN_Noticia int NOT NULL,
	TN_Juridica int NOT NULL,
	[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE TInfoteca_Bitacora(
TN_Id int identity(1,1) not null PRIMARY KEY,
TC_Operacion varchar(max) default null,
TC_Usuario varchar(100) default null,
TC_Host varchar(100) Not null,
TD_Modificado datetime NOT NULL DEFAULT GETDATE(),
TC_Tabla varchar(100) not null,
TN_IdObjeto int not null,
[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE TInfoteca_Mensaje(
TN_ID int identity(1,1) not null PRIMARY KEY,
TC_Formato varchar(50) null,
TC_Accion varchar(50) null,
TC_Tabla varchar(50) null,
TC_Mensaje varchar (200) null,
[TB_Activo] [bit] NOT NULL DEFAULT (1));

CREATE TABLE TInfoteca_Usuario(
TN_ID int identity(1,1) not null PRIMARY KEY,
TC_Usuario varchar(50) null,
TC_Idetificacion varchar(50) null,
TC_Nombre varchar(50) null,
TC_PriApellido varchar(50) null,
TC_SegApellido varchar(50) null,
TC_Tipo_Autentificacion varchar(50) null,
TC_Tipo_Usuario varchar(50) null,
TC_Email varchar(50) null,
TN_Intentos int default 0,
TC_Usuario_Actualiza varchar(50) null,
TF_FecActualiza datetime default GetDate(),
TC_Observaciones varchar(250) null,
TC_Eliminado [bit] NOT NULL DEFAULT (0),
TC_Tipo_Identificacion_ID varchar(50) null,
	TC_Institucion_ID varchar(50) null,
TC_Oficina_ID varchar(50) null,
[TB_Activo] [bit] NOT NULL DEFAULT (1));


/****** Object:  ForeignKey [FK_TInfoteca_Fuente_TInfoteca_Tipo_Fuente]    Script Date: 10/20/2018 21:09:24 ******/
ALTER TABLE [dbo].[TInfoteca_Fuente]  WITH CHECK ADD  CONSTRAINT [FK_TInfoteca_Fuente_TInfoteca_Tipo_Fuente] FOREIGN KEY([TN_Tipo_Fuente])
REFERENCES [dbo].[TInfoteca_Tipo_Fuente] ([TN_Id])
GO
ALTER TABLE [dbo].[TInfoteca_Fuente] CHECK CONSTRAINT [FK_TInfoteca_Fuente_TInfoteca_Tipo_Fuente]
GO
/****** Object:  ForeignKey [FK_TInfoteca_Noticia_TInfoteca_Tipo_Delito]    Script Date: 10/20/2018 21:09:24 ******/
ALTER TABLE [dbo].[TInfoteca_Noticia]  WITH CHECK ADD  CONSTRAINT [FK_TInfoteca_Noticia_TInfoteca_Tipo_Delito] FOREIGN KEY([TN_Id_Tipo_Delito])
REFERENCES [dbo].[TInfoteca_Tipo_Delito] ([TN_Id])
GO
ALTER TABLE [dbo].[TInfoteca_Noticia] CHECK CONSTRAINT [FK_TInfoteca_Noticia_TInfoteca_Tipo_Delito]
GO
/****** Object:  ForeignKey [FK_TInfoteca_Noticia_Imagen_TInfoteca_Imagen]    Script Date: 10/20/2018 21:09:24 ******/
ALTER TABLE [dbo].[TInfoteca_Noticia_Imagen]  WITH CHECK ADD  CONSTRAINT [FK_TInfoteca_Noticia_Imagen_TInfoteca_Imagen] FOREIGN KEY([TN_Id_Imagen])
REFERENCES [dbo].[TInfoteca_Imagen] ([TN_Id])
GO
ALTER TABLE [dbo].[TInfoteca_Noticia_Imagen] CHECK CONSTRAINT [FK_TInfoteca_Noticia_Imagen_TInfoteca_Imagen]
GO
/****** Object:  ForeignKey [FK_TInfoteca_Noticia_Imagen_TInfoteca_Noticia]    Script Date: 10/20/2018 21:09:24 ******/
ALTER TABLE [dbo].[TInfoteca_Noticia_Imagen]  WITH CHECK ADD  CONSTRAINT [FK_TInfoteca_Noticia_Imagen_TInfoteca_Noticia] FOREIGN KEY([TN_Id_Noticia])
REFERENCES [dbo].[TInfoteca_Noticia] ([TN_Id])
GO
ALTER TABLE [dbo].[TInfoteca_Noticia_Imagen] CHECK CONSTRAINT [FK_TInfoteca_Noticia_Imagen_TInfoteca_Noticia]
GO
/****** Object:  ForeignKey [FK_TInfoteca_Noticia_Imagen_TInfoteca_Noticia]    Script Date: 10/25/2018 17:30:25 ******/
ALTER TABLE dbo.TInfoteca_Noticia WITH CHECK ADD CONSTRAINT FK_TInfoteca_Noticia_TInfoteca_Tipo_Fuente FOREIGN KEY 	(TN_Id_Fuente) 
REFERENCES dbo.TInfoteca_Fuente	(TN_Id) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO


ALTER TABLE dbo.TInfoteca_Noticia_Persona ADD CONSTRAINT
	FK_TInfoteca_Noticia_Persona_TInfoteca_Noticia FOREIGN KEY	(
	TN_Noticia) REFERENCES dbo.TInfoteca_Noticia(TN_Id) 
	ON UPDATE  NO ACTION 	ON DELETE  NO ACTION 	
GO
ALTER TABLE dbo.TInfoteca_Noticia_Persona ADD CONSTRAINT
	FK_TInfoteca_Noticia_Persona_TInfoteca_Persona FOREIGN KEY	(
	TN_Persona	) REFERENCES dbo.TInfoteca_Persona
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Vehiculo ADD CONSTRAINT
	FK_TInfoteca_Noticia_Vehiculo_TInfoteca_Noticia FOREIGN KEY	
	(TN_Noticia	) REFERENCES dbo.TInfoteca_Noticia
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Vehiculo ADD CONSTRAINT
	FK_TInfoteca_Noticia_Vehiculo_TInfoteca_Vehiculo FOREIGN KEY
	(	TN_Vehiculo	) REFERENCES dbo.TInfoteca_Vehiculo	(	
	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Propiedad ADD CONSTRAINT
	FK_TInfoteca_Noticia_Propiedad_TInfoteca_Noticia FOREIGN KEY
	(	TN_Noticia	) REFERENCES dbo.TInfoteca_Noticia	
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Propiedad ADD CONSTRAINT
	FK_TInfoteca_Noticia_Propiedad_TInfoteca_Propiedad FOREIGN KEY
	( 	TN_Propiedad	) REFERENCES dbo.TInfoteca_Propiedad
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Juridica ADD CONSTRAINT
	FK_TInfoteca_Noticia_Juridica_TInfoteca_Noticia FOREIGN KEY
	(	TN_Noticia	) REFERENCES dbo.TInfoteca_Noticia
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO

ALTER TABLE dbo.TInfoteca_Noticia_Juridica ADD CONSTRAINT
	FK_TInfoteca_Noticia_Juridica_TInfoteca_Persona_Juridica FOREIGN KEY
	(	TN_Juridica	) REFERENCES dbo.TInfoteca_Persona_Juridica
	(	TN_Id	) ON UPDATE  NO ACTION 	 ON DELETE  NO ACTION 	
GO
checkpoint;