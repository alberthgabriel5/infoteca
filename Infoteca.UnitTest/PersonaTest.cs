using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void CRUDPersonaTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var persona = CrearPersona();

            Assert.IsNotNull(persona);

            var insertarResultado = PersonaDA.InsertarPersona(persona, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(persona.LstrCedula, insertarResultado.LstrCedula);
            Assert.AreEqual(persona.LstrNombre, insertarResultado.LstrNombre);
            Assert.AreEqual(persona.LstrApelido, insertarResultado.LstrApelido);
            Assert.AreEqual(persona.LstrAlias, insertarResultado.LstrAlias);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = PersonaDA.BuscarPersona(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrCedula, buscarResultado.LstrCedula);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = PersonaDA.BuscarTodosPersona(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombre = "OtroNombre";
            insertarResultado.LstrApelido = "OtroApellido";

            var editarResultado = PersonaDA.EditarPersona(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombre, editarResultado.LstrNombre);
            Assert.AreEqual(insertarResultado.LstrApelido, editarResultado.LstrApelido);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = PersonaDA.BorrarPersona(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private PersonaUT CrearPersona()
        {
            var persona = new PersonaUT()
            {
                LstrCedula = "33333",
                LstrNombre = "Alguien",
                LstrApelido = "Alguno",
                LstrAlias = "Algo"
            };

            return persona;
        }
    }
}


