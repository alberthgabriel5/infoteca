using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoteca.DataAccess.TRAN
{
    public static class PersonaJuridicaDA
    {
        public static PersonaJuridicaUT InsertarPersonaJuridica(PersonaJuridicaUT personaJuridica, ref MensajeError mensajeError)
        {
            var personaJuridicaUT = new PersonaJuridicaUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var personaJuridicaEntity = ConvertirAEntity(personaJuridica, ref mensajeError);

                    var entityResult = entities.TInfoteca_Persona_Juridica.Add(personaJuridicaEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        personaJuridicaUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-PersonaJuridica";
                mensajeError.Mensaje = ex.Message;
            }

            return personaJuridicaUT;
        }

        public static PersonaJuridicaUT EditarPersonaJuridica(PersonaJuridicaUT personaJuridica, ref MensajeError mensajeError)
        {
            var personaJuridicaUT = new PersonaJuridicaUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var personaJuridicaEntity = ConvertirAEntity(personaJuridica, ref mensajeError);

                    var entity = entities.TInfoteca_Persona_Juridica.Find(personaJuridica.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-PersonaJuridicaDA";
                        mensajeError.Mensaje = $"PersonaJuridicaUT no existe: {personaJuridica.LintID}";

                        return personaJuridicaUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(personaJuridicaEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        personaJuridicaUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-PersonaJuridicaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaJuridicaUT;
        }

        public static PersonaJuridicaUT BuscarPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            var personaJuridicaUT = new PersonaJuridicaUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona_Juridica.Find(idPersonaJuridica);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-PersonaJuridicaDA";
                        mensajeError.Mensaje = $"PersonaJuridicaUT no existe: {idPersonaJuridica}";

                        return personaJuridicaUT;
                    }

                    personaJuridicaUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-PersonaJuridicaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaJuridicaUT;
        }

        public static List<PersonaJuridicaUT> BuscarTodosPersonaJuridica(ref MensajeError mensajeError)
        {
            List<PersonaJuridicaUT> personaJuridicaUTLista = new List<PersonaJuridicaUT>();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona_Juridica.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            personaJuridicaUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-PersonaJuridicaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return personaJuridicaUTLista;
        }

        public static int BuscarCantidadApariciones(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            var result = 0;

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Juridica.Where(p => p.TN_Juridica == idPersonaJuridica);
                    result = entity.Count();
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarCantidadApariciones-PersonaJuridicaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return result;
        }
        
        public static bool BorrarPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            var personaJuridicaUT = new PersonaJuridicaUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Persona_Juridica.Find(idPersonaJuridica);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-PersonaJuridicaDA";
                        mensajeError.Mensaje = $"PersonaJuridicaUT no existe: {idPersonaJuridica}";

                        return false;
                    }

                    //entities.TInfoteca_Persona_Juridica.Remove(entity);
                    entity.TB_Activo = false; // cambiar estado a inactivo
                    entities.Entry(entity).CurrentValues.SetValues(entity);

                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-PersonaJuridicaDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        public static PersonaJuridicaUT ConvertirAUtilitario(TInfoteca_Persona_Juridica personaJuridica, ref MensajeError mensajeError)
        {
            try
            {
                var personaJuridicaUT = new PersonaJuridicaUT()
                {
                    LintID = personaJuridica.TN_Id,
                    LstrNombreJuridico = personaJuridica.TC_Nombre,
                    LstrNombrePublico = personaJuridica.TC_Nombre_Fantasia,
                    LstrCedulaJuridica = personaJuridica.TC_Cedula,

                };

                return personaJuridicaUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        public static TInfoteca_Persona_Juridica ConvertirAEntity(PersonaJuridicaUT personaJuridica, ref MensajeError mensajeError)
        {
            try
            {
                var personaJuridicaEntity = new TInfoteca_Persona_Juridica()
                {
                    TN_Id = personaJuridica.LintID,
                    TC_Nombre = personaJuridica.LstrNombreJuridico,
                    TC_Nombre_Fantasia = personaJuridica.LstrNombrePublico,
                    TC_Cedula = personaJuridica.LstrCedulaJuridica,
                    TF_Fecha_Creacion = DateTime.Now,
                    TB_Activo = true
                };
                return personaJuridicaEntity;

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
