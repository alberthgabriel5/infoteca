using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class BitacoraBL
    {
        public static BitacoraUT InsertarBitacora(BitacoraUT bitacora, ref MensajeError mensajeError)
        {
            return BitacoraDA.InsertarBitacora(bitacora, ref mensajeError);
        }

        public static BitacoraUT EditarBitacora(BitacoraUT bitacora, ref MensajeError mensajeError)
        {
            return BitacoraDA.EditarBitacora(bitacora, ref mensajeError);
        }

        public static BitacoraUT BuscarBitacora(int idBitacora, ref MensajeError mensajeError)
        {
            return BitacoraDA.BuscarBitacora(idBitacora, ref mensajeError);
        }

        public static List<BitacoraUT> BuscarTodosBitacora(ref MensajeError mensajeError)
        {
            return BitacoraDA.BuscarTodosBitacora(ref mensajeError);
        }

        public static bool BorrarBitacora(int idBitacora, ref MensajeError mensajeError)
        {
            return BitacoraDA.BorrarBitacora(idBitacora, ref mensajeError);
        }
    }
}
