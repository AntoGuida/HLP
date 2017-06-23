using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;

namespace DAO
{
   public class AntXPacDao
    {

        public  string insertarAntPorPac(AntXPac ap)
        {
            string script = @"<script type='text/javascript'>
                            alert('El componente se cargó con Exito!!');
                            </script>";
            try
            {
                //1. Abrir la conexion
                Conexion c = new Conexion();
                SqlConnection cn = c.abrirConexion();

                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"insert into AntecXPac 
                                values(@id_antecedente,@id_paciente)";


                cmd.Parameters.AddWithValue("@id_paciente", ap.id_paciente);
                cmd.Parameters.AddWithValue("@id_antecedente", ap.id_antecedente);
               

                //Cerrar siempre la conexion
                cmd.ExecuteNonQuery();
                c.cerrarConexion();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        script = @"<script type='text/javascript'>
                            alert('No se puede ingresar el paciente en la base de datos.');
                            </script>";

                        break;
                    default:
                        script = @"<script type='text/javascript'>
                            alert('Error al ingresar el nuevo paciente');
                            </script>";
                        break;
                }
            }

            return script;
        }

        public string eliminarAntPorPac(AntXPac ap)
        {
            string script = @"<script type='text/javascript'>
                            alert('El componente se cargó con Exito!!');
                            </script>";
            try
            {
                //1. Abrir la conexion
                Conexion c = new Conexion();
                SqlConnection cn = c.abrirConexion();

                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"delete AntecXPac 
                                where id_paciente=@id_paciente and id_antecedente=@id_antecedente";


                cmd.Parameters.AddWithValue("@id_paciente", ap.id_paciente);
                cmd.Parameters.AddWithValue("@id_antecedente", ap.id_antecedente);


                //Cerrar siempre la conexion
                cmd.ExecuteNonQuery();
                c.cerrarConexion();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        script = @"<script type='text/javascript'>
                            alert('No se puede ingresar el paciente en la base de datos.');
                            </script>";

                        break;
                    default:
                        script = @"<script type='text/javascript'>
                            alert('Error al ingresar el nuevo paciente');
                            </script>";
                        break;
                }
            }

            return script;
        }



    }
}
