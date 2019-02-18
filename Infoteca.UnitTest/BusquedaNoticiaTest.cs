using System;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Utiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class BusquedaNoticiaTest
    {

        [TestMethod]
        public void BusquedaNoticia()
        {

            Assert.IsTrue(true);
            var mensajeError = new MensajeError();

            /***************
             * 
             * Busqueda por Fechas
             * 
            ***************/

            var buscarFechasResultado = NoticiaDA.BuscarPorFechaNoticia(new DateTime(2018, 01, 01), new DateTime(2019, 01, 01),"", ref mensajeError);

            Assert.IsNotNull(buscarFechasResultado);
            Assert.IsFalse(mensajeError.ExisteError());

            /***************
             * 
             * Busqueda por Palabras clave
             * 
            ***************/

            var buscarPalabraClaveResultado = NoticiaDA.BuscarPorPalabraClave("o o.o, o","", ref mensajeError);

            Assert.IsNotNull(buscarPalabraClaveResultado);
            Assert.IsFalse(mensajeError.ExisteError());


        }
    }
}
