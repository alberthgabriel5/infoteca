using System;
using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class NoticiaBL
    {
        public static NoticiaUT InsertarNoticia(NoticiaUT noticia, ref MensajeError mensajeError)
        {
            return NoticiaDA.InsertarNoticia(noticia, ref mensajeError);
        }

        public static NoticiaUT EditarNoticia(NoticiaUT noticia, ref MensajeError mensajeError)
        {
            return NoticiaDA.EditarNoticia(noticia, ref mensajeError);
        }

        public static NoticiaUT BuscarNoticia(int idNoticia, ref MensajeError mensajeError, bool incluirImagenes = false)
        {
            return NoticiaDA.BuscarNoticia(idNoticia, ref mensajeError, incluirImagenes);
        }

        public static List<NoticiaUT> BuscarNoticiasActivas(ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiasActivas(ref mensajeError);
        }

        public static List<NoticiaUT> BuscarTodasLasNoticias(ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarTodasLasNoticias(ref mensajeError);
        }

        public static List<NoticiaUT> BuscarNoticiaPorFuente(int idFuente, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorFuente(idFuente,ref mensajeError);
        }

        public static List<NoticiaUT> BuscarNoticiaPorPersona(int idPersona, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorPersona(idPersona, ref mensajeError);
        }

        public static List<NoticiaUT> BuscarNoticiaPorVehiculo(int idVehiculo, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorVehiculo(idVehiculo, ref mensajeError);
        }
        public static List<NoticiaUT> BuscarNoticiaPorPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorPersonaJuridica(idPersonaJuridica, ref mensajeError);
        }
        public static List<NoticiaUT> BuscarNoticiaPorPropiedad(int idPropiedad, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorPropiedad(idPropiedad, ref mensajeError);
        }

        public static List<NoticiaUT> BuscarNoticiaPorTipoDelito(int idDelito, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarNoticiaPorTipoDelito(idDelito, ref mensajeError);
        }

        public static bool BorrarNoticia(int idNoticia, ref MensajeError mensajeError)
        {
            return NoticiaDA.BorrarNoticia(idNoticia, ref mensajeError);
        }

        public static List<NoticiaUT> BuscarPorPalabraClave(string tags, string usuario, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarPorPalabraClave(tags, usuario, ref mensajeError);
        }

        public static List<NoticiaUT> BuscarPorFechaNoticia(DateTime inicio, DateTime fin, string usuario, ref MensajeError mensajeError)
        {
            return NoticiaDA.BuscarPorFechaNoticia(inicio, fin, usuario, ref mensajeError);
        }
    }
}
