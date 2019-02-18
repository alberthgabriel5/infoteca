using Infoteca.Utilitarios.Objetos;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class FuenteUT
    {
        private int lintIDFuente;
        private string lstrNombreFuente;
        private string lstrTitulo;
        private string lstrSubTitulo;
        private bool lbytActivo;
        private TipoFuenteUT lobjTipoFuente;

        public FuenteUT() { }

       

   

        public int LintID { get => lintIDFuente; set => lintIDFuente = value; }
        public string LstrNombreFuente { get => lstrNombreFuente; set => lstrNombreFuente = value; }
        public string LstrTitulo { get => lstrTitulo; set => lstrTitulo = value; }
        public string LstrSubTitulo { get => lstrSubTitulo; set => lstrSubTitulo = value; }
        public TipoFuenteUT LobjTipoFuente { get => lobjTipoFuente; set => lobjTipoFuente = value; }
        public bool LbytActivo { get => lbytActivo; set => lbytActivo = value; }

       
    }
}
