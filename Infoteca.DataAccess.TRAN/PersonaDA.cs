using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class PersonaDA
    {
        public static PersonaUT InsertarPersona(PersonaUT persona, ref MensajeError mensajeError)
        {
            var personaUT = new PersonaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var personaEntity = ConvertirAEntity(persona, ref mensajeError);

                    var entityResult = entities.TInfoteca_Persona.Add(personaEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        personaUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-TipoDelito";
                mensajeError.Mensaje = ex.Message;
            }

            return personaUT;
        }

        public static PersonaUT EditarPersona(PersonaUT persona, ref MensajeError mensajeError)
        {
            var personaUT = new PersonaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var personaEntity = ConvertirAEntity(persona, ref mensajeError);

                    var entity = entities.TInfoteca_Persona.Find(persona.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-PersonaDA";
                        mensajeError.Mensaje = $"PersonaUT no existe: {persona.LintID}";

                        return personaUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(personaEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        personaUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-PersonaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaUT;
        }

        public static PersonaUT BuscarPersona(int idPersona, ref MensajeError mensajeError)
        {
            var personaUT = new PersonaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona.Find(idPersona);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-PersonaDA";
                        mensajeError.Mensaje = $"PersonaUT no existe: {idPersona}";

                        return personaUT;
                    }

                    personaUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-PersonaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaUT;
        }

        public static List<PersonaUT> BuscarTodosPersona(ref MensajeError mensajeError)
        {
            var personaUTLista = new List<PersonaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            personaUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-PersonaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaUTLista;
        }

        public static int BuscarCantidadApariciones(int idPersona, ref MensajeError mensajeError)
        {
            var result = 0;

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Persona.Where(p=>p.TN_Persona == idPersona);
                    result = entity.Count();
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-PersonaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return result;
        }

        public static bool BorrarPersona(int idPersona, ref MensajeError mensajeError)
        {

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona.Find(idPersona);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-PersonaDA";
                        mensajeError.Mensaje = $"PersonaUT no existe: {idPersona}";

                        return false;
                    }

                    //entities.TInfoteca_Persona.Remove(entity);
                    entity.TB_Activo = false; // cambiar estado a inactivo
                    entities.Entry(entity).CurrentValues.SetValues(entity);
                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-PersonaDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        public static PersonaUT ConvertirAUtilitario(TInfoteca_Persona persona, ref MensajeError mensajeError)
        {
            try
            {
                var personaUT = new PersonaUT()
                {
                    LintID = persona.TN_Id,
                    LstrNombre = persona.TC_Nombre,
                    LstrApelido = persona.TC_Apellido,
                    LstrAlias = persona.TC_Alias,
                    LstrCedula = persona.TC_Identificacion,
                    LstrTipoIdentificacion = persona.TC_TipoIdentificacion
                };

                return personaUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        public static TInfoteca_Persona ConvertirAEntity(PersonaUT persona, ref MensajeError mensajeError)
        {
            try
            {
                var personaEntity = new TInfoteca_Persona()
                {
                    TN_Id = persona.LintID > 0 ? persona.LintID : 0,
                    TC_Nombre = persona.LstrNombre,
                    TC_Apellido = persona.LstrApelido,
                    TC_Alias = persona.LstrAlias,
                    TC_Identificacion = persona.LstrCedula,
                    TC_TipoIdentificacion = persona.LstrTipoIdentificacion,
                    TF_Fecha_Creacion = DateTime.Now,
                    TB_Activo = true
                };
                return personaEntity;

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
