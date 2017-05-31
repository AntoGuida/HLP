using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;

namespace DAO
{
 public   class EspecialidadDao
    {

        public static List<String> VectorEspecialidad(String letra)
        {

            List<String> listEsp = new List<string>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_especialidad
                                      ,nombre                                    
                                FROM Especialidad
                                 WHERE nombre like @letra ";
            cmm.Parameters.AddWithValue("@letra", "%" + letra + "%");
            SqlDataReader dr = cmm.ExecuteReader();
        
            while (dr.Read())
            {
                listEsp.Add(dr["nombre"].ToString());

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listEsp;

        }
    }
}
