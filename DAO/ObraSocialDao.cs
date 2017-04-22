using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class ObraSocialDao
    {
        public static List<ObraSocial> ObtenerObraSocial()
        {
            List<ObraSocial> listObraSocial = new List<ObraSocial>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_obra_social
                                      ,nombre
                                     
                                FROM ObraSocial";
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                ObraSocial b = new ObraSocial();
                b.id_obra_social = int.Parse(dr["id_obra_social"].ToString());
                b.nombre = dr["nombre"].ToString();

                listObraSocial.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listObraSocial;
        }
    }
}
