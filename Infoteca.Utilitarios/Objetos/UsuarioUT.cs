using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class UsuarioUT
    {
        private int lintID;
        private string lstrUsuario;
        private string lstrIdentificacion;
        private string lstrNombre;
        private string lstrPrimerApellido;
        private string lstrSegundoApellido;
        private string lstrTipoAutentificacion;
        private string lstrTipoUsuario;
        private string lstrEmail;
        private string lintIntentosAcceso;
        private string lstrUsuarioActualiza;
        private DateTime ldtiFechaActualiza;
        private string lstrObservaciones;
        private byte lbytEliminado;
        private string lstrTipoIdentificacionID;
        private string lstrInstitucionID;
        private string lstrOficinaID;
        private byte lbytActivo;

        public UsuarioUT()
        {
        }

        public int LintID { get => lintID; set => lintID = value; }
        public string LstrUsuario { get => lstrUsuario; set => lstrUsuario = value; }
        public string LstrIdentificacion { get => lstrIdentificacion; set => lstrIdentificacion = value; }
        public string LstrNombre { get => lstrNombre; set => lstrNombre = value; }
        public string LstrPrimerApellido { get => lstrPrimerApellido; set => lstrPrimerApellido = value; }
        public string LstrSegundoApellido { get => lstrSegundoApellido; set => lstrSegundoApellido = value; }
        public string LstrTipoAutentificacion { get => lstrTipoAutentificacion; set => lstrTipoAutentificacion = value; }
        public string LstrTipoUsuario { get => lstrTipoUsuario; set => lstrTipoUsuario = value; }
        public string LstrEmail { get => lstrEmail; set => lstrEmail = value; }
        public string LintIntentosAcceso { get => lintIntentosAcceso; set => lintIntentosAcceso = value; }
        public string LstrUsuarioActualiza { get => lstrUsuarioActualiza; set => lstrUsuarioActualiza = value; }
        public DateTime LdtiFechaActualiza { get => ldtiFechaActualiza; set => ldtiFechaActualiza = value; }
        public string LstrObservaciones { get => lstrObservaciones; set => lstrObservaciones = value; }
        public byte LbytEliminado { get => lbytEliminado; set => lbytEliminado = value; }
        public string LstrTipoIdentificacionID { get => lstrTipoIdentificacionID; set => lstrTipoIdentificacionID = value; }
        public string LstrInstitucionID { get => lstrInstitucionID; set => lstrInstitucionID = value; }
        public string LstrOficinaID { get => lstrOficinaID; set => lstrOficinaID = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
    }
}
