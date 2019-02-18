using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class FuenteTest
    {
        [TestMethod]
        public void CRUDFuenteTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var fuente = CrearFuente();

            Assert.IsNotNull(fuente);

            var insertarResultado = FuenteDA.InsertarFuente(fuente, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(fuente.LstrNombreFuente, insertarResultado.LstrNombreFuente);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = FuenteDA.BuscarFuente(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombreFuente, buscarResultado.LstrNombreFuente);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = FuenteDA.BuscarTodosFuente(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombreFuente = "Nombre actualizado";

            var editarResultado = FuenteDA.EditarFuente(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombreFuente, editarResultado.LstrNombreFuente);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = FuenteDA.BorrarFuente(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private FuenteUT CrearFuente()
        {
            var mensajeError = new MensajeError();

            var fuente = new FuenteUT()
            {
                LstrNombreFuente = "Extra Noticias",
                LstrSubTitulo = "Titulo 1",
                LobjTipoFuente = TipoFuenteDA.BuscarTipoFuente(1,ref mensajeError)
            };

            return fuente;
        }
    }
}

