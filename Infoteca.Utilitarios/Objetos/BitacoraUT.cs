using Infoteca.Utilitarios.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class BitacoraUT
    {
        public int TN_Id { get; set; }
        public string TC_Operacion { get; set; }
        public string TC_Usuario { get; set; }
        public string TC_Host { get; set; }
        public System.DateTime TD_Modificado { get; set; }
        public string TC_Tabla { get; set; }
        public int TN_IdObjeto { get; set; }
        public bool TB_Activo { get; set; }
    }
}
