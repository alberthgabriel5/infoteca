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
    
    public partial class TInfoteca_Persona_Juridica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TInfoteca_Persona_Juridica()
        {
            this.TInfoteca_Noticia_Juridica = new HashSet<TInfoteca_Noticia_Juridica>();
        }
    
        public int TN_Id { get; set; }
        public string TC_Nombre { get; set; }
        public string TC_Nombre_Fantasia { get; set; }
        public string TC_Cedula { get; set; }
        public Nullable<System.DateTime> TF_Fecha_Creacion { get; set; }
        public bool TB_Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TInfoteca_Noticia_Juridica> TInfoteca_Noticia_Juridica { get; set; }
    }
}
