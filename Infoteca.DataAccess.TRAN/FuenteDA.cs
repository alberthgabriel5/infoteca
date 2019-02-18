using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class FuenteDA
    {
        public static FuenteUT InsertarFuente(FuenteUT fuente, ref MensajeError mensajeError)
        {
            var fuenteUT = new FuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var fuenteEntity = ConvertirAEntity(fuente, ref mensajeError);

                    var entityResult = entities.TInfoteca_Fuente.Add(fuenteEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        fuenteUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Fuente";
                mensajeError.Mensaje = ex.Message;
            }

            return fuenteUT;
        }

        public static FuenteUT EditarFuente(FuenteUT fuente, ref MensajeError mensajeError)
        {
            var fuenteUT = new FuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var fuenteEntity = ConvertirAEntity(fuente, ref mensajeError);

                    var entity = entities.TInfoteca_Fuente.Find(fuente.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-FuenteDA";
                        mensajeError.Mensaje = $"FuenteUT no existe: {fuente.LintID}";

                        return fuenteUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(fuenteEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        fuenteUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-FuenteDA";
                mensajeError.Mensaje = ex.Message;
            }

            return fuenteUT;
        }

        public static FuenteUT BuscarFuente(int IDFuente, ref MensajeError mensajeError)
        {
            var fuenteUT = new FuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Fuente.Find(IDFuente);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-FuenteDA";
                        mensajeError.Mensaje = $"FuenteUT no existe: {IDFuente}";

                        return fuenteUT;
                    }

                    fuenteUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-FuenteDA";
                mensajeError.Mensaje = ex.Message;
            }

            return fuenteUT;
        }

        public static List<FuenteUT> BuscarTodosFuente(ref MensajeError mensajeError)
        {
            var fuenteUTLista = new List<FuenteUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Fuente.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                          fuenteUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-FuenteDA";
                mensajeError.Mensaje = ex.Message;
            }

            return fuenteUTLista;
        }

        public static bool BorrarFuente(int IdFuente, ref MensajeError mensajeError)
        {
            var fuenteUT = new FuenteUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Fuente.Find(IdFuente);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-FuenteDA";
                        mensajeError.Mensaje = $"FuenteUT no existe: {IdFuente}";

                        return false;
                    }

                    entities.TInfoteca_Fuente.Remove(entity);
                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-FuenteDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        private static FuenteUT ConvertirAUtilitario(TInfoteca_Fuente fuente, ref MensajeError mensajeError)
        {
            try
            {
                var fuenteUT = new FuenteUT()
                {
                    LintID = fuente.TN_Id,
                    LstrNombreFuente = fuente.TC_Nombre,
                    LstrTitulo = fuente.TC_Titulo,
                    LstrSubTitulo = fuente.TC_Sub_Titulo,
                    LobjTipoFuente = TipoFuenteDA.BuscarTipoFuente(fuente.TN_Tipo_Fuente, ref mensajeError),
                    LbytActivo = fuente.TB_Activo
                    
                };

                return fuenteUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        private static TInfoteca_Fuente ConvertirAEntity(FuenteUT fuente, ref MensajeError mensajeError)
        {
            try
            {
                var fuenteEntity = new TInfoteca_Fuente()
                {
                    TN_Id = fuente.LintID > 0 ? fuente.LintID : 0,
                    TC_Nombre = fuente.LstrNombreFuente,
                    TC_Titulo = fuente.LstrTitulo,
                    TC_Sub_Titulo = fuente.LstrSubTitulo,
                    TN_Tipo_Fuente = fuente.LobjTipoFuente.LintID,
                    TF_Fecha_Creacion = DateTime.Now,
                    TB_Activo = fuente.LbytActivo
                };
                return fuenteEntity;

            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }
    }
}

