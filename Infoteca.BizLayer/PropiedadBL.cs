using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class PropiedadBL
    {
        public static PropiedadUT InsertarPropiedad(PropiedadUT propiedad, ref MensajeError mensajeError)
        {
            return PropiedadDA.InsertarPropiedad(propiedad, ref mensajeError);
        }

        public static PropiedadUT EditarPropiedad(PropiedadUT propiedad, ref MensajeError mensajeError)
        {
            return PropiedadDA.EditarPropiedad(propiedad, ref mensajeError);
        }

        public static PropiedadUT BuscarPropiedad(int idPropiedad, ref MensajeError mensajeError)
        {
            return PropiedadDA.BuscarPropiedad(idPropiedad, ref mensajeError);
        }

        public static List<PropiedadUT> BuscarTodosPropiedad(ref MensajeError mensajeError)
        {
            return PropiedadDA.BuscarTodosPropiedad(ref mensajeError);
        }

        public static bool BorrarPropiedad(int idPropiedad, ref MensajeError mensajeError)
        {
            return PropiedadDA.BorrarPropiedad(idPropiedad, ref mensajeError);
        }

        public static int BuscarCantidadApariciones(int idPropiedad, ref MensajeError mensajeError)
        {
            return PropiedadDA.BuscarCantidadApariciones(idPropiedad, ref mensajeError);
        }
    }
}
