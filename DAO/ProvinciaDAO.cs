using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class ProvinciaDao
    {
        public static List<Provincia> ObtenerProvincias()
        {
            List<Provincia> listProvincia = new List<Provincia>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_provincia
                                      ,nombre
                                     
                                FROM Provincia";
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Provincia b = new Provincia();
                b.id_provincia = int.Parse(dr["id_provincia"].ToString());
                b.nombre = dr["nombre"].ToString();

                listProvincia.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listProvincia;
        }
    }
}
