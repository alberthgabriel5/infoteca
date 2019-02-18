using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using Image = System.Web.UI.WebControls.Image;
using Infoteca.UserInterface.utils;

namespace Infoteca.UserInterface
{
    public partial class frm_ConReporteNoticia : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["idNoticia"] != null)
            {
                var idNoticia = int.Parse(Request["idNoticia"]);

                NumeroNoticia.Text = Request["idNoticia"];

                var mensajeError = new MensajeError();

                var noticia = NoticiaBL.BuscarNoticia(idNoticia, ref mensajeError, true);

                if (!mensajeError.ExisteError())
                {
                    CargarNoticia(noticia);

                    TituloNoticia.InnerText = $"Noticia #{NumeroNoticia.Text}";

                    DivNoticia.Visible = true;
                    BtnGenerarPDF.Visible = true;
                }
            }
        }

        protected void BuscarNoticia(object sender, EventArgs e)
        {
            BtnGenerarPDF.Visible = false;
            ControlMensajes.Visible = false;

            if (string.IsNullOrEmpty(NumeroNoticia.Text) || !int.TryParse(NumeroNoticia.Text, out _))
            {
                ControlMensajes.MostrarMensaje(true, "Ingrese un número de noticia valido!");
                return;
            }

            var idNoticia = int.Parse(NumeroNoticia.Text);

            var mensajeError = new MensajeError();

            var noticia = NoticiaBL.BuscarNoticia(idNoticia, ref mensajeError, true);

            if (!mensajeError.ExisteError())
            {
                CargarNoticia(noticia);

                TituloNoticia.InnerText = $"Noticia #{NumeroNoticia.Text}";

                DivNoticia.Visible = true;
                BtnGenerarPDF.Visible = true;
            }
            else
            {
                ControlMensajes.MostrarMensaje(true, mensajeError.Mensaje);
            }
        }

        private void CargarNoticia(NoticiaUT noticia)
        {
            Div1.Visible = false;
            Div2.Visible = false;
            Div3.Visible = false;
            Div4.Visible = false;
            Div5.Visible = false;

            var mensajeError = new MensajeError();

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

            if (noticia.LobjImagenes != null && noticia.LobjImagenes.Count > 0)
            {
                foreach (var imagen in noticia.LobjImagenes)
                {
                    var imagenAsp = new Image()
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
                                    imagenAsp
                                }
                            }
                        }
                    });
                }

                Div5.Visible = true;
            }

            if (noticia.LobjPersonas != null && noticia.LobjPersonas.Count > 0)
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

                Div1.Visible = true;
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

                    TablaVehiculos.Rows.Add(tableRow);
                }

                Div2.Visible = true;
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

                Div3.Visible = true;
            }

            if (noticia.LobjPropiedades != null)
            {
                foreach (var propiedades in noticia.LobjPropiedades)
                {
                    var tableRow = new TableRow();
                    
                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = propiedades.LstrTipoPropiedad
                    });

                    tableRow.Cells.Add(new TableCell()
                    {
                        Text = propiedades.LstrLugar
                    });

                    TablaPropiedades.Rows.Add(tableRow);
                }

                Div4.Visible = true;
            }
        }

        protected void GenerarPDF_OnClick(object sender, EventArgs e)
        {
            BtnGenerarPDF.Visible = false;
            ControlMensajes.Visible = false;

            if (string.IsNullOrEmpty(NumeroNoticia.Text) || !int.TryParse(NumeroNoticia.Text, out _))
            {
                ControlMensajes.MostrarMensaje(true, "Ingrese un número de noticia valido!");
                return;
            }

            var idNoticia = int.Parse(NumeroNoticia.Text);

            var mensajeError = new MensajeError();

            var noticia = NoticiaBL.BuscarNoticia(idNoticia, ref mensajeError, true);

            var bytes = GenerarPdf.GenerarPdfNoticia(noticia);

            Response.Clear();
            Response.ContentType = "application/pdf";

            var pdfName = $"Reporte-Noticia-{noticia.LintId}";

            Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
            Response.ContentType = "application/pdf";
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(bytes);
            Response.End();
            Response.Close();
        }
    }    
}