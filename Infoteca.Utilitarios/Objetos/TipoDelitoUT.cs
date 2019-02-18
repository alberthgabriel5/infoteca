using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class TipoDelitoUT
    {
        #region Parametros

        
        private int lintID;
        private string lstrNombre;
        private DateTime fdtiFechaCreaccion;
        private byte lbytActivo;

       public int LintID { get => lintID; set => lintID = value; }
        public string LstrNombre { get => lstrNombre; set => lstrNombre = value; }
        public DateTime FdtiFechaCreaccion { get => fdtiFechaCreaccion; set => fdtiFechaCreaccion = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }

        #endregion

        #region Constructores

        public TipoDelitoUT()
        {
        }

        public TipoDelitoUT(string lstrNombre)
        {
            this.LstrNombre = lstrNombre ?? throw new ArgumentNullException(nameof(lstrNombre));
        }

        public TipoDelitoUT(int lintID, string lstrNombre, DateTime fdtiFechaCreaccion, byte lbytActivo)
        {
            LintID = lintID;
            LstrNombre = lstrNombre;
            FdtiFechaCreaccion = fdtiFechaCreaccion;
            this.LbytActivo = lbytActivo;
        }

        

        #endregion

        #region Metodos Soporte

        public override string ToString()
        {
            return $"LintID : {LintID} , LstrNombre : {LstrNombre}, FdtiFechaCreaccion : {FdtiFechaCreaccion.ToString("G")}";
        }

        #endregion
    }
}
