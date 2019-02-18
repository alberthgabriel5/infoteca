using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class NoticiaDA
    {
        public static NoticiaUT InsertarNoticia(NoticiaUT noticia, ref MensajeError mensajeError)
        {
            var noticiaUT = new NoticiaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var noticiaEntity = ConvertirAEntity(noticia, ref mensajeError);

                    var entityResult = entities.TInfoteca_Noticia.Add(noticiaEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        noticiaUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Noticia";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUT;
        }

        public static NoticiaUT EditarNoticia(NoticiaUT noticia, ref MensajeError mensajeError)
        {
            var noticiaUT = new NoticiaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var noticiaEntity = ConvertirAEntity(noticia, ref mensajeError);

                    if (entities.TInfoteca_Noticia != null)
                    {
                        var entity = entities.TInfoteca_Noticia.Find(noticia.LintId);

                        if (entity == null)
                        {
                            mensajeError.Code = "CODE-Editar-NoticiaDA";
                            mensajeError.Mensaje = $"NoticiaUT no existe: {noticia.LintId}";

                            return noticiaUT;
                        }

                        entity.TInfoteca_Noticia_Imagen.ToList().ForEach(s => entities.Entry(s).State = EntityState.Deleted);
                        entity.TInfoteca_Noticia_Persona.ToList().ForEach(s => entities.Entry(s).State = EntityState.Deleted);
                        entity.TInfoteca_Noticia_Vehiculo.ToList().ForEach(s => entities.Entry(s).State = EntityState.Deleted);
                        entity.TInfoteca_Noticia_Juridica.ToList().ForEach(s => entities.Entry(s).State = EntityState.Deleted);
                        entity.TInfoteca_Noticia_Propiedad.ToList().ForEach(s => entities.Entry(s).State = EntityState.Deleted);

                        entities.SaveChanges();

                        if (noticiaEntity.TInfoteca_Noticia_Imagen != null &&
                            noticiaEntity.TInfoteca_Noticia_Imagen.Count > 0)
                        {
                            foreach (var infotecaNoticiaImagen in noticiaEntity.TInfoteca_Noticia_Imagen)
                            {
                                infotecaNoticiaImagen.TN_Id_Noticia = noticiaEntity.TN_Id;
                                entity.TInfoteca_Noticia_Imagen.Add(infotecaNoticiaImagen);
                            }
                        }

                        if (noticiaEntity.TInfoteca_Noticia_Persona != null &&
                            noticiaEntity.TInfoteca_Noticia_Persona.Count > 0)
                        {
                            foreach (var infotecaNoticiaPersona in noticiaEntity.TInfoteca_Noticia_Persona)
                            {
                                infotecaNoticiaPersona.TN_Noticia = noticiaEntity.TN_Id;
                                entity.TInfoteca_Noticia_Persona.Add(infotecaNoticiaPersona);
                            }
                        }

                        if (noticiaEntity.TInfoteca_Noticia_Vehiculo != null &&
                            noticiaEntity.TInfoteca_Noticia_Vehiculo.Count > 0)
                        {
                            foreach (var infotecaNoticiaVehiculo in noticiaEntity.TInfoteca_Noticia_Vehiculo)
                            {
                                infotecaNoticiaVehiculo.TN_Noticia = noticiaEntity.TN_Id;
                                entity.TInfoteca_Noticia_Vehiculo.Add(infotecaNoticiaVehiculo);
                            }
                        }

                        if (noticiaEntity.TInfoteca_Noticia_Juridica != null &&
                            noticiaEntity.TInfoteca_Noticia_Juridica.Count > 0)
                        {
                            foreach (var infotecaNoticiaJuridica in noticiaEntity.TInfoteca_Noticia_Juridica)
                            {
                                infotecaNoticiaJuridica.TN_Noticia = noticiaEntity.TN_Id;
                                entity.TInfoteca_Noticia_Juridica.Add(infotecaNoticiaJuridica);
                            }
                        }

                        if (noticiaEntity.TInfoteca_Noticia_Propiedad != null &&
                            noticiaEntity.TInfoteca_Noticia_Propiedad.Count > 0)
                        {
                            foreach (var infotecaNoticiaPropiedad in noticiaEntity.TInfoteca_Noticia_Propiedad)
                            {
                                infotecaNoticiaPropiedad.TN_Noticia = noticiaEntity.TN_Id;
                                entity.TInfoteca_Noticia_Propiedad.Add(infotecaNoticiaPropiedad);
                            }
                        }

                        entities.SaveChanges();

                        entities.Entry(entity).CurrentValues.SetValues(noticiaEntity);

                        if (entities.SaveChanges() > 0)
                        {
                            entity = entities.TInfoteca_Noticia.Find(noticia.LintId);

                            noticiaUT = ConvertirAUtilitario(entity, ref mensajeError);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUT;
        }
        
        public static NoticiaUT AgregarObjetoNoticia(int idNoticia, int idObjeto, int tipoObjeto, ref MensajeError mensajeError)
        {
            var noticiaUT = new NoticiaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Find(idNoticia);
                    switch (tipoObjeto) {
                        case Tipo.PERSONA:
                            entity.TInfoteca_Noticia_Persona.Add(new TInfoteca_Noticia_Persona()
                            {
                                TN_Persona = idObjeto,
                                TB_Activo = true
                            });
                            break;
                        case Tipo.PERSONA_JURIDICA:
                            entity.TInfoteca_Noticia_Juridica.Add(new TInfoteca_Noticia_Juridica()
                            {
                                TN_Juridica = idObjeto,
                                TB_Activo = true
                            });
                            break;
                        case Tipo.PROPIEDAD:
                            entity.TInfoteca_Noticia_Propiedad.Add(new TInfoteca_Noticia_Propiedad()
                            {
                                TN_Propiedad = idObjeto,
                                TB_Activo = true
                            });
                            break;
                        case Tipo.VEHICULO:
                            entity.TInfoteca_Noticia_Vehiculo.Add(new TInfoteca_Noticia_Vehiculo()
                            {
                                TN_Vehiculo = idObjeto,
                                TB_Activo = true
                            });
                            break;
                        case Tipo.IMAGEN:
                            entity.TInfoteca_Noticia_Imagen.Add(new TInfoteca_Noticia_Imagen()
                            {
                                TN_Id_Imagen = idObjeto,
                                TB_Activo = true
                            });
                            break;
                    }
                    if (entities.SaveChanges() > 0)
                    {
                        noticiaUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-AgregarObjeto-Noticia";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUT;
        }

        public static NoticiaUT BorrarObjetoNoticia(int idNoticia, int idObjeto, int tipoObjeto, ref MensajeError mensajeError)
        {
            var noticiaUT = new NoticiaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Find(idNoticia);
                    switch (tipoObjeto)
                    {
                        case Tipo.PERSONA:
                            foreach (var objeto in entity.TInfoteca_Noticia_Persona.ToList())
                            {
                                if (objeto.TN_Id == idObjeto)
                                {
                                    objeto.TB_Activo = false;
                                    entities.Entry(objeto).CurrentValues.SetValues(objeto);
                                }
                            }
                            break;
                        case Tipo.PERSONA_JURIDICA:
                            foreach (var objeto in entity.TInfoteca_Noticia_Juridica.ToList())
                            {
                                if (objeto.TN_Id == idObjeto)
                                {
                                    objeto.TB_Activo = false;
                                    entities.Entry(objeto).CurrentValues.SetValues(objeto);
                                }
                            }
                            break;
                        case Tipo.PROPIEDAD:
                            foreach (var objeto in entity.TInfoteca_Noticia_Propiedad.ToList())
                            {
                                if (objeto.TN_Id == idObjeto)
                                {
                                    objeto.TB_Activo = false;
                                    entities.Entry(objeto).CurrentValues.SetValues(objeto);
                                }
                            }
                            break;
                        case Tipo.VEHICULO:
                            foreach (var objeto in entity.TInfoteca_Noticia_Vehiculo.ToList())
                            {
                                if (objeto.TN_Id == idObjeto)
                                {
                                    objeto.TB_Activo = false;
                                    entities.Entry(objeto).CurrentValues.SetValues(objeto);
                                }
                            }
                            break;
                        case Tipo.IMAGEN:
                            foreach (var objeto in entity.TInfoteca_Noticia_Imagen.ToList())
                            {
                                if (objeto.TN_Id == idObjeto)
                                {
                                    objeto.TB_Activo = false;
                                    entities.Entry(objeto).CurrentValues.SetValues(objeto);
                                }
                            }
                            break;

                    }
                    if (entities.SaveChanges() > 0)
                    {
                        noticiaUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BorrarObjeto-Noticia";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUT;
        }

        public static NoticiaUT BuscarNoticia(int idNoticia, ref MensajeError mensajeError, bool incluirImagenes = false)
        {
            var noticiaUT = new NoticiaUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Find(idNoticia);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-NoticiaDA";
                        mensajeError.Mensaje = $"NoticiaUT no existe: {idNoticia}";

                        return noticiaUT;
                    }

                    if (!entity.TB_Activo)
                    {
                        mensajeError.Code = "CODE-Buscar-NoticiaDA";
                        mensajeError.Mensaje = $"Noticia Inactiva: {idNoticia}";

                        return noticiaUT;
                    }

                    noticiaUT = ConvertirAUtilitario(entity, ref mensajeError, incluirImagenes);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUT;
        }
        
        public static List<NoticiaUT> BuscarNoticiaPorFuente(int idFuente, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Id_Fuente.Equals(idFuente))
                        {
                            noticiaUtLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorFuente-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }

        public static List<NoticiaUT> BuscarNoticiaPorPersona(int idPersona, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Persona.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Persona.Equals(idPersona))
                        {
                            var noticia = BuscarNoticia(item.TN_Noticia, ref mensajeError);

                            noticiaUtLista.Add(noticia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorPersona-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }

        public static List<NoticiaUT> BuscarNoticiaPorVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Vehiculo.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Vehiculo.Equals(idVehiculo))
                        {
                            var noticia = BuscarNoticia(item.TN_Noticia, ref mensajeError);

                            noticiaUtLista.Add(noticia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorVehiculo-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }

        public static List<NoticiaUT> BuscarNoticiaPorPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Juridica.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Juridica.Equals(idPersonaJuridica))
                        {
                            var noticia = BuscarNoticia(item.TN_Noticia, ref mensajeError);

                            noticiaUtLista.Add(noticia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorPersonaJuridica-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }
        
        public static List<NoticiaUT> BuscarNoticiaPorPropiedad(int idPropiedad, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Propiedad.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Propiedad.Equals(idPropiedad))
                        {
                            var noticia = BuscarNoticia(item.TN_Noticia, ref mensajeError);

                            noticiaUtLista.Add(noticia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorPropiedad-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }

        public static List<NoticiaUT> BuscarNoticiaPorTipoDelito(int idTipoDelito, ref MensajeError mensajeError)
        {
            var noticiaUtLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TN_Id_Tipo_Delito.Equals(idTipoDelito))
                        {
                            noticiaUtLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarNoticiaPorTipoDelito-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUtLista;
        }

        public static List<NoticiaUT> BuscarNoticiasActivas(ref MensajeError mensajeError)
        {
            var noticiaUTLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            noticiaUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUTLista;
        }

        public static List<NoticiaUT> BuscarTodasLasNoticias(ref MensajeError mensajeError)
        {
            var noticiaUTLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        noticiaUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUTLista;
        }

        public static List<NoticiaUT> BuscarPorFechaNoticia(DateTime inicio, DateTime fin, string usuario, ref MensajeError mensajeError)
        {
            var noticiaUTLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.PInfoteca_BuscarNoticiaPorFechas(inicio, fin);

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            var noticia = BuscarNoticia(item.TN_Id, ref mensajeError);

                            noticiaUTLista.Add(noticia);
                        }
                    }

                    var resultados = new List<string>();

                    foreach (var noticiaUt in noticiaUTLista)
                    {
                        resultados.Add(noticiaUt.LintId.ToString());
                    }

                    var bitacora = new BitacoraUT()
                    {
                        TB_Activo = true,
                        TC_Host = $"{inicio.ToString("d")}-{fin.ToString("d")}",
                        TC_Operacion = string.Join(",", resultados),
                        TC_Tabla = "RangoFechas",
                        TC_Usuario = usuario,
                        TD_Modificado = DateTime.Now,

                    };

                    BitacoraDA.InsertarBitacora(bitacora, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarPorFecha-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUTLista;
        }

        public static List<NoticiaUT> BuscarPorPalabraClave(string tags, string usuario, ref MensajeError mensajeError)
        {
            char[] separadores = { ',', ' ', '.', '/', '\\', '-', ';'};

            var listatags = tags.Split(separadores).ToList();

            var noticiaUTLista = new List<NoticiaUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    foreach (var palabraClave in listatags)
                    {
                        var entity = entities.PInfoteca_BuscarNoticiaPorPalabrasClave(palabraClave);

                        foreach (var item in entity)
                        {
                            if (noticiaUTLista.All(x => x.LintId != item.TN_Id) && item.TB_Activo)
                            {
                                var noticia = BuscarNoticia(item.TN_Id, ref mensajeError);

                                noticiaUTLista.Add(noticia);
                            }
                        }
                    }

                    var resultados = new List<string>();

                    foreach (var noticiaUt in noticiaUTLista)
                    {
                        resultados.Add(noticiaUt.LintId.ToString());
                    }

                    var bitacora = new BitacoraUT()
                    {
                        TB_Activo = true,
                        TC_Host = tags,
                        TC_Operacion = string.Join(",", resultados),
                        TC_Tabla = "PalabraClave",
                        TC_Usuario = usuario,
                        TD_Modificado = DateTime.Now,
                        
                    };

                    BitacoraDA.InsertarBitacora(bitacora, ref mensajeError);

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarPorPalabraClave-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
            }

            return noticiaUTLista;
        }
        
        public static bool BorrarNoticia(int idNoticia, ref MensajeError mensajeError)
        {
            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var noticia = entities.TInfoteca_Noticia.Find(idNoticia);

                    if (noticia == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-NoticiaDA";
                        mensajeError.Mensaje = $"NoticiaUT no existe: {idNoticia}";

                        return false;
                    }
                  
                    noticia.TB_Activo = false; // cambiar estado a inactivo
                    entities.Entry(noticia).CurrentValues.SetValues(noticia);

                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-NoticiaDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        private static TInfoteca_Noticia ConvertirAEntity(NoticiaUT noticia, ref MensajeError mensajeError)
        {
            try
            {
                var noticiaEntity = new TInfoteca_Noticia()
                {
                    TN_Id = noticia.LintId,
                    TC_Descripcion = noticia.LstrDescripcion,
                    TC_Sub_Delito = noticia.LstrSubDelito,
                    TC_Palabras_Clave = noticia.LstrPalabraClave,
                    TF_Fecha_Evento = noticia.LdtiFecha,
                    TN_Id_Fuente = noticia.LintIdFuente,
                    TN_Id_Tipo_Delito = noticia.LintIdTipoDelito,
                    TF_Fecha_Creacion = DateTime.Now,
                    TB_Activo = true
                };

                if (noticia.LobjImagenes !=null && noticia.LobjImagenes.Count > 0)
                {
                    foreach (var imagen in noticia.LobjImagenes)
                    {
                        noticiaEntity.TInfoteca_Noticia_Imagen.Add(new TInfoteca_Noticia_Imagen()
                        {
                            TInfoteca_Imagen = ImagenDA.ConvertirAEntity(imagen, ref mensajeError),
                            TB_Activo = true
                        });
                    }
                }

                if (noticia.LobjPersonas != null &&  noticia.LobjPersonas.Count > 0)
                {
                    foreach (var persona in noticia.LobjPersonas)
                    {
                        noticiaEntity.TInfoteca_Noticia_Persona.Add(new TInfoteca_Noticia_Persona()
                        {
                            TN_Persona = persona.LintID,
                            TB_Activo = true
                        });
                    }
                }

                if (noticia.LobjVehiculos !=null && noticia.LobjVehiculos.Count > 0)
                {
                    foreach (var vehiculo in noticia.LobjVehiculos)
                    {
                        noticiaEntity.TInfoteca_Noticia_Vehiculo.Add(new TInfoteca_Noticia_Vehiculo()
                        {
                            TN_Vehiculo = vehiculo.LintID,
                            TB_Activo = true
                        });
                    }
                }

                if (noticia.LobjPropiedades != null && noticia.LobjPropiedades.Count > 0)
                {
                    foreach (var propiedad in noticia.LobjPropiedades)
                    {
                        noticiaEntity.TInfoteca_Noticia_Propiedad.Add(new TInfoteca_Noticia_Propiedad()
                        {
                            TN_Propiedad = propiedad.LintID,
                            TB_Activo = true
                        });
                    }
                }

                if (noticia.LobjPersonaJuridicas != null && noticia.LobjPersonaJuridicas.Count > 0)
                {
                    foreach (var personaJuridica in noticia.LobjPersonaJuridicas)
                    {
                        noticiaEntity.TInfoteca_Noticia_Juridica.Add(new TInfoteca_Noticia_Juridica()
                        {
                            TN_Juridica = personaJuridica.LintID,
                            TB_Activo = true
                        });
                    }
                }

                return noticiaEntity;

            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        private static NoticiaUT ConvertirAUtilitario(TInfoteca_Noticia entity, ref MensajeError mensajeError, bool incluirImagenes = false)
        {

            try
            {
                var noticiaUT = new NoticiaUT()
                {
                    LintId= entity.TN_Id,
                    LdtiFecha = entity.TF_Fecha_Evento,
                    LstrDescripcion = entity.TC_Descripcion,
                    LstrSubDelito = entity.TC_Sub_Delito,
                    LintIdTipoDelito = entity.TN_Id_Tipo_Delito,
                    LintIdFuente = entity.TN_Id_Fuente,
                    LstrPalabraClave = entity.TC_Palabras_Clave
                };

                if (incluirImagenes)
                {
                    if (entity.TInfoteca_Noticia_Imagen != null && entity.TInfoteca_Noticia_Imagen.Count > 0)
                    {
                        noticiaUT.LobjImagenes = new List<ImagenUT>();

                        foreach (var imagen in entity.TInfoteca_Noticia_Imagen)
                        {
                            if (imagen.TB_Activo)
                                noticiaUT.LobjImagenes.Add(ImagenDA.BuscarImagen(imagen.TN_Id_Imagen, ref mensajeError));
                        }
                    }
                }

                if (entity.TInfoteca_Noticia_Persona != null && entity.TInfoteca_Noticia_Persona.Count > 0)
                {
                    noticiaUT.LobjPersonas = new List<PersonaUT>();

                    foreach (var persona in entity.TInfoteca_Noticia_Persona)
                    {
                        if (persona.TB_Activo)
                            noticiaUT.LobjPersonas.Add(PersonaDA.BuscarPersona(persona.TN_Persona, ref mensajeError));
                    }
                }

                if (entity.TInfoteca_Noticia_Vehiculo != null && entity.TInfoteca_Noticia_Vehiculo.Count > 0)
                {
                    noticiaUT.LobjVehiculos = new List<VehiculoUT>();

                    foreach (var vehiculo in entity.TInfoteca_Noticia_Vehiculo)
                    {
                        if (vehiculo.TB_Activo)
                            noticiaUT.LobjVehiculos.Add(VehiculoDA.BuscarVehiculo(vehiculo.TN_Vehiculo, ref mensajeError));
                    }
                }

                if (entity.TInfoteca_Noticia_Propiedad != null && entity.TInfoteca_Noticia_Propiedad.Count > 0)
                {
                    noticiaUT.LobjPropiedades = new List<PropiedadUT>();
                    foreach (var propiedad in entity.TInfoteca_Noticia_Propiedad)
                    {
                        if (propiedad.TB_Activo)
                            noticiaUT.LobjPropiedades.Add(PropiedadDA.BuscarPropiedad(propiedad.TN_Propiedad, ref mensajeError));
                    }
                }

                if (entity.TInfoteca_Noticia_Juridica !=null && entity.TInfoteca_Noticia_Juridica.Count > 0)
                {
                    noticiaUT.LobjPersonaJuridicas = new List<PersonaJuridicaUT>();

                    foreach (var juridica in entity.TInfoteca_Noticia_Juridica)
                    {
                        if (juridica.TB_Activo)
                            noticiaUT.LobjPersonaJuridicas.Add(PersonaJuridicaDA.BuscarPersonaJuridica(juridica.TN_Juridica, ref mensajeError));
                    }
                }

                return noticiaUT;
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
