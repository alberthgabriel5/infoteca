using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class PersonaUT
    {
        private int lintID;
        private string lstrTipoIdentificacion;
        private string lstrCedula;
        private string lstrNombre;
        private string lstrApelido;
        private string lstrAlias;
        private byte lbytActivo;

        public PersonaUT()
        {
        }

        public PersonaUT(int lintID, string lstrCedula, string lstrNombre, string lstrApelido, string lstrAlias, byte lbytActivo)
        {
            this.lintID = lintID;
            this.lstrCedula = lstrCedula;
            this.lstrNombre = lstrNombre;
            this.lstrApelido = lstrApelido;
            this.lstrAlias = lstrAlias;
            this.lbytActivo = lbytActivo;
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrTipoIdentificacion { get => lstrTipoIdentificacion; set => lstrTipoIdentificacion = value; }
        public string LstrCedula { get => lstrCedula; set => lstrCedula = value; }
        public string LstrNombre { get => lstrNombre; set => lstrNombre = value; }
        public string LstrApelido { get => lstrApelido; set => lstrApelido = value; }
        public string LstrAlias { get => lstrAlias; set => lstrAlias = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
