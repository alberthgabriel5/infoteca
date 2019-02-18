using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class VehiculoUT
    {
        private int lintID;
        private string lstrPlaca;
        private string lstrEstilo;
        private string lstrMarca;
        private string lstrModelo;
        private string lstrColor;
        private byte lbytActivo;

        public VehiculoUT()
        {
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrPlaca { get => lstrPlaca; set => lstrPlaca = value; }
        public string LstrEstilo { get => lstrEstilo; set => lstrEstilo = value; }
        public string LstrMarca { get => lstrMarca; set => lstrMarca = value; }
        public string LstrModelo { get => lstrModelo; set => lstrModelo = value; }
        public string LstrColor { get => lstrColor; set => lstrColor = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
