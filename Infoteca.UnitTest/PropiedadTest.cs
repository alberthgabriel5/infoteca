using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class PropiedadTest
    {
        [TestMethod]
        public void CRUDPropiedadTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var propiedad = CrearPropiedad();

            Assert.IsNotNull(propiedad);

            var insertarResultado = PropiedadDA.InsertarPropiedad(propiedad, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(propiedad.LstrLugar, insertarResultado.LstrLugar);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = PropiedadDA.BuscarPropiedad(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrLugar, buscarResultado.LstrLugar);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = PropiedadDA.BuscarTodosPropiedad(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrLugar = "Lugar actualizado";

            var editarResultado = PropiedadDA.EditarPropiedad(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrLugar, editarResultado.LstrLugar);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = PropiedadDA.BorrarPropiedad(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private PropiedadUT CrearPropiedad()
        {
            var propiedad = new PropiedadUT()
            {
                LstrLugar = "Algun lugar de La Mancha",
                LstrTipoPropiedad = "Lote"
            };

            return propiedad;
        }
    }
}

