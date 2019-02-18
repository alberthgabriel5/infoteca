using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class TipoFuenteBL
    {
        public static TipoFuenteUT InsertarTipoFuente(TipoFuenteUT tipoFuente, ref MensajeError mensajeError)
        {
            return TipoFuenteDA.InsertarTipoFuente(tipoFuente, ref mensajeError);
        }

        public static TipoFuenteUT EditarTipoFuente(TipoFuenteUT tipoFuente, ref MensajeError mensajeError)
        {
            return TipoFuenteDA.EditarTipoFuente(tipoFuente, ref mensajeError);
        }

        public static TipoFuenteUT BuscarTipoFuente(int idTipoFuente, ref MensajeError mensajeError)
        {
            return TipoFuenteDA.BuscarTipoFuente(idTipoFuente, ref mensajeError);
        }

        public static List<TipoFuenteUT> BuscarTodosTipoFuente(ref MensajeError mensajeError)
        {
            return TipoFuenteDA.BuscarTodosTipoFuente(ref mensajeError);
        }

        public static bool BorrarTipoFuente(int idTipoFuente, ref MensajeError mensajeError)
        {
            return TipoFuenteDA.BorrarTipoFuente(idTipoFuente, ref mensajeError);
        }
    }
}
