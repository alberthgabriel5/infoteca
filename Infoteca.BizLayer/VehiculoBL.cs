using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class VehiculoBL
    {
        public static VehiculoUT InsertarVehiculo(VehiculoUT vehiculo, ref MensajeError mensajeError)
        {
            return VehiculoDA.InsertarVehiculo(vehiculo, ref mensajeError);
        }

        public static VehiculoUT EditarVehiculo(VehiculoUT vehiculo, ref MensajeError mensajeError)
        {
            return VehiculoDA.EditarVehiculo(vehiculo, ref mensajeError);
        }

        public static VehiculoUT BuscarVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            return VehiculoDA.BuscarVehiculo(idVehiculo, ref mensajeError);
        }

        public static List<VehiculoUT> BuscarTodosVehiculo(ref MensajeError mensajeError)
        {
            return VehiculoDA.BuscarTodosVehiculo(ref mensajeError);
        }

        public static int BuscarCantidadApariciones(int idVehiculo, ref MensajeError mensajeError)
        {
            return VehiculoDA.BuscarCantidadApariciones(idVehiculo, ref mensajeError);
        }

        public static bool BorrarVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            return VehiculoDA.BorrarVehiculo(idVehiculo, ref mensajeError);
        }
    }
}
