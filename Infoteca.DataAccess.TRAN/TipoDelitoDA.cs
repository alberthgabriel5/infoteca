using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class TipoDelitoDA
    {
        public static TipoDelitoUT InsertarTipoDelito(TipoDelitoUT tipoDelito, ref MensajeError mensajeError)
        {
            var tipoDelitoUT = new TipoDelitoUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var tipoDelitoEntity = ConvertirAEntity(tipoDelito, ref mensajeError);

                    var entityResult = entities.TInfoteca_Tipo_Delito.Add(tipoDelitoEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        tipoDelitoUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }                                     
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-TipoDelito";
                mensajeError.Mensaje = ex.Message;                
            }

            return tipoDelitoUT;
        }

        public static TipoDelitoUT EditarTipoDelito(TipoDelitoUT tipoDelito, ref MensajeError mensajeError)
        {
            var tipoDelitoUT = new TipoDelitoUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var tipoDelitoEntity = ConvertirAEntity(tipoDelito, ref mensajeError);

                    var entity = entities.TInfoteca_Tipo_Delito.Find(tipoDelito.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-TipoDelitoDA";
                        mensajeError.Mensaje = $"TipoDelitoUT no existe: {tipoDelito.LintID}";

                        return tipoDelitoUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(tipoDelitoEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        tipoDelitoUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-TipoDelitoDA";
                mensajeError.Mensaje = ex.Message;                
            }

            return tipoDelitoUT;
        }

        public static TipoDelitoUT BuscarTipoDelito(int idTipoDelito, ref MensajeError mensajeError)
        {
            var tipoDelitoUT = new TipoDelitoUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Delito.Find(idTipoDelito);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-TipoDelitoDA";
                        mensajeError.Mensaje = $"TipoDelitoUT no existe: {idTipoDelito}";

                        return tipoDelitoUT;                        
                    }

                    tipoDelitoUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-TipoDelitoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return tipoDelitoUT;
        }

        public static List<TipoDelitoUT> BuscarTodosTipoDelito(ref MensajeError mensajeError)
        {
            List<TipoDelitoUT> tipoDelitoUTLista = new List<TipoDelitoUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Delito.Select(x => x).ToList();                    

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            tipoDelitoUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-TipoDelitoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return tipoDelitoUTLista;
        }

        public static bool BorrarTipoDelito(int idTipoDelito, ref MensajeError mensajeError)
        {

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Tipo_Delito.Find(idTipoDelito);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-TipoDelitoDA";
                        mensajeError.Mensaje = $"TipoDelitoUT no existe: {idTipoDelito}";

                        return false;
                    }

                    entities.TInfoteca_Tipo_Delito.Remove(entity);
                    var result = entities.SaveChanges();

                    return result > 0;               
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-TipoDelitoDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }            
        }

        private static TipoDelitoUT ConvertirAUtilitario(TInfoteca_Tipo_Delito tipoDelito, ref MensajeError mensajeError)
        {
            try
            {
                var tipoDelitoUT = new TipoDelitoUT()
                {
                    LintID = tipoDelito.TN_Id,
                    LstrNombre = tipoDelito.TC_Nombre,
                    FdtiFechaCreaccion = tipoDelito.TF_Fecha_Creacion.Value
                    
                };

                return tipoDelitoUT;
            }
            catch(Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }            
        }

        private static TInfoteca_Tipo_Delito ConvertirAEntity(TipoDelitoUT tipoDelito, ref MensajeError mensajeError)
        {
            try
            {
                var tipoDelitoEntity = new TInfoteca_Tipo_Delito()
                {
                    TN_Id = tipoDelito.LintID > 0 ? tipoDelito.LintID : 0,
                    TC_Nombre = tipoDelito.LstrNombre,
                    TF_Fecha_Creacion = DateTime.Now,
                    TB_Activo = tipoDelito.LbytActivo == 1 ? true : false
                };
                return tipoDelitoEntity;

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
