using System.Collections.Generic;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.BizLayer
{
    public static class PersonaBL
    {
        public static PersonaUT InsertarPersona(PersonaUT persona, ref MensajeError mensajeError)
        {
            return PersonaDA.InsertarPersona(persona, ref mensajeError);
        }

        public static PersonaUT EditarPersona(PersonaUT persona, ref MensajeError mensajeError)
        {
            return PersonaDA.EditarPersona(persona, ref mensajeError);
        }

        public static PersonaUT BuscarPersona(int idPersona, ref MensajeError mensajeError)
        {
            return PersonaDA.BuscarPersona(idPersona, ref mensajeError);
        }

        public static int BuscarCantidadApariciones(int idPersona, ref MensajeError mensajeError)
        {
            return PersonaDA.BuscarCantidadApariciones(idPersona, ref mensajeError);
        }

        public static List<PersonaUT> BuscarTodosPersona(ref MensajeError mensajeError)
        {
            return PersonaDA.BuscarTodosPersona(ref mensajeError);
        }

        public static bool BorrarPersona(int idPersona, ref MensajeError mensajeError)
        {
            return PersonaDA.BorrarPersona(idPersona, ref mensajeError);
        }
    }
}
