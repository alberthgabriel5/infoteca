using log4net;

namespace Infoteca.Utilitarios.Utiles
{
    public static class EscribirLog
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogMensajeError(string value)
        {
            if (!value.Equals(string.Empty))
            {
                Log.Error(value);
            }
        }

        public static void LogMensajeDebug(string value)
        {
            if (!value.Equals(string.Empty))
            {
                Log.Debug(value);
            }
        }
    }
}
