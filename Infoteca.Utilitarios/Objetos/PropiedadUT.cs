using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class PropiedadUT
    {
        private int lintID;       
        private string lstrLugar;
        private string lstrTipoPropiedad;
        private byte lbytActivo;

        public PropiedadUT()
        {
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrLugar { get => lstrLugar; set => lstrLugar = value; }
        public string LstrTipoPropiedad { get => lstrTipoPropiedad; set => lstrTipoPropiedad = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
