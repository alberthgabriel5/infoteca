using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class BitacoraDA
    {
        public static BitacoraUT InsertarBitacora(BitacoraUT bitacora, ref MensajeError mensajeError)
        {
            var bitacoraUT = new BitacoraUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var bitacoraEntity = ConvertirAEntity(bitacora, ref mensajeError);

                    var entityResult = entities.TInfoteca_Bitacora.Add(bitacoraEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        bitacoraUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Bitacora";
                mensajeError.Mensaje = ex.Message;
            }

            return bitacoraUT;
        }

        public static BitacoraUT EditarBitacora(BitacoraUT bitacora, ref MensajeError mensajeError)
        {
            var bitacoraUT = new BitacoraUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var bitacoraEntity = ConvertirAEntity(bitacora, ref mensajeError);

                    var entity = entities.TInfoteca_Bitacora.Find(bitacora.TN_Id);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-BitacoraDA";
                        mensajeError.Mensaje = $"BitacoraUT no existe: {bitacora.TN_Id}";

                        return bitacoraUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(bitacoraEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        bitacoraUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-BitacoraDA";
                mensajeError.Mensaje = ex.Message;
            }

            return bitacoraUT;
        }

        public static BitacoraUT BuscarBitacora(int IDBitacora, ref MensajeError mensajeError)
        {
            var bitacoraUT = new BitacoraUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Bitacora.Find(IDBitacora);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-BitacoraDA";
                        mensajeError.Mensaje = $"BitacoraUT no existe: {IDBitacora}";

                        return bitacoraUT;
                    }

                    bitacoraUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-BitacoraDA";
                mensajeError.Mensaje = ex.Message;
            }

            return bitacoraUT;
        }

        public static List<BitacoraUT> BuscarTodosBitacora(ref MensajeError mensajeError)
        {
            var bitacoraUTLista = new List<BitacoraUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Bitacora.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                          bitacoraUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-BitacoraDA";
                mensajeError.Mensaje = ex.Message;
            }

            return bitacoraUTLista;
        }

        public static bool BorrarBitacora(int IdBitacora, ref MensajeError mensajeError)
        {
            var bitacoraUT = new BitacoraUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Bitacora.Find(IdBitacora);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-BitacoraDA";
                        mensajeError.Mensaje = $"BitacoraUT no existe: {IdBitacora}";

                        return false;
                    }

                    entities.TInfoteca_Bitacora.Remove(entity);
                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-BitacoraDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        private static BitacoraUT ConvertirAUtilitario(TInfoteca_Bitacora bitacora, ref MensajeError mensajeError)
        {
            try
            {
                var bitacoraUT = new BitacoraUT()
                {
                    TN_Id = bitacora.TN_Id,
                    TB_Activo = bitacora.TB_Activo,
                    TC_Host = bitacora.TC_Host,
                    TC_Usuario = bitacora.TC_Usuario,
                    TC_Tabla = bitacora.TC_Tabla,
                    TD_Modificado = bitacora.TD_Modificado,
                    TC_Operacion = bitacora.TC_Operacion,
                    TN_IdObjeto = bitacora.TN_IdObjeto
                };

                return bitacoraUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        private static TInfoteca_Bitacora ConvertirAEntity(BitacoraUT bitacora, ref MensajeError mensajeError)
        {
            try
            {
                var bitacoraEntity = new TInfoteca_Bitacora()
                {
                    TN_Id = bitacora.TN_Id,
                    TB_Activo = bitacora.TB_Activo,
                    TC_Host = bitacora.TC_Host,
                    TC_Usuario = bitacora.TC_Usuario,
                    TC_Tabla = bitacora.TC_Tabla,
                    TD_Modificado = bitacora.TD_Modificado,
                    TC_Operacion = bitacora.TC_Operacion,
                    TN_IdObjeto = bitacora.TN_IdObjeto
                };
                return bitacoraEntity;

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

