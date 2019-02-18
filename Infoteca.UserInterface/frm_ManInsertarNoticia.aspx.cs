using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManInsertarNoticia : Page
    {
       
        private NoticiaUT Noticia { get; set; }
        private const string ImagenesSession = "ImagenesSession";

        private List<PersonaUT> Personas
        {
            get => (List<PersonaUT>) ViewState["Personas"];
            set => ViewState["Personas"] = value;
        }

        private List<VehiculoUT> Vehiculos
        {
            get => (List<VehiculoUT>)ViewState["Vehiculos"];
            set => ViewState["Vehiculos"] = value;
        }

        private List<PersonaJuridicaUT> PersonaJuridicas
        {
            get => (List<PersonaJuridicaUT>)ViewState["PersonasJuridicas"];
            set => ViewState["PersonasJuridicas"] = value;
        }

        private List<PropiedadUT> Propiedades
        {
            get => (List<PropiedadUT>)ViewState["Propiedades"];
            set => ViewState["Propiedades"] = value;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!AjaxFileUpload1.IsInFileUploadPostBack)
                {
                    CargarTiposDelito();
                    CargarTiposFuente();
                    CargarFuentes();
                    CargarPersonas();
                    CargarVehiculos();
                    CargarPersonaJuridicas();
                    CargarPropiedades();
                }
            }
        }

        protected void Registrar_Noticia(object sender, EventArgs e)
        {
            var idFuente = 0;
            var mensajeError = new MensajeError();

            if (opcionRadioCrear.Checked)
            {
                if (!string.IsNullOrEmpty(NombreFuente.Value))
                {
                    if (!TipoFuentes.SelectedValue.Equals("-1"))
                    {
                        var tipoFuente = TipoFuenteBL.BuscarTipoFuente(int.Parse(TipoFuentes.SelectedValue), ref mensajeError);

                        var fuente = new FuenteUT
                        {
                            LstrNombreFuente = NombreFuente.Value,
                            LstrTitulo = Titulo.Value,
                            LstrSubTitulo = Subtitulo.Value,
                            LbytActivo = true,
                            LobjTipoFuente = tipoFuente
                        };

                        var fuenteCreada = FuenteBL.InsertarFuente(fuente, ref mensajeError);

                        if (!mensajeError.ExisteError())
                        {
                            idFuente = fuenteCreada.LintID;
                        }
                    }
                    else
                    {
                        controlMensajes.MostrarMensaje(true, "Por Favor, Ingrese un Tipo de Fuente Valido.");
                        return;
                    }
                }
                else
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Ingrese un Nombre de Fuente Valido.");
                    return;
                }
            }
            else if (opcionRadioSeleccionar.Checked)
            {
                if (!Fuentes.SelectedValue.Equals("-1"))
                {
                    idFuente = int.Parse(Fuentes.SelectedValue);
                }
                else
                {
                    controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione una Fuente.");
                    return;
                }
            }

            List<ImagenUT> imagenes = null;

            if (Session[ImagenesSession] != null)
            {
                imagenes = (List<ImagenUT>)Session[ImagenesSession];
            }

            if (TipoDelitos.SelectedValue.Equals("-1"))
            {
                controlMensajes.MostrarMensaje(true, "Por Favor, Seleccione un Tipo de Delito.");
                return;
            }

            List<PersonaUT> personas = null;

            mensajeError = new MensajeError();

            if (PersonasSeleccionadasMLB.Items.Count > 0)
            {
                personas = new List<PersonaUT>();

                foreach (ListItem listItem in PersonasSeleccionadasMLB.Items)
                {
                    var personaBuscada = PersonaBL.BuscarPersona(int.Parse(listItem.Value), ref mensajeError);

                    if (!mensajeError.ExisteError())
                    {
                        personas.Add(personaBuscada);
                    }
                }
            }

            List<VehiculoUT> vehiculos = null;

            mensajeError = new MensajeError();

            if (ListBoxVehiculoSeleccionados.Items.Count > 0)
            {
                vehiculos = new List<VehiculoUT>();
                foreach (ListItem listItem in ListBoxVehiculoSeleccionados.Items)
                { 
                    var vehiculoBuscado = VehiculoBL.BuscarVehiculo(int.Parse(listItem.Value), ref mensajeError);

                    if (!mensajeError.ExisteError())
                    {
                        vehiculos.Add(vehiculoBuscado);
                    }
                }
            }

            List<PersonaJuridicaUT> juridicas = null;

            mensajeError = new MensajeError();

            if (ListBoxVehiculoSeleccionados.Items.Count > 0)
            {
                juridicas = new List<PersonaJuridicaUT>();

                foreach (ListItem listItem in ListBoxPersonaJuridicaSeleccionados.Items)
                {
                    var juridicaBuscado =
                        PersonaJuridicaBL.BuscarPersonaJuridica(int.Parse(listItem.Value), ref mensajeError);

                    if (!mensajeError.ExisteError())
                    {
                        juridicas.Add(juridicaBuscado);
                    }
                }
            }

            List<PropiedadUT> propiedades = null;

            mensajeError = new MensajeError();

            if (ListBoxPropiedadeSeleccionados.Items.Count > 0)
            {
                propiedades = new List<PropiedadUT>();

                foreach (ListItem listItem in ListBoxPropiedadeSeleccionados.Items)
                {
                    var propiedadBuscada = PropiedadBL.BuscarPropiedad(int.Parse(listItem.Value), ref mensajeError);

                    if (!mensajeError.ExisteError())
                    {
                        propiedades.Add(propiedadBuscada);
                    }
                }
            }

            Noticia = new NoticiaUT()
            {
                LintIdTipoDelito = int.Parse(TipoDelitos.SelectedValue),
                LdtiFecha = DateTime.Parse(fecha.Value),
                LstrDescripcion = descripcion.Value,
                LstrSubDelito = subDelito.Value,
                LstrPalabraClave = palabrasClave.Value,
                LobjImagenes = imagenes,
                LintIdFuente = idFuente,
                LobjPersonas = personas,
                LobjVehiculos = vehiculos,
                LobjPersonaJuridicas = juridicas,
                LobjPropiedades = propiedades,
                LbytActivo = 1
            };

            NoticiaBL.InsertarNoticia(Noticia, ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, mensajeError.Mensaje);
            }
            else
            {
                controlMensajes.MostrarMensaje(false, "Noticia Creadad");
            }

            hidTAB.Value = "#home";
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var imagenes = new List<ImagenUT>();

            if (Session[ImagenesSession] != null)
            {
                imagenes = (List<ImagenUT>)Session[ImagenesSession];
            }

            using (var stream = e.GetStreamContents())
            {
                imagenes.Add(new ImagenUT()
                {
                    LstrNombre = e.FileName,
                    FdtiFechaCreaccion = DateTime.Now,
                    LByteImagen = LeerImagen(stream)
                });
            }

            Session.Remove(ImagenesSession);

            Session.Add(ImagenesSession, imagenes);
        }

        protected void Registrar_Persona(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombrePersona.Value))
            {
                ModalTitulo.InnerText = "Error al crear Persona";
                ModalMensaje.Text = $"Ingrese un nombre de Persona Valido";

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
            }
            else
            {
                var mensajeError = new MensajeError();
                var persona = new PersonaUT()
                {
                    LstrCedula = Identificacion.Value,
                    LstrNombre = NombrePersona.Value,
                    LstrApelido = Apellidos.Value,
                    LstrAlias = Alias.Value,
                    LbytActivo = 1
                };

                var personaCreada = PersonaBL.InsertarPersona(persona, ref mensajeError);

                if (!mensajeError.ExisteError())
                {
                    PersonasSeleccionadasMLB.Items.Add(new ListItem()
                    {
                        Value = personaCreada.LintID.ToString(),
                        Text = $"{personaCreada.LstrNombre} {personaCreada.LstrApelido}"
                    });

                    hidTAB.Value = "#menu2";
                }
                else
                {
                    ModalTitulo.InnerText = "Error al crear Persona";
                    ModalMensaje.Text = "Error insertando Persona";

                    ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
                }
            }
        }

        protected void Registrar_Vehiculo(object sender, EventArgs e)
        {
            var mensajeError = new MensajeError();

            var vehiculo = new VehiculoUT()
            {
                LstrPlaca = Placa.Value,
                LstrColor = Color.Value,
                LstrEstilo = Tipo.Value,
                LstrMarca = Marca.Value,
                LstrModelo = Modelo.Value,
                LbytActivo = 1
            };

            var vehiculoCreado = VehiculoBL.InsertarVehiculo(vehiculo, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                ListBoxVehiculoSeleccionados.Items.Add(new ListItem()
                {
                    Value = vehiculoCreado.LintID.ToString(),
                    Text = $"{vehiculo.LstrPlaca} {vehiculo.LstrMarca} {vehiculo.LstrModelo}"
                });

                hidTAB.Value = "#menu3";
            }
            else
            {
                ModalTitulo.InnerText = "Error al crear Vehiculo";
                ModalMensaje.Text = "Error insertando Vehiculo";

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
            }
        
        }

        protected void Registrar_PersonaJuridica(object sender, EventArgs e)
        {
            var mensajeError = new MensajeError();

            var personaJuridica = new PersonaJuridicaUT()
            {
                LstrCedulaJuridica = IdentificacionJU.Value,
                LstrNombreJuridico = NombreJU.Value,
                LstrNombrePublico = Fantasia.Value,
                LbytActivo = 1
            };

            var personaJuridicaCreado = PersonaJuridicaBL.InsertarPersonaJuridica(personaJuridica, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                ListBoxPersonaJuridicaSeleccionados.Items.Add(new ListItem()
                {
                    Value = personaJuridicaCreado.LintID.ToString(),
                    Text = $"{personaJuridicaCreado.LstrCedulaJuridica} {personaJuridicaCreado.LstrNombreJuridico}"
                });

                hidTAB.Value = "#menu4";
            }
            else
            {
                ModalTitulo.InnerText = "Error al crear PersonaJuridica";
                ModalMensaje.Text = "Error insertando PersonaJuridica";

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
            }

        }

        protected void Registrar_Propiedad(object sender, EventArgs e)
        {
            var mensajeError = new MensajeError();

            var propiedad = new PropiedadUT()
            {
                LstrTipoPropiedad = TipoPropiedad.Value,
                LstrLugar = Ubicacion.Value,
                LbytActivo = 1
            };

            var propiedadCreado = PropiedadBL.InsertarPropiedad(propiedad, ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                ListBoxPropiedadeSeleccionados.Items.Add(new ListItem()
                {
                    Value = propiedadCreado.LintID.ToString(),
                    Text = $"{propiedadCreado.LstrLugar} {propiedadCreado.LstrTipoPropiedad}"
                });

                hidTAB.Value = "#menu5";
            }
            else
            {
                ModalTitulo.InnerText = "Error al crear Propiedad";
                ModalMensaje.Text = "Error insertando Propiedad";

                ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "openModal();", true);
            }

        }

        private void CargarTiposDelito()
        {
            var mensajeError = new MensajeError();

            var tiposDelito = TipoDelitoBL.BuscarTodosTipoDelito(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando los tipos de delito");
            }
            else
            {
                foreach (var tipoDelito in tiposDelito)
                {
                    TipoDelitos.Items.Add(new ListItem(tipoDelito.LstrNombre, $"{tipoDelito.LintID}"));
                }
            }
        }

        private void CargarTiposFuente()
        {
            var mensajeError = new MensajeError();

            var tiposFuente = TipoFuenteBL.BuscarTodosTipoFuente(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando los tipos de Fuente");
            }
            else
            {
                foreach (var tipoFuente in tiposFuente)
                {
                    TipoFuentes.Items.Add(new ListItem(tipoFuente.LstrNombre, $"{tipoFuente.LintID}"));
                }
            }
        }

        private void CargarFuentes()
        {
            var mensajeError = new MensajeError();

            var fuenteList = FuenteBL.BuscarTodosFuente(ref mensajeError);

            if (mensajeError.ExisteError())
            {
                controlMensajes.MostrarMensaje(true, "Error Cargando las Fuentes");
            }
            else
            {
                foreach (var fuente in fuenteList)
                {
                    Fuentes.Items.Add(new ListItem(fuente.LstrNombreFuente, $"{fuente.LintID}"));
                }
            }
        }

        private void CargarPersonas()
        {
            var mensajeError = new MensajeError();

            Personas = PersonaBL.BuscarTodosPersona(ref mensajeError);

            Personas = Personas.OrderBy(s => s.LstrNombre).ToList();

            if (!mensajeError.ExisteError())
            {
                foreach (var persona in Personas)
                {
                    var alias = string.IsNullOrEmpty(persona.LstrAlias) ? "" : $"({persona.LstrAlias})";
                    var item = new ListItem()
                    {
                        Value = persona.LintID.ToString(),
                        Text =  $"{persona.LstrNombre} {persona.LstrApelido} {alias}"
                    };

                    PersonasMLB.Items.Add(item);
                }
            }
        }

        private void CargarVehiculos()
        {
            var mensajeError = new MensajeError();

            Vehiculos = VehiculoBL.BuscarTodosVehiculo(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var vehiculo in Vehiculos)
                {
                    var item = new ListItem()
                    {
                        Value = vehiculo.LintID.ToString(),
                        Text = $"{vehiculo.LstrPlaca} {vehiculo.LstrMarca} {vehiculo.LstrModelo}"
                    };

                    ListBoxVehiculos.Items.Add(item);
                }
            }
        }

        private void CargarPersonaJuridicas()
        {
            var mensajeError = new MensajeError();

            PersonaJuridicas = PersonaJuridicaBL.BuscarTodosPersonaJuridica(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var personaJuridica in PersonaJuridicas)
                {
                    var item = new ListItem()
                    {
                        Value = personaJuridica.LintID.ToString(),
                        Text = $"{personaJuridica.LstrCedulaJuridica} {personaJuridica.LstrNombreJuridico}"
                    };

                    ListBoxPersonaJuridicas.Items.Add(item);
                }
            }
        }

        private static byte[] LeerImagen(Stream input)
        {
            var buffer = new byte[16 * 1024];

            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

        private void CargarPropiedades()
        {
            var mensajeError = new MensajeError();

            Propiedades = PropiedadBL.BuscarTodosPropiedad(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                foreach (var propiedad in Propiedades)
                {
                    var item = new ListItem()
                    {
                        Value = propiedad.LintID.ToString(),
                        Text = $"{propiedad.LstrLugar} {propiedad.LstrTipoPropiedad}"
                    };

                    ListBoxPropiedades.Items.Add(item);
                }
            }
        }

        protected void AgregarPersonas_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in PersonasMLB.GetSelectedIndices())
            {
                var item = PersonasMLB.Items[indexItem];

                PersonasSeleccionadasMLB.Items.Add(item);

                PersonasMLB.Items.Remove(item);
            }

            hidTAB.Value = "#menu2";
        }

        protected void QuitarPersonas_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in PersonasSeleccionadasMLB.GetSelectedIndices())
            {
                var item = PersonasSeleccionadasMLB.Items[indexItem];

                PersonasMLB.Items.Add(item);

                PersonasSeleccionadasMLB.Items.Remove(item);
            }

            hidTAB.Value = "#menu2";
        }

        protected void AgregarVehiculos_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxVehiculos.GetSelectedIndices())
            {
                var item = ListBoxVehiculos.Items[indexItem];

                ListBoxVehiculoSeleccionados.Items.Add(item);

                ListBoxVehiculos.Items.Remove(item);
            }

            hidTAB.Value = "#menu3";
        }

        protected void QuitarVehiculos_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxVehiculoSeleccionados.GetSelectedIndices())
            {
                var item = ListBoxVehiculoSeleccionados.Items[indexItem];

                ListBoxVehiculos.Items.Add(item);

                ListBoxVehiculoSeleccionados.Items.Remove(item);
            }

            hidTAB.Value = "#menu3";
        }

        protected void AgregarPersonaJuridicas_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxPersonaJuridicas.GetSelectedIndices())
            {
                var item = ListBoxPersonaJuridicas.Items[indexItem];

                ListBoxPersonaJuridicaSeleccionados.Items.Add(item);

                ListBoxPersonaJuridicas.Items.Remove(item);
            }

            hidTAB.Value = "#menu4";
        }

        protected void QuitarPersonaJuridicas_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxPersonaJuridicaSeleccionados.GetSelectedIndices())
            {
                var item = ListBoxPersonaJuridicaSeleccionados.Items[indexItem];

                ListBoxPersonaJuridicas.Items.Add(item);

                ListBoxPersonaJuridicaSeleccionados.Items.Remove(item);
            }

            hidTAB.Value = "#menu4";
        }

        protected void AgregarPropiedades_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxPropiedades.GetSelectedIndices())
            {
                var item = ListBoxPropiedades.Items[indexItem];

                ListBoxPropiedadeSeleccionados.Items.Add(item);

                ListBoxPropiedades.Items.Remove(item);
            }

            hidTAB.Value = "#menu5";
        }

        protected void QuitarPropiedades_OnClick(object sender, EventArgs e)
        {
            foreach (var indexItem in ListBoxPropiedadeSeleccionados.GetSelectedIndices())
            {
                var item = ListBoxPropiedadeSeleccionados.Items[indexItem];

                ListBoxPropiedades.Items.Add(item);

                ListBoxPropiedadeSeleccionados.Items.Remove(item);
            }

            hidTAB.Value = "#menu5";
        }

        protected void FiltrarPersonas_TextChanged(object sender, EventArgs e)
        {
            PersonasMLB.Items.Clear();

            if (string.IsNullOrEmpty(FiltrarPersonas.Text))
            {
                foreach (var persona in Personas)
                {
                    var item = new ListItem()
                    {
                        Value = persona.LintID.ToString(),
                        Text = $"{persona.LstrNombre} {persona.LstrApelido}"
                    };

                    PersonasMLB.Items.Add(item);
                }
            }
            else
            {
                foreach (var persona in Personas)
                {
                    if (persona.LstrNombre.ToLower().Contains(FiltrarPersonas.Text.ToLower()) ||
                        persona.LstrApelido.ToLower().Contains(FiltrarPersonas.Text.ToLower()) ||
                        persona.LstrCedula.ToLower().Contains(FiltrarPersonas.Text.ToLower()))
                    {
                        var item = new ListItem()
                        {
                            Value = persona.LintID.ToString(),
                            Text = $"{persona.LstrNombre} {persona.LstrApelido}"
                        };

                        PersonasMLB.Items.Add(item);
                    }
                }
            }

            hidTAB.Value = "#menu2";
        }
        
        protected void FiltrarVehiculos_TextChanged(object sender, EventArgs e)
        {
            ListBoxVehiculos.Items.Clear();

            if (string.IsNullOrEmpty(FiltrarVehiculos.Text))
            {
                foreach (var vehiculo in Vehiculos)
                {
                    var item = new ListItem()
                    {
                        Value = vehiculo.LintID.ToString(),
                        Text = $"{vehiculo.LstrPlaca} {vehiculo.LstrMarca} {vehiculo.LstrModelo}"
                    };

                    ListBoxVehiculos.Items.Add(item);
                }
            }
            else
            {
                foreach (var vehiculo in Vehiculos)
                {
                    if (vehiculo.LstrPlaca.ToLower().Contains(FiltrarVehiculos.Text.ToLower()) ||
                        vehiculo.LstrMarca.ToLower().Contains(FiltrarVehiculos.Text.ToLower()) ||
                        vehiculo.LstrModelo.ToLower().Contains(FiltrarVehiculos.Text.ToLower()))
                    {
                        var item = new ListItem()
                        {
                            Value = vehiculo.LintID.ToString(),
                            Text = $"{vehiculo.LstrPlaca} {vehiculo.LstrMarca} {vehiculo.LstrModelo}"
                        };

                        ListBoxVehiculos.Items.Add(item);
                    }
                }
            }

            hidTAB.Value = "#menu3";
        }
        
        protected void FiltrarPersonasJuridicas_TextChanged(object sender, EventArgs e)
        {
            ListBoxPersonaJuridicas.Items.Clear();

            if (string.IsNullOrEmpty(FiltarPersonasJuridicas.Text))
            {
                foreach (var personaJuridica in PersonaJuridicas)
                {
                    var item = new ListItem()
                    {
                        Value = personaJuridica.LintID.ToString(),
                        Text = $"{personaJuridica.LstrCedulaJuridica} {personaJuridica.LstrNombreJuridico}"
                    };

                    ListBoxPersonaJuridicas.Items.Add(item);
                }
            }
            else
            {
                foreach (var personaJuridica in PersonaJuridicas)
                {
                    if (personaJuridica.LstrCedulaJuridica.ToLower().Contains(FiltarPersonasJuridicas.Text.ToLower()) ||
                        personaJuridica.LstrNombreJuridico.ToLower().Contains(FiltarPersonasJuridicas.Text.ToLower()))
                    {
                        var item = new ListItem()
                        {
                            Value = personaJuridica.LintID.ToString(),
                            Text = $"{personaJuridica.LstrCedulaJuridica} {personaJuridica.LstrNombreJuridico}"
                        };

                        ListBoxPersonaJuridicas.Items.Add(item);
                    }
                }
            }

            hidTAB.Value = "#menu4";
        }

        protected void FiltrarPropiedades_TextChanged(object sender, EventArgs e)
        {
            ListBoxPropiedades.Items.Clear();

            if (string.IsNullOrEmpty(FiltrarPropiedades.Text))
            {
                foreach (var propiedad in Propiedades)
                {
                    var item = new ListItem()
                    {
                        Value = propiedad.LintID.ToString(),
                        Text = $"{propiedad.LstrLugar} {propiedad.LstrTipoPropiedad}"
                    };

                    ListBoxPropiedades.Items.Add(item);
                }
            }
            else
            {
                foreach (var propiedad in Propiedades)
                {
                    if (propiedad.LstrLugar.ToLower().Contains(FiltrarPropiedades.Text.ToLower()))/* ||
                        propiedad.LstrAlias.ToLower().Contains(FiltrarPropiedades.Text.ToLower()))*/
                    {
                        var item = new ListItem()
                        {
                            Value = propiedad.LintID.ToString(),
                            Text = $"{propiedad.LstrLugar} {propiedad.LstrTipoPropiedad}"
                        };

                        ListBoxPropiedades.Items.Add(item);
                    }
                }
            }

            hidTAB.Value = "#menu5";
        }
        
    }
}