//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infoteca.DataAccess.TRAN
{
    using System;
    using System.Collections.Generic;
    
    public partial class TInfoteca_Noticia_Imagen
    {
        public int TN_Id { get; set; }
        public int TN_Id_Noticia { get; set; }
        public int TN_Id_Imagen { get; set; }
        public bool TB_Activo { get; set; }
    
        public virtual TInfoteca_Imagen TInfoteca_Imagen { get; set; }
        public virtual TInfoteca_Noticia TInfoteca_Noticia { get; set; }
    }
}
