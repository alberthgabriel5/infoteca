using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infoteca.DataAccess.TRAN
{
    public static class ImagenDA
    {
        public static ImagenUT InsertarImagen(ImagenUT imagen, ref MensajeError mensajeError)
        {
            var imagenUT = new ImagenUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var imagenEntity = ConvertirAEntity(imagen, ref mensajeError);

                    var entityResult = entities.TInfoteca_Imagen.Add(imagenEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        imagenUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }                                     
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Imagen";
                mensajeError.Mensaje = ex.Message;                
            }

            return imagenUT;
        }

        public static ImagenUT EditarImagen(ImagenUT imagen, ref MensajeError mensajeError)
        {
            var imagenUT = new ImagenUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var imagenEntity = ConvertirAEntity(imagen, ref mensajeError);

                    var entity = entities.TInfoteca_Imagen.Find(imagen.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-ImagenDA";
                        mensajeError.Mensaje = $"ImagenUT no existe: {imagen.LintID}";

                        return imagenUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(imagenEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        imagenUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }
                   
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-ImagenDA";
                mensajeError.Mensaje = ex.Message;                
            }

            return imagenUT;
        }

        public static ImagenUT BuscarImagen(int IdImagen, ref MensajeError mensajeError)
        {
            var imagenUT = new ImagenUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Imagen.Find(IdImagen);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-ImagenDA";
                        mensajeError.Mensaje = $"ImagenUT no existe: {IdImagen}";

                        return imagenUT;                        
                    }

                    imagenUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-ImagenDA";
                mensajeError.Mensaje = ex.Message;
            }

            return imagenUT;
        }

        public static List<ImagenUT> BuscarTodosImagen(ref MensajeError mensajeError)
        {
            List<ImagenUT> imagenUTLista = new List<ImagenUT>();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Imagen.Select(x => x).ToList();                    

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            imagenUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-ImagenDA";
                mensajeError.Mensaje = ex.Message;
            }

            return imagenUTLista;
        }

        public static bool BorrarImagen(int IdImagen, ref MensajeError mensajeError)
        {
            var imagenUT = new ImagenUT();

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Imagen.Find(IdImagen);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-ImagenDA";
                        mensajeError.Mensaje = $"ImagenUT no existe: {IdImagen}";

                        return false;
                    }

                    entities.TInfoteca_Imagen.Remove(entity);
                    var result = entities.SaveChanges();

                    return result > 0;               
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-ImagenDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }            
        }

        public static ImagenUT ConvertirAUtilitario(TInfoteca_Imagen imagen, ref MensajeError mensajeError)
        {
            try
            {
                var imagenUT = new ImagenUT()
                {
                    LintID = imagen.TN_Id,
                    LstrNombre = imagen.TC_Nombre,
                    FdtiFechaCreaccion = imagen.TF_Fecha_Creacion != null ? imagen.TF_Fecha_Creacion.Value : DateTime.MinValue,
                    LByteImagen = imagen.TI_Imagen                    
                };

                return imagenUT;
            }
            catch(Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }            
        }

        public static TInfoteca_Imagen ConvertirAEntity(ImagenUT imagen, ref MensajeError mensajeError)
        {
            try
            {
                var imagenEntity = new TInfoteca_Imagen()
                {
                    TN_Id = imagen.LintID > 0 ? imagen.LintID : 0,
                    TC_Nombre = imagen.LstrNombre,
                    TF_Fecha_Creacion = DateTime.Now,
                    TI_Imagen = imagen.LByteImagen,
                    TB_Activo=true
                };
                return imagenEntity;

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
