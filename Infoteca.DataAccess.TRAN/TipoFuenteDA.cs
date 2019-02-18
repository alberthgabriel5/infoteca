using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class TipoFuenteDA
    {
        public static TipoFuenteUT InsertarTipoFuente(TipoFuenteUT tipoFuente, ref MensajeError mensajeError)
        {
            var tipoFuenteUT = new TipoFuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var tipoFuenteEntity = ConvertirAEntity(tipoFuente, ref mensajeError);

                    var entityResult = entities.TInfoteca_Tipo_Fuente.Add(tipoFuenteEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        tipoFuenteUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }                                     
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-TipoFuente";
                mensajeError.Mensaje = ex.Message;                
            }

            return tipoFuenteUT;
        }

        public static TipoFuenteUT EditarTipoFuente(TipoFuenteUT tipoFuente, ref MensajeError mensajeError)
        {
            var tipoFuenteUT = new TipoFuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var tipoFuenteEntity = ConvertirAEntity(tipoFuente, ref mensajeError);

                    var entity = entities.TInfoteca_Tipo_Fuente.Find(tipoFuente.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-TipoFuenteDA";
                        mensajeError.Mensaje = $"TipoFuenteUT no existe: {tipoFuente.LintID}";

                        return tipoFuenteUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(tipoFuenteEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        tipoFuenteUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-TipoFuenteDA";
                mensajeError.Mensaje = ex.Message;                
            }

            return tipoFuenteUT;
        }

        public static TipoFuenteUT BuscarTipoFuente(int idTipoFuente, ref MensajeError mensajeError)
        {
            var tipoFuenteUT = new TipoFuenteUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Fuente.Find(idTipoFuente);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-TipoFuenteDA";
                        mensajeError.Mensaje = $"TipoFuenteUT no existe: {idTipoFuente}";

                        return tipoFuenteUT;                        
                    }

                    tipoFuenteUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-TipoFuenteDA";
                mensajeError.Mensaje = ex.Message;
            }

            return tipoFuenteUT;
        }

        public static List<TipoFuenteUT> BuscarTodosTipoFuente(ref MensajeError mensajeError)
        {
            var tipoFuenteUTLista = new List<TipoFuenteUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Fuente.Select(x => x).ToList();                    

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            tipoFuenteUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-TipoFuenteDA";
                mensajeError.Mensaje = ex.Message;
            }

            return tipoFuenteUTLista;
        }

        public static bool BorrarTipoFuente(int idTipoFuente, ref MensajeError mensajeError)
        {

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Fuente.Find(idTipoFuente);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-TipoFuenteDA";
                        mensajeError.Mensaje = $"TipoFuenteUT no existe: {idTipoFuente}";

                        return false;
                    }

                    entities.TInfoteca_Tipo_Fuente.Remove(entity);
                    var result = entities.SaveChanges();

                    return result > 0;               
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-TipoFuenteDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }            
        }

        private static TipoFuenteUT ConvertirAUtilitario(TInfoteca_Tipo_Fuente tipoFuente, ref MensajeError mensajeError)
        {
            try
            {
                var tipoFuenteUT = new TipoFuenteUT()
                {
                    LintID = tipoFuente.TN_Id,
                    LstrNombre = tipoFuente.TC_Nombre,
                    FdtiFechaCreaccion = tipoFuente.TF_Fecha_Creacion.Value
                };

                return tipoFuenteUT;
            }
            catch(Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }            
        }

        private static TInfoteca_Tipo_Fuente ConvertirAEntity(TipoFuenteUT tipoFuente, ref MensajeError mensajeError)
        {
            try
            {
                var tipoFuenteEntity = new TInfoteca_Tipo_Fuente()
                {
                    TN_Id = tipoFuente.LintID > 0 ? tipoFuente.LintID : 0,
                    TC_Nombre = tipoFuente.LstrNombre,
                    TF_Fecha_Creacion = DateTime.Now
                };
                return tipoFuenteEntity;

            }
            catch(Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }
    }
}
