using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class ImagenUT
    {
        
        #region Parametros
        private int lintID;
        private string lstrNombre;
        private byte[] lByteImagen;
        private DateTime fdtiFechaCreaccion;
        private byte lbytActivo;
      
        #endregion

        #region Constructores

        public ImagenUT()
        {
        }

        public ImagenUT(string lstrNombre)
        {
            this.LstrNombre = lstrNombre ?? throw new ArgumentNullException(nameof(lstrNombre));
        }

        public ImagenUT(int lintID, string lstrNombre, DateTime fdtiFechaCreaccion, byte[] lByteImagen)
        {
            LintID = lintID;
            LstrNombre = lstrNombre;
            FdtiFechaCreaccion = fdtiFechaCreaccion;
            LByteImagen = lByteImagen;
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrNombre { get => lstrNombre; set => lstrNombre = value; }
        public byte[] LByteImagen { get => lByteImagen; set => lByteImagen = value; }
        public DateTime FdtiFechaCreaccion { get => fdtiFechaCreaccion; set => fdtiFechaCreaccion = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }

        #endregion

        #region Metodos Soporte

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion
    }
}
