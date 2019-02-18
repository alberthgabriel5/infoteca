Use Infoteca
GO

CREATE PROCEDURE PInfoteca_BuscarNoticiaPorFechas
@fecha_inicio DATETIME,
@fecha_fin DATETIME
AS
Declare @aux DATETIME;
BEGIN

	IF(@fecha_inicio>@fecha_fin) BEGIN
		SET @aux = @fecha_fin;
		SET @fecha_fin = @fecha_inicio;
		SET @fecha_inicio = @aux;
	END

	SELECT 
		TN_Id
		,TF_Fecha_Evento
		,TC_Descripcion
		,TC_Sub_Delito
		,TC_Palabras_Clave
		,TF_Fecha_Creacion
		,TN_Id_Tipo_Delito
		,TN_Id_Fuente
		,TB_Activo
	FROM Infoteca.dbo.TInfoteca_Noticia
	WHERE TF_Fecha_Evento >= @fecha_inicio and TF_Fecha_Evento <= @fecha_fin;
end
