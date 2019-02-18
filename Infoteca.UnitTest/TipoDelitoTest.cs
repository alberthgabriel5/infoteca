using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class TipoDelitoTest
    {
        [TestMethod]
        public void CRUDTipoDelitoTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var tipoDelito = CrearTipoDelito();

            Assert.IsNotNull(tipoDelito);

            var insertarResultado = TipoDelitoDA.InsertarTipoDelito(tipoDelito, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(tipoDelito.LstrNombre, insertarResultado.LstrNombre);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = TipoDelitoDA.BuscarTipoDelito(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, buscarResultado.LstrNombre);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = TipoDelitoDA.BuscarTodosTipoDelito(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombre = "Nombre actualizado";

            var editarResultado = TipoDelitoDA.EditarTipoDelito(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, editarResultado.LstrNombre);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = TipoDelitoDA.BorrarTipoDelito(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private TipoDelitoUT CrearTipoDelito()
        {
            var tipoDelito = new TipoDelitoUT()
            {
                LstrNombre = "Trafico de Drogas",
                FdtiFechaCreaccion = DateTime.Now
            };

            return tipoDelito;
        }
    } 
}
