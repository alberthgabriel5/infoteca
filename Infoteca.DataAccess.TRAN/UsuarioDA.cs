using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Infoteca.Utilitarios.Objetos;

namespace Infoteca.DataAccess.TRAN
{
    public class UsuarioDA
    {
        private String connString;

        public UsuarioDA(string connString)
        {
            this.connString = connString;
        }

        public bool lfaddnewusr(UsuarioUT lobjUsuario)
        {
            SqlConnection cnn = new SqlConnection(this.connString);
            String lstrProcedimiento = "pa_insertar_usuario";
            SqlCommand cmd = new SqlCommand(lstrProcedimiento, cnn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id_usuario", lobjUsuario.LintID));
            cmd.Parameters.Add(new SqlParameter("@usuario_usuario", lobjUsuario.LstrUsuario));
            cmd.Parameters.Add(new SqlParameter("@identificacion_usuario", lobjUsuario.LstrIdentificacion));
            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", lobjUsuario.LstrNombre));
            cmd.Parameters.Add(new SqlParameter("@primer_apellido_usuario", lobjUsuario.LstrPrimerApellido));
            cmd.Parameters.Add(new SqlParameter("@segundo_Apellido_usuario", lobjUsuario.LstrSegundoApellido));
            cmd.Parameters.Add(new SqlParameter("@tipo_autentificacion_usuario", lobjUsuario.LstrTipoAutentificacion));
            cmd.Parameters.Add(new SqlParameter("@tipo_usuario", lobjUsuario.LstrTipoUsuario));
            cmd.Parameters.Add(new SqlParameter("@email_usuario", lobjUsuario.LstrEmail));
            cmd.Parameters.Add(new SqlParameter("@intentos_acceso_usuario", lobjUsuario.LintIntentosAcceso));
            cmd.Parameters.Add(new SqlParameter("@actuliza_usuario", lobjUsuario.LstrUsuarioActualiza));
            cmd.Parameters.Add(new SqlParameter("@fec_actualiza_usuario", lobjUsuario.LdtiFechaActualiza));
            cmd.Parameters.Add(new SqlParameter("@observaciones_usuario", lobjUsuario.LstrObservaciones));
            cmd.Parameters.Add(new SqlParameter("@eliminado_usuario", lobjUsuario.LbytEliminado));
            cmd.Parameters.Add(new SqlParameter("@tipo_identificacion_usuario", lobjUsuario.LstrTipoIdentificacionID));
            cmd.Parameters.Add(new SqlParameter("@institucion_usuario", lobjUsuario.LstrInstitucionID));
            cmd.Parameters.Add(new SqlParameter("@oficina_usuario", lobjUsuario.LstrOficinaID));
            cmd.Parameters.Add(new SqlParameter("@activo_usuario", lobjUsuario.LbytActivo));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool actualizar(UsuarioUT lobjUsuario)
        {
            SqlConnection conexion = new SqlConnection(this.connString);
            String procedimiento = "pa_actualizar_usuario";
            SqlCommand cmd = new SqlCommand(procedimiento, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id_usuario", lobjUsuario.LintID));
            cmd.Parameters.Add(new SqlParameter("@usuario_usuario", lobjUsuario.LstrUsuario));
            cmd.Parameters.Add(new SqlParameter("@identificacion_usuario", lobjUsuario.LstrIdentificacion));
            cmd.Parameters.Add(new SqlParameter("@nombre_usuario", lobjUsuario.LstrNombre));
            cmd.Parameters.Add(new SqlParameter("@primer_apellido_usuario", lobjUsuario.LstrPrimerApellido));
            cmd.Parameters.Add(new SqlParameter("@segundo_Apellido_usuario", lobjUsuario.LstrSegundoApellido));
            cmd.Parameters.Add(new SqlParameter("@tipo_autentificacion_usuario", lobjUsuario.LstrTipoAutentificacion));
            cmd.Parameters.Add(new SqlParameter("@tipo_usuario", lobjUsuario.LstrTipoUsuario));
            cmd.Parameters.Add(new SqlParameter("@email_usuario", lobjUsuario.LstrEmail));
            cmd.Parameters.Add(new SqlParameter("@intentos_acceso_usuario", lobjUsuario.LintIntentosAcceso));
            cmd.Parameters.Add(new SqlParameter("@actuliza_usuario", lobjUsuario.LstrUsuarioActualiza));
            cmd.Parameters.Add(new SqlParameter("@fec_actualiza_usuario", lobjUsuario.LdtiFechaActualiza));
            cmd.Parameters.Add(new SqlParameter("@observaciones_usuario", lobjUsuario.LstrObservaciones));
            cmd.Parameters.Add(new SqlParameter("@eliminado_usuario", lobjUsuario.LbytEliminado));
            cmd.Parameters.Add(new SqlParameter("@tipo_identificacion_usuario", lobjUsuario.LstrTipoIdentificacionID));
            cmd.Parameters.Add(new SqlParameter("@institucion_usuario", lobjUsuario.LstrInstitucionID));
            cmd.Parameters.Add(new SqlParameter("@oficina_usuario", lobjUsuario.LstrOficinaID));
            cmd.Parameters.Add(new SqlParameter("@activo_usuario", lobjUsuario.LbytActivo));

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        } // actualizar
        public UsuarioUT lfBuscaUsuario(string id)
        {

            SqlConnection conexion = new SqlConnection(this.connString);
            String procedimiento = "pa_busca_usuario";
            SqlCommand cmd = new SqlCommand(procedimiento, conexion);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@id", id));

            UsuarioUT lobjUsuario = null;
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lobjUsuario = new UsuarioUT();
                    lobjUsuario.LintID = Convert.ToInt16(reader.GetValue(0).ToString());
                    lobjUsuario.LstrUsuario = reader.GetValue(1).ToString();
                    lobjUsuario.LstrIdentificacion = reader.GetValue(2).ToString();
                    lobjUsuario.LstrNombre = reader.GetValue(3).ToString();
                    lobjUsuario.LstrPrimerApellido = reader.GetValue(4).ToString();
                    lobjUsuario.LstrSegundoApellido = reader.GetValue(5).ToString();
                    lobjUsuario.LstrTipoAutentificacion = reader.GetValue(6).ToString();
                    lobjUsuario.LstrTipoUsuario = reader.GetValue(7).ToString();
                    lobjUsuario.LstrEmail = reader.GetValue(8).ToString();
                    lobjUsuario.LintIntentosAcceso = reader.GetValue(9).ToString();
                    lobjUsuario.LstrUsuarioActualiza = reader.GetValue(10).ToString();
                    lobjUsuario.LdtiFechaActualiza = Convert.ToDateTime(reader.GetValue(11).ToString());
                    lobjUsuario.LstrObservaciones = reader.GetValue(12).ToString();
                    lobjUsuario.LbytEliminado = Convert.ToByte(reader.GetValue(13).ToString());
                    lobjUsuario.LstrTipoIdentificacionID = reader.GetValue(14).ToString();
                    lobjUsuario.LstrInstitucionID = reader.GetValue(15).ToString();
                    lobjUsuario.LstrOficinaID = reader.GetValue(16).ToString();
                    lobjUsuario.LbytActivo = Convert.ToByte(reader.GetValue(17).ToString());
                }
                reader.Close();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return lobjUsuario;
        } // obtenerUsuarioUT
    }
}
