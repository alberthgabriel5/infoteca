using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void CRUDVehiculoTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var vehiculo = CrearVehiculo();

            Assert.IsNotNull(vehiculo);

            var insertarResultado = VehiculoDA.InsertarVehiculo(vehiculo, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(vehiculo.LstrPlaca, insertarResultado.LstrPlaca);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = VehiculoDA.BuscarVehiculo(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrPlaca, buscarResultado.LstrPlaca);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = VehiculoDA.BuscarTodosVehiculo(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrPlaca = "Nombre actualizado";

            var editarResultado = VehiculoDA.EditarVehiculo(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrPlaca, editarResultado.LstrPlaca);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = VehiculoDA.BorrarVehiculo(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private VehiculoUT CrearVehiculo()
        {
            var vehiculo = new VehiculoUT()
            {
                LstrPlaca = "Trafico de Drogas"
            };

            return vehiculo;
        }
    } 
}
