using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class TipoFuenteUT
    {
        #region Parametros

        public int LintID { get; set; }

        public string LstrNombre { get; set; }

        public DateTime FdtiFechaCreaccion { get; set; }

        #endregion

        #region Constructores

        public TipoFuenteUT()
        {
        }      

        public TipoFuenteUT(string lstrNombre)
        {
            this.LstrNombre = lstrNombre ?? throw new ArgumentNullException(nameof(lstrNombre));
        }

        public TipoFuenteUT(int lintID, string lstrNombre, DateTime fdtiFechaCreaccion)
        {
            LintID = lintID;
            LstrNombre = lstrNombre;
            FdtiFechaCreaccion = fdtiFechaCreaccion;
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
