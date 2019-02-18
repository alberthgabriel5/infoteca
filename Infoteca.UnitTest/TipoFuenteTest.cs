using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class TipoFuenteTest
    {
        [TestMethod]
        public void CRUDTipoFuenteTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var tipoFuente = CrearTipoFuente();

            Assert.IsNotNull(tipoFuente);

            var insertarResultado = TipoFuenteDA.InsertarTipoFuente(tipoFuente, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(tipoFuente.LstrNombre, insertarResultado.LstrNombre);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = TipoFuenteDA.BuscarTipoFuente(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, buscarResultado.LstrNombre);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = TipoFuenteDA.BuscarTodosTipoFuente(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombre = "Nombre actualizado";

            var editarResultado = TipoFuenteDA.EditarTipoFuente(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, editarResultado.LstrNombre);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = TipoFuenteDA.BorrarTipoFuente(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private TipoFuenteUT CrearTipoFuente()
        {
            var tipoFuente = new TipoFuenteUT()
            {
                LstrNombre = "Facebook de Extra Noticias",
                FdtiFechaCreaccion = DateTime.Now
            };

            return tipoFuente;
        }
    } 
}
