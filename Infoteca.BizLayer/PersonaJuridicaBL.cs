using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class PersonaJuridicaBL
    {
        public static PersonaJuridicaUT InsertarPersonaJuridica(PersonaJuridicaUT personaJuridica, ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.InsertarPersonaJuridica(personaJuridica, ref mensajeError);
        }

        public static PersonaJuridicaUT EditarPersonaJuridica(PersonaJuridicaUT personaJuridica, ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.EditarPersonaJuridica(personaJuridica, ref mensajeError);
        }

        public static PersonaJuridicaUT BuscarPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.BuscarPersonaJuridica(idPersonaJuridica, ref mensajeError);
        }

        public static List<PersonaJuridicaUT> BuscarTodosPersonaJuridica(ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.BuscarTodosPersonaJuridica(ref mensajeError);
        }

        public static int BuscarCantidadApariciones(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.BuscarCantidadApariciones(idPersonaJuridica, ref mensajeError);
        }

        public static bool BorrarPersonaJuridica(int idPersonaJuridica, ref MensajeError mensajeError)
        {
            return PersonaJuridicaDA.BorrarPersonaJuridica(idPersonaJuridica, ref mensajeError);
        }
    }
}
