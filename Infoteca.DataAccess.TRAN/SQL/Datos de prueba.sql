Use Infoteca
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Asalto'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Trafico de drogas'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Secuestro'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Homicidio'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Violencia domestica'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Delito]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Extorsión'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Fuente]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Medio Digital'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Fuente]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Red social'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Tipo_Fuente]
           ([TC_Nombre]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           ('Periodico'
           ,GETDATE()
		   ,1)
GO


INSERT INTO [Infoteca].[dbo].[TInfoteca_Fuente]
           ([TN_Tipo_Fuente]
		  ,[TC_Nombre]
		  ,[TC_Titulo]
		  ,[TC_Sub_Titulo]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           (2
           ,'La Teja'
           ,'Edicion Digital'
           ,'Sucesos'
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Fuente]
           ([TN_Tipo_Fuente]
		  ,[TC_Nombre]
		  ,[TC_Titulo]
		  ,[TC_Sub_Titulo]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           (3
           ,'Extra'
           ,'Edicion Digital'
           ,''
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Fuente]
           ([TN_Tipo_Fuente]
		  ,[TC_Nombre]
		  ,[TC_Titulo]
		  ,[TC_Sub_Titulo]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           (3
           ,'La Nacion'
           ,'Edicion Digital'
           ,''
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Fuente]
           ([TN_Tipo_Fuente]
		  ,[TC_Nombre]
		  ,[TC_Titulo]
		  ,[TC_Sub_Titulo]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           (2
           ,'Facebook'
           ,'Edicion Digital'
           ,''
           ,GETDATE()
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Fuente]
           ([TN_Tipo_Fuente]
		  ,[TC_Nombre]
		  ,[TC_Titulo]
		  ,[TC_Sub_Titulo]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
     VALUES
           (2
           ,'Twitter'
           ,'Edicion Digital'
           ,''
           ,GETDATE()
		   ,1)
GO


INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/05/10'
           ,'Asesinato de vicepresidente de Costa Rica'
           ,'Homicidio'
           ,'muerte,asesinato,homicidio'
           ,GETDATE()
		   ,4
		   ,1
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/01/15'
           ,'Atraco en supermercado'
           ,'Robo'
           ,'robo,asalto,atraco'
           ,GETDATE()
		   ,1
		   ,2
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/01/20'
           ,'Bomba explota en San Jose'
           ,'Homicidio'
           ,'bomba,explosion,asesinato,homicidio,muerte'
           ,GETDATE()
		   ,4
		   ,3
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/01/20'
           ,'Secuestran niña'
           ,'Secuestro'
           ,'secuestro,rapto,desaparicion,perdida,niña'
           ,GETDATE()
		   ,3
		   ,4
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/09/20'
           ,'Roban la casa del presidente'
           ,'Robo'
           ,'robo,asalto,presidente,roban'
           ,GETDATE()
		   ,1
		   ,5
		   ,1)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia]
           ([TF_Fecha_Evento]
		  ,[TC_Descripcion]
		  ,[TC_Sub_Delito]
		  ,[TC_Palabras_Clave]
		  ,[TF_Fecha_Creacion]
		  ,[TN_Id_Tipo_Delito]
		  ,[TN_Id_Fuente]
		  ,[TB_Activo])
     VALUES
           ('2018/03/11'
           ,'Extoricionan usuarios de Twitter'
           ,'Extorsion'
           ,'extorsion,twitter,usuario'
           ,GETDATE()
		   ,6
		   ,3
		   ,6)
GO

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Pedro'
		   ,'Rojas'
		   ,'Paco'
		   ,'Cedula'
		   ,'12345678'
		   ,GETDATE()
		   ,1)

		   INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Carlos'
		   ,'Perez'
		   ,''
		   ,'Cedula'
		   ,'87654321'
		   ,GETDATE()
		   ,1)
		   
INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Juan'
		   ,'Mora'
		   ,'Juanito'
		   ,'Cedula'
		   ,'111111'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Jaime'
		   ,'Mendez'
		   ,''
		   ,'Cedula'
		   ,'2222222'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Karla'
		   ,'Solano'
		   ,''
		   ,'Cedula'
		   ,'333333'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Maria'
		   ,'Perez'
		   ,'La maria'
		   ,'Cedula'
		   ,'4444444'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Francisco'
		   ,'Lopez'
		   ,'Pancho'
		   ,'Cedula'
		   ,'5555555'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Jose'
		   ,'Garza'
		   ,''
		   ,'Cedula'
		   ,'6666666'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona]
		   ([TC_Nombre]
		  ,[TC_Apellido]
		  ,[TC_Alias]
		  ,[TC_TipoIdentificacion]
		  ,[TC_Identificacion]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Lucia'
		   ,'Cerdas'
		   ,''
		   ,'Cedula'
		   ,'777777'
		   ,GETDATE()
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Propiedad]
		   ([TC_Ubicacion]
		   ,[TC_TipoPropiedad]
		   ,[TB_Activo])
	VALUES
           ('San Jose, centro'
           ,'Otro'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Propiedad]
		   ([TC_Ubicacion]
		   ,[TC_TipoPropiedad]
		   ,[TB_Activo])
	VALUES
           ('Casa presidencial'
           ,'Casa de habitación'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Propiedad]
		   ([TC_Ubicacion],
		   [TC_TipoPropiedad]
		   ,[TB_Activo])
	VALUES
           ('Local Chino, Cartago'
           ,'Espacio comercial'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Persona_Juridica]
		   ([TC_Nombre]
		  ,[TC_Nombre_Fantasia]
		  ,[TC_Cedula]
		  ,[TF_Fecha_Creacion]
		  ,[TB_Activo])
	VALUES
           ('Super fantasia S.A.'
		   ,'Super fantasia'
		   ,'111111'
		   ,GETDATE()
		   ,1)
		  
INSERT INTO [Infoteca].[dbo].[TInfoteca_Vehiculo]
		   ([TC_Placa]
		  ,[TC_Marca]
		  ,[TC_Modelo]
		  ,[TC_Color]
		  ,[TB_Activo])
	VALUES
           ('SA-1111'
		   ,'Toyota'
		   ,'Hilux'
		   ,'Negro'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Vehiculo]
		   ([TC_Placa]
		  ,[TC_Marca]
		  ,[TC_Modelo]
		  ,[TC_Color]
		  ,[TB_Activo])
	VALUES
           ('CA-22222'
		   ,'Honda'
		   ,''
		   ,'rojo'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Vehiculo]
		   ([TC_Placa]
		  ,[TC_Marca]
		  ,[TC_Modelo]
		  ,[TC_Color]
		  ,[TB_Activo])
	VALUES
           ('Li-3333'
		   ,'Toyota'
		   ,'md-01'
		   ,'negro'
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (1
		   ,1
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (2
		   ,2
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (2
		   ,3
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (4
		   ,5
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (5
		   ,4
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (5
		   ,6
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Persona]
		   ([TN_Noticia]
		  ,[TN_Persona]
		  ,[TB_Activo])
	VALUES
           (6
		   ,7
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Juridica]
		   ([TN_Noticia]
		  ,[TN_Juridica]
		  ,[TB_Activo])
	VALUES
           (2
		   ,1
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Propiedad]
		   ([TN_Noticia]
		  ,[TN_Propiedad]
		  ,[TB_Activo])
	VALUES
           (2
		   ,3
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Propiedad]
		   ([TN_Noticia]
		  ,[TN_Propiedad]
		  ,[TB_Activo])
	VALUES
           (1
		   ,2
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Propiedad]
		   ([TN_Noticia]
		  ,[TN_Propiedad]
		  ,[TB_Activo])
	VALUES
           (5
		   ,2
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Propiedad]
		   ([TN_Noticia]
		  ,[TN_Propiedad]
		  ,[TB_Activo])
	VALUES
           (3
		   ,1
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Propiedad]
		   ([TN_Noticia]
		  ,[TN_Propiedad]
		  ,[TB_Activo])
	VALUES
           (4
		   ,1
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Vehiculo]
		   ([TN_Noticia]
		  ,[TN_Vehiculo]
		  ,[TB_Activo])
	VALUES
           (4
		   ,1
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Vehiculo]
		   ([TN_Noticia]
		  ,[TN_Vehiculo]
		  ,[TB_Activo])
	VALUES
           (2
		   ,2
		   ,1)

INSERT INTO [Infoteca].[dbo].[TInfoteca_Noticia_Vehiculo]
		   ([TN_Noticia]
		  ,[TN_Vehiculo]
		  ,[TB_Activo])
	VALUES
           (5
		   ,3
		   ,1)