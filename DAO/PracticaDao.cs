using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DAO
{
   public  class PracticaDao
    {

        public static List<String> VectorPrac(String letra)
        {

            List<String> listPrac = new List<string>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_practica
                                      ,nombre                                    
                                FROM Practica
                                     WHERE nombre like @letra ";
            cmm.Parameters.AddWithValue("@letra", "%" + letra + "%");
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                listPrac.Add(dr["nombre"].ToString());

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listPrac;

        }

    }
}
