using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class PropiedadDA
    {
        public static PropiedadUT InsertarPropiedad(PropiedadUT propiedad, ref MensajeError mensajeError)
        {
            var propiedadUT = new PropiedadUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var propiedadEntity = ConvertirAEntity(propiedad, ref mensajeError);

                    var entityResult = entities.TInfoteca_Propiedad.Add(propiedadEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        propiedadUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Propiedad";
                mensajeError.Mensaje = ex.Message;
            }

            return propiedadUT;
        }

        public static PropiedadUT EditarPropiedad(PropiedadUT propiedad, ref MensajeError mensajeError)
        {
            var propiedadUT = new PropiedadUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var propiedadEntity = ConvertirAEntity(propiedad, ref mensajeError);

                    var entity = entities.TInfoteca_Propiedad.Find(propiedad.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-PropiedadDA";
                        mensajeError.Mensaje = $"PropiedadUT no existe: {propiedad.LintID}";

                        return propiedadUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(propiedadEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        propiedadUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-PropiedadDA";
                mensajeError.Mensaje = ex.Message;
            }

            return propiedadUT;
        }

        public static PropiedadUT BuscarPropiedad(int idPropiedad, ref MensajeError mensajeError)
        {
            var propiedadUT = new PropiedadUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Propiedad.Find(idPropiedad);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-PropiedadDA";
                        mensajeError.Mensaje = $"PropiedadUT no existe: {idPropiedad}";

                        return propiedadUT;
                    }

                    propiedadUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-PropiedadDA";
                mensajeError.Mensaje = ex.Message;
            }

            return propiedadUT;
        }

        public static List<PropiedadUT> BuscarTodosPropiedad(ref MensajeError mensajeError)
        {
            var propiedadUTLista = new List<PropiedadUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Propiedad.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            propiedadUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-PropiedadDA";
                mensajeError.Mensaje = ex.Message;
            }

            return propiedadUTLista;
        }

        public static int BuscarCantidadApariciones(int idPropiedad, ref MensajeError mensajeError)
        {
            var result = 0;

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Persona.Where(p => p.TN_Persona == idPropiedad);
                    result = entity.Count();
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarCantidadApariciones-PropiedadDA";
                mensajeError.Mensaje = ex.Message;
            }

            return result;
        }
        
        public static bool BorrarPropiedad(int IdPropiedad, ref MensajeError mensajeError)
        {
            var propiedadUT = new PropiedadUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Propiedad.Find(IdPropiedad);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-PropiedadDA";
                        mensajeError.Mensaje = $"PropiedadUT no existe: {IdPropiedad}";

                        return false;
                    }

                    //entities.TInfoteca_Propiedad.Remove(entity);
                    entity.TB_Activo = false; // cambiar estado a inactivo
                    entities.Entry(entity).CurrentValues.SetValues(entity);
                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-PropiedadDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        public static PropiedadUT ConvertirAUtilitario(TInfoteca_Propiedad propiedad, ref MensajeError mensajeError)
        {
            try
            {
                var propiedadUT = new PropiedadUT()
                {
                    LintID = propiedad.TN_Id,
                    LstrLugar = propiedad.TC_Ubicacion,
                    LstrTipoPropiedad = propiedad.TC_TipoPropiedad
                };

                return propiedadUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        public static TInfoteca_Propiedad ConvertirAEntity(PropiedadUT propiedad, ref MensajeError mensajeError)
        {
            try
            {
                var propiedadEntity = new TInfoteca_Propiedad()
                {
                    TN_Id = propiedad.LintID > 0 ? propiedad.LintID : 0,
                    TC_Ubicacion = propiedad.LstrLugar,
                    TC_TipoPropiedad = propiedad.LstrTipoPropiedad,
                    TB_Activo = true
                };
                return propiedadEntity;

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