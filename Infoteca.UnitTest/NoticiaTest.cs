using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infoteca.DataAccess.TRAN;
using Infoteca.Utilitarios.Objetos;
using Infoteca.Utilitarios.Utiles;

namespace Infoteca.UnitTest
{
    [TestClass]
    public class NoticiaTest
    {
        [TestMethod]
        public void CRUDNoticiaTest()
        {
            Assert.IsTrue(true);

            /***************
             * 
             * Insertar
             * 
            ***************/

            var mensajeError = new MensajeError();
            var noticia = CrearNoticia(ref mensajeError);

            Assert.IsNotNull(noticia);


            var insertarResultado = NoticiaDA.InsertarNoticia(noticia, ref mensajeError);

            Assert.IsNotNull(insertarResultado);
            Assert.IsFalse(mensajeError.ExisteError());

            /***************
             * 
             * Buscar
             * 
            ***************/

            mensajeError = new MensajeError();

            var buscarResultado = NoticiaDA.BuscarNoticia(insertarResultado.LintId, ref mensajeError);

            Assert.IsNotNull(buscarResultado);
            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(buscarResultado.LintId);
            Assert.AreEqual(noticia.LstrDescripcion, buscarResultado.LstrDescripcion);

            /***************
             * 
             * Buscar todos
             * 
            ***************/

            var buscarTodosResultado = NoticiaDA.BuscarNoticiasActivas(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsFalse(mensajeError.ExisteError());

            /***************
             * 
             * Editar
             * 
            ***************/

            mensajeError = new MensajeError();
            insertarResultado.LstrDescripcion = "Descripcion actualizada";

            var editarResultado = NoticiaDA.EditarNoticia(insertarResultado, ref mensajeError);

            Assert.IsNotNull(editarResultado);
            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(editarResultado.LintId);
            Assert.AreEqual(insertarResultado.LstrDescripcion, editarResultado.LstrDescripcion);

            /***************
             * 
             * Agregar objetos a la noticia
             * 
            ***************/

            var persona = CrearPersona("Alejandro", ref mensajeError);

            editarResultado = NoticiaDA.AgregarObjetoNoticia(
                editarResultado.LintId, 
                persona.LintID, 
                Tipo.PERSONA,
                ref mensajeError);                                      

            Assert.IsNotNull(editarResultado);
            Assert.IsFalse(mensajeError.ExisteError());
            Assert.IsNotNull(editarResultado.LintId);
            Assert.IsNotNull(editarResultado.LobjPersonas.Find(x=>x.LintID==persona.LintID));

            /***************
             * 
             * Borrar objetos de la noticia
             * 
            ***************/

            editarResultado = NoticiaDA.BorrarObjetoNoticia(
                editarResultado.LintId,
                persona.LintID,
                Tipo.PERSONA,
                ref mensajeError);
            mensajeError = new MensajeError();
            try
            {
                Assert.IsNotNull(editarResultado);
                Assert.IsFalse(mensajeError.ExisteError());
                Assert.IsNotNull(editarResultado.LintId);
                Assert.IsNull(editarResultado.LobjPersonas.Find(x => x.LintID == persona.LintID));
            }catch(System.NullReferenceException e)
            {
                mensajeError.Mensaje = e.Message;
            }
            /***************
             * 
             * Borrar
             * 
            ***************/

            
            var borrarResultado = NoticiaDA.BorrarNoticia(insertarResultado.LintId, ref mensajeError);

            Assert.IsTrue(borrarResultado);
            Assert.IsFalse(mensajeError.ExisteError());



            /***************
             * 
             * Verificar borrado logico
             * 
            ***************/

            buscarTodosResultado = NoticiaDA.BuscarNoticiasActivas(ref mensajeError);

            Assert.IsNotNull(buscarTodosResultado);
            Assert.IsFalse(mensajeError.ExisteError());
        }





        private NoticiaUT CrearNoticia(ref MensajeError mensajeError)
        {
            var noticia = new NoticiaUT()
            {
                LstrPalabraClave = "Robo",
                LstrSubDelito = "Asalto a mano armada",
                LstrDescripcion = "Robo a local",
                LintIdTipoDelito = 1,
                LintIdFuente = 1,
                LdtiFecha = DateTime.Now
            };

            return noticia;
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

        private PersonaUT CrearPersona(string nombre,ref MensajeError mensajeError)
        {
            var persona = new PersonaUT()
            {
                LstrCedula = "11111",
                LstrNombre = nombre,
                LstrApelido = "Apellido",
                LstrAlias = "alias"
            };
            return PersonaDA.InsertarPersona(persona, ref mensajeError);
        }

        private VehiculoUT CrearVehiculo(string placa, ref MensajeError mensajeError)
        {
            var vehiculo = new VehiculoUT()
            {
                LstrColor="",
                LstrEstilo="",
                LstrMarca="",
                LstrModelo="",
                LstrPlaca=placa
            };
            return VehiculoDA.InsertarVehiculo(vehiculo, ref mensajeError);
        }

        private PersonaJuridicaUT CrearJuridico(string nombre, ref MensajeError mensajeError)
        {
            var juridico = new PersonaJuridicaUT()
            {
                LstrCedulaJuridica="",
                LstrNombreJuridico=nombre,
                LstrNombrePublico=""
            };
            return PersonaJuridicaDA.InsertarPersonaJuridica(juridico, ref mensajeError);
        }

        private PropiedadUT CrearPropiedad(string lugar, ref MensajeError mensajeError)
        {
            var propiedad = new PropiedadUT()
            {
                LstrTipoPropiedad = "Lote",
                LstrLugar = lugar
            };
            return PropiedadDA.InsertarPropiedad(propiedad, ref mensajeError);
        }

    } // CRUDNoticiaTest
}

