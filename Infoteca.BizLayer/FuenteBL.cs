using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class FuenteBL
    {
        public static FuenteUT InsertarFuente(FuenteUT fuente, ref MensajeError mensajeError)
        {
            return FuenteDA.InsertarFuente(fuente, ref mensajeError);
        }

        public static FuenteUT EditarFuente(FuenteUT fuente, ref MensajeError mensajeError)
        {
            return FuenteDA.EditarFuente(fuente, ref mensajeError);
        }

        public static FuenteUT BuscarFuente(int idFuente, ref MensajeError mensajeError)
        {
            return FuenteDA.BuscarFuente(idFuente, ref mensajeError);
        }

        public static List<FuenteUT> BuscarTodosFuente(ref MensajeError mensajeError)
        {
            return FuenteDA.BuscarTodosFuente(ref mensajeError);
        }

        public static bool BorrarFuente(int idFuente, ref MensajeError mensajeError)
        {
            return FuenteDA.BorrarFuente(idFuente, ref mensajeError);
        }
    }
}
