using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Infoteca.Utilitarios.Objetos;
using Microsoft.AspNet.Identity;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;

namespace Infoteca.UserInterface.utils
{
    public static class GenerarPdf
    {
        public static byte[] GenerarPdfNoticia(NoticiaUT noticia)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {

                var document = new Document(PageSize.A4, 30, 20, 10, 10);

                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var pic = Image.GetInstance($"{HttpContext.Current.Server.MapPath("~")}\\images\\poder-judicial-logo.png");

                pic.ScalePercent(20);
                pic.Alignment = Element.ALIGN_CENTER;

                document.Add(pic);

                document.Add(new Paragraph("Reporte de Noticia", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f, BaseColor.BLACK))
                {
                    Alignment = Element.ALIGN_CENTER
                });

                AgregarLineaAlPdf(document, "Número Noticia: ", noticia.LintId.ToString());
                AgregarLineaAlPdf(document, "Descripción: ", noticia.LstrDescripcion);
                AgregarLineaAlPdf(document, "Sub-delito: ", noticia.LstrSubDelito);
                AgregarLineaAlPdf(document, "Fecha del Evento: ", noticia.LdtiFecha.ToString("d"));
                AgregarLineaAlPdf(document, "Palabras Clave: ", noticia.LstrPalabraClave);
                AgregarLineaAlPdf(document, "Fecha de generación: ", DateTime.Now.ToString("d"));
                AgregarLineaAlPdf(document, "Usuario: ", HttpContext.Current.User.Identity.GetUserName());

                if (noticia.LobjPersonas != null && noticia.LobjPersonas.Count > 0)
                {
                    document.Add(new Paragraph("Personas vinculadas", FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaPersonas = new PdfPTable(5)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 500f,
                        LockedWidth = true
                    };

                    tablaPersonas.SetWidths(new[] { 50f, 30f, 50f, 50f, 50f });

                    AddCell(tablaPersonas, "Tipo Identificación", 1, true);
                    AddCell(tablaPersonas, "Identificación", 1, true);
                    AddCell(tablaPersonas, "Nombre", 1, true);
                    AddCell(tablaPersonas, "Apellidos", 1, true);
                    AddCell(tablaPersonas, "Alias.", 1, true);

                    foreach (var noticiaLobjPersona in noticia.LobjPersonas)
                    {
                        AddCell(tablaPersonas, noticiaLobjPersona.LstrTipoIdentificacion, 1);
                        AddCell(tablaPersonas, noticiaLobjPersona.LstrCedula, 1);
                        AddCell(tablaPersonas, noticiaLobjPersona.LstrNombre, 1);
                        AddCell(tablaPersonas, noticiaLobjPersona.LstrApelido, 1);
                        AddCell(tablaPersonas, noticiaLobjPersona.LstrAlias, 1);
                    }

                    document.Add(tablaPersonas);
                }

                if (noticia.LobjVehiculos != null && noticia.LobjVehiculos.Count > 0)
                {

                    document.Add(new Paragraph("Vehiculos vinculados",
                        FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaVehiculos = new PdfPTable(5)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 500f,
                        LockedWidth = true
                    };

                    tablaVehiculos.SetWidths(new[] { 50f, 30f, 50f, 50f, 50f });

                    AddCell(tablaVehiculos, "Placa", 1, true);
                    AddCell(tablaVehiculos, "Estilo", 1, true);
                    AddCell(tablaVehiculos, "Marca", 1, true);
                    AddCell(tablaVehiculos, "Modelo", 1, true);
                    AddCell(tablaVehiculos, "Color.", 1, true);

                    foreach (var noticiaLobjVehiculo in noticia.LobjVehiculos)
                    {
                        AddCell(tablaVehiculos, noticiaLobjVehiculo.LstrPlaca, 1);
                        AddCell(tablaVehiculos, noticiaLobjVehiculo.LstrEstilo, 1);
                        AddCell(tablaVehiculos, noticiaLobjVehiculo.LstrMarca, 1);
                        AddCell(tablaVehiculos, noticiaLobjVehiculo.LstrModelo, 1);
                        AddCell(tablaVehiculos, noticiaLobjVehiculo.LstrColor, 1);
                    }

                    document.Add(tablaVehiculos);
                }

                if (noticia.LobjPersonaJuridicas != null && noticia.LobjPersonaJuridicas.Count > 0)
                {

                    document.Add(new Paragraph("Personas Juridicas vinculadas",
                        FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaPersonaJuridicas = new PdfPTable(3)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 500f,
                        LockedWidth = true
                    };

                    tablaPersonaJuridicas.SetWidths(new[] { 50f, 30f, 50f });

                    AddCell(tablaPersonaJuridicas, "Cédula Juridica", 1, true);
                    AddCell(tablaPersonaJuridicas, "Nombre Juridico", 1, true);
                    AddCell(tablaPersonaJuridicas, "Nombre Publico", 1, true);

                    foreach (var noticiaLobjPersonaJuridica in noticia.LobjPersonaJuridicas)
                    {
                        AddCell(tablaPersonaJuridicas, noticiaLobjPersonaJuridica.LstrCedulaJuridica, 1);
                        AddCell(tablaPersonaJuridicas, noticiaLobjPersonaJuridica.LstrNombreJuridico, 1);
                        AddCell(tablaPersonaJuridicas, noticiaLobjPersonaJuridica.LstrNombrePublico, 1);
                    }

                    document.Add(tablaPersonaJuridicas);
                }

                if (noticia.LobjPropiedades != null && noticia.LobjPropiedades.Count > 0)
                {

                    document.Add(new Paragraph("Propiedades vinculadas",
                        FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaPropiedades = new PdfPTable(2)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 500f,
                        LockedWidth = true
                    };

                    tablaPropiedades.SetWidths(new[] { 50f, 50f });

                    AddCell(tablaPropiedades, "Tipo Propiedad", 1, true);
                    AddCell(tablaPropiedades, "Ubicación", 1, true);

                    foreach (var noticiaLobjPropiedades in noticia.LobjPropiedades)
                    {
                        AddCell(tablaPropiedades, noticiaLobjPropiedades.LstrTipoPropiedad, 1);
                        AddCell(tablaPropiedades, noticiaLobjPropiedades.LstrLugar, 1);
                    }

                    document.Add(tablaPropiedades);
                }

                if (noticia.LobjImagenes != null && noticia.LobjImagenes.Count > 0)
                {

                    document.Add(new Paragraph("Imagenes registradas",
                        FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    foreach (var noticiaLobjImagen in noticia.LobjImagenes)
                    {
                        var picTemp = Image.GetInstance(noticiaLobjImagen.LByteImagen);

                        if (picTemp.Height > picTemp.Width)
                        {
                            //Maximum height is 600 pixels.
                            var percentage = 0.0f;
                            percentage = 600 / picTemp.Height;
                            picTemp.ScalePercent(percentage * 100);
                        }
                        else
                        {
                            //Maximum width is 600 pixels.
                            var percentage = 0.0f;
                            percentage = 540 / picTemp.Width;
                            picTemp.ScalePercent(percentage * 100);
                        }

                        picTemp.Alignment = Element.ALIGN_CENTER;

                        document.Add(picTemp);
                    }
                }

                document.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();

                return bytes;
            }
        }

        public static byte[] GenerarPdfListaDeNoticias(List<NoticiaGridView> noticias, string rango)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {

                var document = new Document(PageSize.A4, 30, 20, 10, 10);

                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var pic = Image.GetInstance($"{HttpContext.Current.Server.MapPath("~")}\\images\\poder-judicial-logo.png");

                pic.ScalePercent(20);
                pic.Alignment = Element.ALIGN_CENTER;

                document.Add(pic);

                document.Add(new Paragraph("Reporte de noticias por rango de fechas", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f, BaseColor.BLACK))
                {
                    Alignment = Element.ALIGN_CENTER
                });

                AgregarLineaAlPdf(document, "Cantidad de registros: ", noticias.Count.ToString());
                AgregarLineaAlPdf(document, "Rango de fechas: ", rango);
                AgregarLineaAlPdf(document, "Fecha de generación: ", DateTime.Now.ToString("d"));
                AgregarLineaAlPdf(document, "Usuario: ", HttpContext.Current.User.Identity.GetUserName());

                if (noticias.Count > 0)
                {
                    document.Add(new Paragraph("Noticias registradas", FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaNoticias = new PdfPTable(12)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 550f,
                        LockedWidth = true
                    };

                    tablaNoticias.SetWidths(new[] { 20f, 50f, 150f, 45f, 120f, 40f, 40f, 45f, 45f, 45f, 45f, 45f });

                    AddCell(tablaNoticias, "Id", 1, true);
                    AddCell(tablaNoticias, "Fecha del\nevento/delito", 1, true);
                    AddCell(tablaNoticias, "Descripción", 1, true);
                    AddCell(tablaNoticias, "SubDelito", 1, true);
                    AddCell(tablaNoticias, "Palabras Clave", 1, true);
                    AddCell(tablaNoticias, "Tipo\nDelito", 1, true);
                    AddCell(tablaNoticias, "Fuente", 1, true);
                    AddCell(tablaNoticias, "Imagenes", 1, true);
                    AddCell(tablaNoticias, "Personas", 1, true);
                    AddCell(tablaNoticias, "Persona\nJuridicas", 1, true);
                    AddCell(tablaNoticias, "Vehiculos", 1, true);
                    AddCell(tablaNoticias, "Propiedades", 1, true);

                    foreach (var noticia in noticias)
                    {
                        AddCell(tablaNoticias, noticia.LintId.ToString(), 1);
                        AddCell(tablaNoticias, noticia.LdtiFecha, 1);
                        AddCell(tablaNoticias, noticia.LstrDescripcion, 1);
                        AddCell(tablaNoticias, noticia.LstrSubDelito, 1);
                        AddCell(tablaNoticias, noticia.LstrPalabraClave, 1);
                        AddCell(tablaNoticias, noticia.LintIdTipoDelito, 1);
                        AddCell(tablaNoticias, noticia.LintIdFuente, 1);
                        AddCell(tablaNoticias, noticia.LobjImagenes, 1);
                        AddCell(tablaNoticias, noticia.LobjPersonas, 1);
                        AddCell(tablaNoticias, noticia.LobjPersonaJuridicas, 1);
                        AddCell(tablaNoticias, noticia.LobjVehiculos, 1);
                        AddCell(tablaNoticias, noticia.LobjPropiedades, 1);
                    }

                    document.Add(tablaNoticias);
                }

                document.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();

                return bytes;
            }
        }

        public static byte[] GenerarPdfEstado(Bitmap estado, Bitmap estado2)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {

                var document = new Document(PageSize.A4, 30, 20, 10, 10);

                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var pic = Image.GetInstance($"{HttpContext.Current.Server.MapPath("~")}\\images\\poder-judicial-logo.png");

                pic.ScalePercent(20);
                pic.Alignment = Element.ALIGN_CENTER;

                document.Add(pic);

                document.Add(new Paragraph("Reporte de estado del sistema", FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f, BaseColor.BLACK))
                {
                    Alignment = Element.ALIGN_CENTER
                });

                AgregarLineaAlPdf(document, "Fecha de generación: ", DateTime.Now.ToString("d"));
                AgregarLineaAlPdf(document, "Usuario: ", HttpContext.Current.User.Identity.GetUserName());

                var pic2 = Image.GetInstance(estado, System.Drawing.Imaging.ImageFormat.Jpeg);

                if (pic2.Height > pic2.Width)
                {
                    //Maximum height is 600 pixels.
                    var percentage = 0.0f;
                    percentage = 600 / pic2.Height;
                    pic2.ScalePercent(percentage * 100);
                }
                else
                {
                    //Maximum width is 600 pixels.
                    var percentage = 0.0f;
                    percentage = 540 / pic2.Width;
                    pic2.ScalePercent(percentage * 100);
                }

                pic2.Alignment = Element.ALIGN_CENTER;

                document.Add(pic2);

                var pic3 = Image.GetInstance(estado2, System.Drawing.Imaging.ImageFormat.Jpeg);

                if (pic3.Height > pic2.Width)
                {
                    //Maximum height is 600 pixels.
                    var percentage = 0.0f;
                    percentage = 600 / pic3.Height;
                    pic3.ScalePercent(percentage * 100);
                }
                else
                {
                    //Maximum width is 600 pixels.
                    var percentage = 0.0f;
                    percentage = 540 / pic3.Width;
                    pic3.ScalePercent(percentage * 100);
                }

                pic3.Alignment = Element.ALIGN_CENTER;

                document.Add(pic3);

                document.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();

                return bytes;
            }
        }

        public static byte[] GenerarPdfListaDeNoticiasPorTipo(List<NoticiaGridView> noticias, string titulo)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {

                var document = new Document(PageSize.A4, 30, 20, 10, 10);

                var writer = PdfWriter.GetInstance(document, memoryStream);

                document.Open();

                var pic = Image.GetInstance($"{HttpContext.Current.Server.MapPath("~")}\\images\\poder-judicial-logo.png");

                pic.ScalePercent(20);
                pic.Alignment = Element.ALIGN_CENTER;

                document.Add(pic);

                document.Add(new Paragraph(titulo, FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f, BaseColor.BLACK))
                {
                    Alignment = Element.ALIGN_CENTER
                });

                AgregarLineaAlPdf(document, "Cantidad de registros: ", noticias.Count.ToString());
                AgregarLineaAlPdf(document, "Fecha de generación: ", DateTime.Now.ToString("d"));
                AgregarLineaAlPdf(document, "Usuario: ", HttpContext.Current.User.Identity.GetUserName());

                if (noticias.Count > 0)
                {
                    document.Add(new Paragraph("Noticias registradas", FontFactory.GetFont(FontFactory.TIMES_BOLD, 14f, BaseColor.BLACK))
                    {
                        Alignment = Element.ALIGN_CENTER,
                        SpacingAfter = 10
                    });

                    var tablaNoticias = new PdfPTable(12)
                    {
                        HorizontalAlignment = 0,
                        TotalWidth = 550f,
                        LockedWidth = true
                    };

                    tablaNoticias.SetWidths(new[] { 20f, 50f, 150f, 45f, 120f, 40f, 40f, 45f, 45f, 45f, 45f, 45f });

                    AddCell(tablaNoticias, "Id", 1, true);
                    AddCell(tablaNoticias, "Fecha del\nevento/delito", 1, true);
                    AddCell(tablaNoticias, "Descripción", 1, true);
                    AddCell(tablaNoticias, "SubDelito", 1, true);
                    AddCell(tablaNoticias, "Palabras Clave", 1, true);
                    AddCell(tablaNoticias, "Tipo\nDelito", 1, true);
                    AddCell(tablaNoticias, "Fuente", 1, true);
                    AddCell(tablaNoticias, "Imagenes", 1, true);
                    AddCell(tablaNoticias, "Personas", 1, true);
                    AddCell(tablaNoticias, "Persona\nJuridicas", 1, true);
                    AddCell(tablaNoticias, "Vehiculos", 1, true);
                    AddCell(tablaNoticias, "Propiedades", 1, true);

                    foreach (var noticia in noticias)
                    {
                        AddCell(tablaNoticias, noticia.LintId.ToString(), 1);
                        AddCell(tablaNoticias, noticia.LdtiFecha, 1);
                        AddCell(tablaNoticias, noticia.LstrDescripcion, 1);
                        AddCell(tablaNoticias, noticia.LstrSubDelito, 1);
                        AddCell(tablaNoticias, noticia.LstrPalabraClave, 1);
                        AddCell(tablaNoticias, noticia.LintIdTipoDelito, 1);
                        AddCell(tablaNoticias, noticia.LintIdFuente, 1);
                        AddCell(tablaNoticias, noticia.LobjImagenes, 1);
                        AddCell(tablaNoticias, noticia.LobjPersonas, 1);
                        AddCell(tablaNoticias, noticia.LobjPersonaJuridicas, 1);
                        AddCell(tablaNoticias, noticia.LobjVehiculos, 1);
                        AddCell(tablaNoticias, noticia.LobjPropiedades, 1);
                    }

                    document.Add(tablaNoticias);
                }

                document.Close();
                var bytes = memoryStream.ToArray();
                memoryStream.Close();

                return bytes;
            }
        }

        private static void AgregarLineaAlPdf(Document document, string titulo, string valor)
        {
            var chunk = new Chunk(titulo, FontFactory.GetFont(FontFactory.TIMES_BOLD, 12f, BaseColor.BLACK));
            document.Add(chunk);

            var phrase = new Phrase(valor);
            document.Add(phrase);

            document.Add(new Chunk("\n"));
        }

        private static void AddCell(PdfPTable table, string text, int rowspan, bool bold = false)
        {
            var bfTimes = bold ? BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false) : BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            var times = new Font(bfTimes, 6, Font.NORMAL, BaseColor.BLACK);

            var cell = new PdfPCell(new Phrase(text, times))
            {
                Rowspan = rowspan,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            table.AddCell(cell);
        }
    }
}