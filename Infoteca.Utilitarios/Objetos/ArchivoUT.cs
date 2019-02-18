using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class ArchivoUT
    {
        private int lintID;        
        private string lstrNombre;
        private string lstrExtension;
        private string lstrContenido;
        private byte lbytActivo;

        public ArchivoUT()
        {
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrNombre { get => lstrNombre; set => lstrNombre = value; }
        public string LstrExtension { get => lstrExtension; set => lstrExtension = value; }
        public string LstrContenido { get => lstrContenido; set => lstrContenido = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }

        
    }
}
