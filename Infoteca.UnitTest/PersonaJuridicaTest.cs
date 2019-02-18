using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class PersonaJuridicaTest
    {
        [TestMethod]
        public void CRUDPersonaJuridicaTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();

            var personaJuridica = CrearPersonaJuridica();

            Assert.IsNotNull(personaJuridica);

            var insertarResultado = PersonaJuridicaDA.InsertarPersonaJuridica(personaJuridica, ref mensajeError);

            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(insertarResultado);
            Assert.IsNotNull(insertarResultado.LintID);
            Assert.AreEqual(personaJuridica.LstrNombreJuridico, insertarResultado.LstrNombreJuridico);

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarResultado = PersonaJuridicaDA.BuscarPersonaJuridica(insertarResultado.LintID, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsNotNull(buscarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombrePublico, buscarResultado.LstrNombrePublico);

            /***************
             * 
             * Buscar Todos
             * 
            ***************/

            mensajeError = new MensajeError();
            var buscarTodosResultado = PersonaJuridicaDA.BuscarTodosPersonaJuridica(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsNotNull(buscarTodosResultado.Count > 0);

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrNombreJuridico = "Nombre actualizado";

            var editarResultado = PersonaJuridicaDA.EditarPersonaJuridica(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsNotNull(editarResultado.LintID);
            Assert.AreEqual(insertarResultado.LstrNombreJuridico, editarResultado.LstrNombreJuridico);

            /***************
             * 
             * Borrar
             * 
            ***************/

            mensajeError = new MensajeError();
            var borrarResultado = PersonaJuridicaDA.BorrarPersonaJuridica(insertarResultado.LintID, ref mensajeError);

            Assert.IsTrue(borrarResultado);
        }

        private PersonaJuridicaUT CrearPersonaJuridica()
        {
            var personaJuridica = new PersonaJuridicaUT()
            {
                LstrNombreJuridico = "Ejemplo S.A"
                
            };

            return personaJuridica;
        }
    } 
}
