using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoteca.DataAccess.TRAN
{
    public static class VehiculoDA
    {
        public static VehiculoUT InsertarVehiculo(VehiculoUT vehiculo, ref MensajeError mensajeError)
        {
            var vehiculoUT = new VehiculoUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var vehiculoEntity = ConvertirAEntity(vehiculo, ref mensajeError);

                    var entityResult = entities.TInfoteca_Vehiculo.Add(vehiculoEntity);
                    if (entities.SaveChanges() > 0)
                    {
                        vehiculoUT = ConvertirAUtilitario(entityResult, ref mensajeError);
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Insertar-Vehiculo";
                mensajeError.Mensaje = ex.Message;
            }

            return vehiculoUT;
        }

        public static VehiculoUT EditarVehiculo(VehiculoUT vehiculo, ref MensajeError mensajeError)
        {
            var vehiculoUT = new VehiculoUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var vehiculoEntity = ConvertirAEntity(vehiculo, ref mensajeError);

                    var entity = entities.TInfoteca_Vehiculo.Find(vehiculo.LintID);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Editar-VehiculoDA";
                        mensajeError.Mensaje = $"VehiculoUT no existe: {vehiculo.LintID}";

                        return vehiculoUT;
                    }

                    entities.Entry(entity).CurrentValues.SetValues(vehiculoEntity);

                    if (entities.SaveChanges() > 0)
                    {
                        vehiculoUT = ConvertirAUtilitario(entity, ref mensajeError);
                    }

                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Editar-VehiculoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return vehiculoUT;
        }

        public static VehiculoUT BuscarVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            var vehiculoUT = new VehiculoUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Vehiculo.Find(idVehiculo);

                    if (entity == null)
                    {
                        mensajeError.Code = "CODE-Buscar-VehiculoDA";
                        mensajeError.Mensaje = $"VehiculoUT no existe: {idVehiculo}";

                        return vehiculoUT;
                    }

                    vehiculoUT = ConvertirAUtilitario(entity, ref mensajeError);
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Buscar-VehiculoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return vehiculoUT;
        }

        public static List<VehiculoUT> BuscarTodosVehiculo(ref MensajeError mensajeError)
        {
            List<VehiculoUT> vehiculoUTLista = new List<VehiculoUT>();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Vehiculo.Select(x => x).ToList();

                    foreach (var item in entity)
                    {
                        if (item.TB_Activo)
                        {
                            vehiculoUTLista.Add(ConvertirAUtilitario(item, ref mensajeError));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarTodos-VehiculoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return vehiculoUTLista;
        }

        public static int BuscarCantidadApariciones(int idVehiculo, ref MensajeError mensajeError)
        {
            var result = 0;

            try
            {
                using (var entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Noticia_Vehiculo.Where(p => p.TN_Vehiculo == idVehiculo);
                    result = entity.Count();
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-BuscarCantidadApariciones-VehiculoDA";
                mensajeError.Mensaje = ex.Message;
            }

            return result;
        }

        public static bool BorrarVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            var vehiculoUT = new VehiculoUT();

            try
            {
                using (InfotecaEntities entities = new InfotecaEntities())
                {
                    var entity = entities.TInfoteca_Vehiculo.Find(idVehiculo);

                    if (entity == null)
                    {
                        mensajeError.Code = "SQL-BuscarTodos-VehiculoDA";
                        mensajeError.Mensaje = $"VehiculoUT no existe: {idVehiculo}";

                        return false;
                    }

                    //entities.TInfoteca_Vehiculo.Remove(entity);
                    entity.TB_Activo = false; // cambiar estado a inactivo
                    entities.Entry(entity).CurrentValues.SetValues(entity);
                    var result = entities.SaveChanges();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                mensajeError.Code = "SQL-Borrar-VehiculoDA";
                mensajeError.Mensaje = ex.Message;
                return false;
            }
        }

        public static VehiculoUT ConvertirAUtilitario(TInfoteca_Vehiculo vehiculo, ref MensajeError mensajeError)
        {
            try
            {
                var vehiculoUT = new VehiculoUT()
                {
                    LintID = vehiculo.TN_Id,
                    LstrPlaca = vehiculo.TC_Placa,
                    LstrEstilo = vehiculo.TN_Id_Estilo,
                    LstrMarca = vehiculo.TC_Marca,
                    LstrModelo = vehiculo.TC_Modelo,
                    LstrColor = vehiculo.TC_Color
                };

                return vehiculoUT;
            }
            catch (Exception ex)
            {
                mensajeError.Code = "";
                mensajeError.Mensaje = ex.Message;

                return null;
            }
        }

        public static TInfoteca_Vehiculo ConvertirAEntity(VehiculoUT vehiculo, ref MensajeError mensajeError)
        {
            try
            {
                var vehiculoEntity = new TInfoteca_Vehiculo()
                {
                    TN_Id = vehiculo.LintID,
                    TC_Placa = vehiculo.LstrPlaca,
                    TN_Id_Estilo = vehiculo.LstrEstilo,
                    TC_Marca = vehiculo.LstrMarca,
                    TC_Modelo = vehiculo.LstrModelo,
                    TC_Color = vehiculo.LstrColor,
                    TB_Activo = true
                };
                return vehiculoEntity;

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
