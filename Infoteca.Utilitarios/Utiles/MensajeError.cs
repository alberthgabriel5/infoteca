using log4net;

namespace Infoteca.Utilitarios.Utiles
{
    public class MensajeError
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string Code { get; set; }
        public string Mensaje { get { return _mensaje; } set { _mensaje = value; LogMensajeError(value); } }

        private string _mensaje;

        public MensajeError()
        {
            Code = string.Empty;
            Mensaje = string.Empty;
        }

        public MensajeError(string code, string mensaje)
        {
            Code = code ?? "";
            Mensaje = mensaje ?? "";
        }

        public bool ExisteError()
        {
            return !Code.Equals(string.Empty);
        }

        private void LogMensajeError(string value)
        {
            if (!value.Equals(string.Empty))
            {
                Log.Error(value);
            } 
        }
    }
}
