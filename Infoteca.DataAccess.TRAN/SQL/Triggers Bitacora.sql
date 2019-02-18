USE Infoteca;
GO

create trigger Fuente_trigger
on TInfoteca_Fuente
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;

if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

GO

/*-----------------------------------------------------------------------------------------*/

create trigger Imagen_trigger
on TInfoteca_Imagen
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

GO

/*-----------------------------------------------------------------------------------------*/

create trigger Noticia_trigger
on TInfoteca_Noticia
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Noticia_Imagen_trigger
on TInfoteca_Noticia_Imagen
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Persona_trigger
on TInfoteca_Persona
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Persona_Juridica_trigger
on TInfoteca_Persona_Juridica
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Propiedad_trigger
on TInfoteca_Propiedad
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Tipo_Delito_trigger
on TInfoteca_Tipo_Delito
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Tipo_Fuente_trigger
on TInfoteca_Tipo_Fuente
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end
GO

/*-----------------------------------------------------------------------------------------*/


create trigger Vehiculo_trigger
on TInfoteca_Vehiculo
after UPDATE, INSERT, DELETE
as
declare @TN_IdObjeto int;
if exists(SELECT * from inserted) and exists (SELECT * from deleted)
begin
    
    SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists (Select * from inserted) and not exists(Select * from deleted)
begin
   SELECT @TN_IdObjeto = TN_Id from inserted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end

If exists(select * from deleted) and not exists(Select * from inserted)
begin 
    SELECT @TN_IdObjeto = TN_Id from deleted i;
    INSERT into TInfoteca_Bitacora(TC_Operacion, TC_Usuario, TC_Host, TC_Tabla, TN_IdObjeto) values ('UPDATE', @@SERVERNAME, SUSER_NAME(),'TInfoteca_Fuente',@TN_IdObjeto);
end