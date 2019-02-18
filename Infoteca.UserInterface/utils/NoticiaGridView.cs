using Infoteca.BizLayer;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.Utilitarios.Objetos
{
    public class NoticiaGridView
    {
        public int LintId { get; set; }
        public string LdtiFecha { get; set; }
        public string LstrDescripcion { get; set; }
        public string LstrSubDelito { get; set; }
        public string LintIdTipoDelito { get; set; }
        public string LstrPalabraClave { get; set; }
        public string LintIdFuente { get; set; }
        public string LobjImagenes { get; set; }
        public string LobjPersonas { get; set; }
        public string LobjPersonaJuridicas { get; set; }
        public string LobjVehiculos { get; set; }
        public string LobjPropiedades { get; set; }

        public NoticiaGridView()
        {
        }

        public static NoticiaGridView GetNoticiaGridView(NoticiaUT noticia)
        {
            var mensajeError = new MensajeError();

            var noticiaGridview = new NoticiaGridView()
            {
                LintId = noticia.LintId,
                LstrDescripcion = noticia.LstrDescripcion,
                LstrPalabraClave = noticia.LstrPalabraClave,
                LstrSubDelito = noticia.LstrSubDelito,
                LintIdTipoDelito = TipoDelitoBL.BuscarTipoDelito(noticia.LintIdTipoDelito, ref mensajeError).LstrNombre,
                LintIdFuente = FuenteBL.BuscarFuente(noticia.LintIdFuente, ref mensajeError).LstrNombreFuente,
                LdtiFecha = noticia.LdtiFecha.ToString("dd/MM/yyyy"),
                LobjImagenes = noticia.LobjImagenes != null ? noticia.LobjImagenes.Count.ToString() : "0",
                LobjPersonas = noticia.LobjPersonas != null ? noticia.LobjPersonas.Count.ToString() : "0",
                LobjVehiculos = noticia.LobjVehiculos != null ? noticia.LobjVehiculos.Count.ToString() : "0",
                LobjPersonaJuridicas = noticia.LobjPersonaJuridicas != null ? noticia.LobjPersonaJuridicas.Count.ToString() : "0",
                LobjPropiedades = noticia.LobjPropiedades != null ? noticia.LobjPropiedades.Count.ToString() : "0"
            };

            return noticiaGridview;
        }
}
}
