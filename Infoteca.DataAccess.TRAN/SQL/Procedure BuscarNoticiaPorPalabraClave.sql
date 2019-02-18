Use Infoteca
GO

CREATE PROCEDURE PInfoteca_BuscarNoticiaPorPalabrasClave
@Tag VARCHAR(MAX)
AS
BEGIN
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
	WHERE	(SELECT count(tag) FROM dbo.splitstring(TC_Palabras_Clave) where tag LIKE '%'+@Tag+'%') > 0
			OR TC_Descripcion LIKE '%'+@Tag+'%'
			OR TC_Sub_Delito LIKE '%'+@Tag+'%'
			OR TN_Id_Tipo_Delito = (SELECT TN_Id FROM TInfoteca_Tipo_Delito WHERE TN_Id = TN_Id_Tipo_Delito AND TC_Nombre LIKE '%'+@Tag+'%')
END
