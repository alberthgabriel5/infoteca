using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class MensajeUsuarioUT
    {
        private int lintID;
        private string lstrFormato;
        private string lstrAccion;
        private string lstrTabla;
        private string lstrMensaje;
        private byte lbytActivo;

        public MensajeUsuarioUT()
        {
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrFormato { get => lstrFormato; set => lstrFormato = value; }
        public string LstrAccion { get => lstrAccion; set => lstrAccion = value; }
        public string LstrTabla { get => lstrTabla; set => lstrTabla = value; }
        public string LstrMensaje { get => lstrMensaje; set => lstrMensaje = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
