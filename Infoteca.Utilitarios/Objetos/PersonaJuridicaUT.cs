using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class PersonaJuridicaUT
    {
        private int lintID;
        private string lstrCedulaJuridica;
        private string lstrNombreJuridico;        
        private string lstrNombrePublico;
        private byte lbytActivo;

        public PersonaJuridicaUT()
        {
        }

        public PersonaJuridicaUT(int lintID, string lstrCedulaJuridica, string lstrNombreJuridico, string lstrNombrePublico, byte lbytActivo)
        {
            this.lintID = lintID;
            this.lstrCedulaJuridica = lstrCedulaJuridica;
            this.lstrNombreJuridico = lstrNombreJuridico;
            this.lstrNombrePublico = lstrNombrePublico;
            this.LbytActivo = lbytActivo;
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrCedulaJuridica { get => lstrCedulaJuridica; set => lstrCedulaJuridica = value; }
        public string LstrNombreJuridico { get => lstrNombreJuridico; set => lstrNombreJuridico = value; }
        public string LstrNombrePublico { get => lstrNombrePublico; set => lstrNombrePublico = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
