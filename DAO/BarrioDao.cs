using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BarrioDao
    {
        public static List<Barrio> ObtenerBarrios(int id_localidad)
        {
            List<Barrio> listBarrio = new List<Barrio>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_barrio
                                      ,nombre                                     
                                FROM Barrio
                                where id_localidad=@id_localidad";
            cmm.Parameters.AddWithValue("@id_localidad", id_localidad);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Barrio b = new Barrio();
                b.id_barrio = int.Parse(dr["id_barrio"].ToString());
                b.nombre = dr["nombre"].ToString();

                listBarrio.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listBarrio;
        }
    }
}
