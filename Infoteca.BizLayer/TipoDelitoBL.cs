using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class TipoDelitoBL
    {
        public static TipoDelitoUT InsertarTipoDelito(TipoDelitoUT tipoDelito, ref MensajeError mensajeError)
        {
            return TipoDelitoDA.InsertarTipoDelito(tipoDelito, ref mensajeError);
        }

        public static TipoDelitoUT EditarTipoDelito(TipoDelitoUT tipoDelito, ref MensajeError mensajeError)
        {
            return TipoDelitoDA.EditarTipoDelito(tipoDelito, ref mensajeError);
        }

        public static TipoDelitoUT BuscarTipoDelito(int idTipoDelito, ref MensajeError mensajeError)
        {
            return TipoDelitoDA.BuscarTipoDelito(idTipoDelito, ref mensajeError);
        }

        public static List<TipoDelitoUT> BuscarTodosTipoDelito(ref MensajeError mensajeError)
        {
            return TipoDelitoDA.BuscarTodosTipoDelito(ref mensajeError);
        }

        public static bool BorrarTipoDelito(int idTipoDelito, ref MensajeError mensajeError)
        {
            return TipoDelitoDA.BorrarTipoDelito(idTipoDelito, ref mensajeError);
        }
    }
}
