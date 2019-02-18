using Infoteca.Utilitarios.Objetos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infoteca.Utilitarios.Objetos
{
    [Serializable]
    public class NoticiaUT
    {

        //parametros nativos
        private int lintId;
        private DateTime ldtiFecha;
        private string lstrDescripcion;
        private string lstrSubDelito;
        private string lstrPalabraClave;
        private int lintIdTipoDelito;
        private int lintIdFuente;
        private byte lbytActivo;

        //parametros dinamicos

        private List<ImagenUT> lobjImagenes;
        private List<PersonaUT> lobjPersonas;
        private List<PersonaJuridicaUT> lobjPersonaJuridicas;
        private List<VehiculoUT> lobjVehiculos;
        private List<PropiedadUT> lobjPropiedades;
        private List<PropiedadUT> lobjArchivos;

        public int LintId { get => lintId; set => lintId = value; }
        public DateTime LdtiFecha { get => ldtiFecha; set => ldtiFecha = value; }
        public string LstrDescripcion { get => lstrDescripcion; set => lstrDescripcion = value; }
        public string LstrSubDelito { get => lstrSubDelito; set => lstrSubDelito = value; }
        public string LstrPalabraClave { get => lstrPalabraClave; set => lstrPalabraClave = value; }
        public int LintIdTipoDelito { get => lintIdTipoDelito; set => lintIdTipoDelito = value; }
        public int LintIdFuente { get => lintIdFuente; set => lintIdFuente = value; }
        public byte LbytActivo { get => lbytActivo; set => lbytActivo = value; }
        public List<ImagenUT> LobjImagenes { get => lobjImagenes; set => lobjImagenes = value; }
        public List<PersonaUT> LobjPersonas { get => lobjPersonas; set => lobjPersonas = value; }
        public List<PersonaJuridicaUT> LobjPersonaJuridicas { get => lobjPersonaJuridicas; set => lobjPersonaJuridicas = value; }
        public List<VehiculoUT> LobjVehiculos { get => lobjVehiculos; set => lobjVehiculos = value; }
        public List<PropiedadUT> LobjPropiedades { get => lobjPropiedades; set => lobjPropiedades = value; }
        public List<PropiedadUT> LobjArchivos { get => lobjArchivos; set => lobjArchivos = value; }

        public NoticiaUT()
        {
        }

    }
}
