using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;
using System.IO;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class ImagenTest
    {
        [TestMethod]
        public void CRUDImagenTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var imagen = CrearImagen();

            Assert.IsNotNull(imagen);

            var insertarResultado = ImagenDA.InsertarImagen(imagen, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(imagen.LstrNombre, insertarResultado.LstrNombre);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = ImagenDA.BuscarImagen(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, buscarResultado.LstrNombre);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = ImagenDA.BuscarTodosImagen(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombre = "Nombre actualizado";

            var editarResultado = ImagenDA.EditarImagen(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, editarResultado.LstrNombre);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = ImagenDA.BorrarImagen(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private ImagenUT CrearImagen()
        {
            var imagen = new ImagenUT()
            {
                LstrNombre = "prueba.jpg",
                FdtiFechaCreaccion = DateTime.Now,
                LByteImagen = File.ReadAllBytes("ArchivosPrueba/prueba.jpg")
        };

            return imagen;
        }
    } 
}
