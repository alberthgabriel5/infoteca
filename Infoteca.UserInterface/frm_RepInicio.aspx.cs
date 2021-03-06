﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Globalization;
using System.Web.Script.Serialization;
using Infoteca.BizLayer;
using Infoteca.Utilitarios.Utiles;


namespace Infoteca.UserInterface
{
    public partial class frm_RepInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        [WebMethod]
        public static string CargarGraficoFuentes()
        {
            var mensajeError = new MensajeError();

            var fuentes = FuenteBL.BuscarTodosFuente(ref mensajeError);

            if (!mensajeError.ExisteError())
            {
                var nombreFuentes = new List<string>();
                var cantidadFuentes = new List<string>();

                foreach (var item in fuentes)
                {
                    nombreFuentes.Add(item.LstrNombreFuente);

                    var noticias = NoticiaBL.BuscarNoticiaPorFuente(item.LintID, ref mensajeError);

                    if (!mensajeError.ExisteError())
                    {
                        cantidadFuentes.Add(noticias.Count.ToString());
                    }
                    else
                    {
                        cantidadFuentes.Add("0");
                    }
                }

                var data = new
                {
                    labels = nombreFuentes.ToArray(),
                    datasets = new[] {
                        new
                        {
                            label = "Fuentes",
                            pointBorderColor = "#fff",
                            backgroundColor= new []{"#3e95cd", "#8e5ea2","#3cba9f","#e8c3b9","#c45850"},
                            data = cantidadFuentes.ToArray()
                        }
                    }
                };

                return data.ToJSON();
            }
            else
            {
                EscribirLog.LogMensajeError(mensajeError.Mensaje);
                return string.Empty;
            }

        }

        [WebMethod]
        public static string CargarGraficoNoticias()
        {
            var mensajeError = new MensajeError();

            var noticias = NoticiaBL.BuscarTodasLasNoticias(ref mensajeError);

            var nombreMeses = new List<string>();
            var cantidadNoticas = new List<string>();

            var seisMesesAtras = DateTime.Today.AddMonths(-12);

            noticias = noticias.Where(x => x.LdtiFecha >= seisMesesAtras).ToList(); ;

            noticias = noticias.OrderBy(e => e.LdtiFecha).ThenBy(e => e.LdtiFecha).ToList();

            var noticasAgrupadas = noticias.GroupBy(x => new {Month = x.LdtiFecha.Month, Year = x.LdtiFecha.Year})
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var item in noticasAgrupadas)
            {
                nombreMeses.Add($"{FirstCharToUpper(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month))}");

                cantidadNoticas.Add(item.Value.ToString());
            }

            var data = new
            {
                labels = nombreMeses.ToArray(),
                datasets = new[] {
                    new
                    {
                        label = "Noticias",
                        borderColor= "#3e12cd",
                        fill= false,
                        data = cantidadNoticas.ToArray()
                    }
                }
            };

            return data.ToJSON();
        }

        [WebMethod]
        public static string CargarGraficoBusquedas()
        {
            var mensajeError = new MensajeError();

            var busquedas = BitacoraBL.BuscarTodosBitacora(ref mensajeError);

            var nombreMeses = new List<string>();
            var cantidadBusquedas = new List<string>();

            var seisMesesAtras = DateTime.Today.AddMonths(-12);

            busquedas = busquedas.Where(x => x.TD_Modificado >= seisMesesAtras).ToList(); ;

            busquedas = busquedas.OrderBy(e => e.TD_Modificado).ThenBy(e => e.TD_Modificado).ToList();

            var busquedasAgrupadas = busquedas.GroupBy(x => new { Month = x.TD_Modificado.Month, Year = x.TD_Modificado.Year })
                .ToDictionary(g => g.Key, g => g.Count());

            foreach (var item in busquedasAgrupadas)
            {
                nombreMeses.Add($"{FirstCharToUpper(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key.Month))}");

                cantidadBusquedas.Add(item.Value.ToString());
            }

            var data = new
            {
                labels = nombreMeses.ToArray(),
                datasets = new[] {
                    new
                    {
                        label = "Busquedas",
                        borderColor= "#3e12cd",
                        fill= false,
                        data = cantidadBusquedas.ToArray()
                    }
                }
            };

            return data.ToJSON();
        }

        [WebMethod]
        public static string CargarGraficoTiposDelito()
        {
            var mensajeError = new MensajeError();

            var tiposDelito = TipoDelitoBL.BuscarTodosTipoDelito(ref mensajeError);

            var nombres = new List<string>();
            var cantidad = new List<string>();

            foreach (var item in tiposDelito)
            {
                nombres.Add(item.LstrNombre);

                var noticias = NoticiaBL.BuscarNoticiaPorTipoDelito(item.LintID, ref mensajeError);

                if (!mensajeError.ExisteError())
                {
                    cantidad.Add(noticias.Count.ToString());
                }
                else
                {
                    cantidad.Add("0");
                }
            }

            var data = new
            {
                labels = nombres.ToArray(),
                datasets = new[] {
                    new
                    {
                        label = "Tipos Delito",
                        fill= false,
                        data = cantidad.ToArray(),
                        backgroundColor = new[] {"#3e95cd", "#8e5ea2","#3cba9f","#e8c3b9","#c45850"}
                    }
                }
            };

            return data.ToJSON();
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }

    public static class JSONHelper
    {
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(obj);
        }

        public static string ToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }
    }
}