using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UserInterface
{
    public partial class frm_ManVerNoticia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var idNoticia = int.Parse(Request["IdNoticia"] ?? "0");

                if (Request["PaginaActual"] != null)
                {
                    if (Request["PaginaActual"].Equals("Criterio"))
                    {
                        volver.PostBackUrl = "frm_ConBusquedaPorCriterio.aspx";
                    }

                    if (Request["PaginaActual"].Equals("Rango"))
                    {
                        volver.PostBackUrl = "frm_ConBusquedaPorRango.aspx";
                    }

                    if (Request["PaginaActual"].Equals("Noticia"))
                    {
                        volver.PostBackUrl = "frm_ManBuscarNoticia.aspx";
                    }
                }                

                var mensajeError = new MensajeError();

                var noticia = NoticiaBL.BuscarNoticia(idNoticia, ref mensajeError, true);

                if (!mensajeError.ExisteError())
                {
                    CargarNoticia(noticia);
                }
            }
        }
          
        private void CargarNoticia(NoticiaUT noticia)
        {
            var mensajeError = new MensajeError();

            LBExportar.PostBackUrl = $"/frm_ConReporteNoticia.aspx?idNoticia={noticia.LintId}";

            var tipoDelito = TipoDelitoBL.BuscarTipoDelito(noticia.LintIdTipoDelito, ref mensajeError);
            var fuente = FuenteBL.BuscarFuente(noticia.LintIdFuente, ref mensajeError);

            TipoDelito.Text = tipoDelito.LstrNombre;
            Fecha.Text = noticia.LdtiFecha.ToString("G");
            Descripcion.Text = noticia.LstrDescripcion;
            SubDelito.Text = noticia.LstrSubDelito;
            PalabrasClave.Text = noticia.LstrPalabraClave;

            Fuente.Text = fuente.LstrNombreFuente;
            Titulo.Text = fuente.LstrTitulo;
            SubDelito.Text = fuente.LstrSubTitulo;

            if (noticia.LobjImagenes != null)
            {
                foreach (var imagen in noticia.LobjImagenes)
                {
                    var imagenASP = new Image()
                    {
                        ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imagen.LByteImagen)
                    };
                    
                    TablaImagenes.Rows.Add(new TableRow()
                    {
                        Cells =
                        {
                            new TableCell()
                            {
                                Controls =
                                {
                                    imagenASP
                                }
                            }
                        }
                    });
                }
            }

            if (noticia.LobjPersonas != null)
            {
                foreach (var persona in noticia.LobjPersonas)
                {
                    var tableRow = new TableRow();

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = persona.LstrCedula
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = persona.LstrNombre
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = persona.LstrApelido
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = persona.LstrAlias
                    });

                    TablaPersonas.Rows.Add(tableRow);
                }
            }
            
            if (noticia.LobjVehiculos != null)
            {
                foreach (var vehiculo in noticia.LobjVehiculos)
                {
                    var tableRow = new TableRow();

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = vehiculo.LstrPlaca
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = vehiculo.LstrMarca
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = vehiculo.LstrModelo
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = vehiculo.LstrEstilo
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = vehiculo.LstrColor
                    });

                    //tableRow.Cells.Add(new TableCell()
                    //{
                    //    Text = vehiculo.
                    //});

                    TablaVehiculos.Rows.Add(tableRow);

                }
            }

            if (noticia.LobjPersonaJuridicas != null)
            {
                foreach (var juridicas in noticia.LobjPersonaJuridicas)
                {
                    var tableRow = new TableRow();

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = juridicas.LstrCedulaJuridica
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = juridicas.LstrCedulaJuridica
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = juridicas.LstrNombreJuridico
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = juridicas.LstrNombrePublico
                    });

                    TablasJuridicas.Rows.Add(tableRow);

                }
            }

            if (noticia.LobjPropiedades != null)
            {
                foreach (var propiedades in noticia.LobjPropiedades)
                {
                    var tableRow = new TableRow();
                    
                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = propiedades.LstrLugar
                    });

                    TablaPropiedades.Rows.Add(tableRow);
                }
            }
        }

    }    
}