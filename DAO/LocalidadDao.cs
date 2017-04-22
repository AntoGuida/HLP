using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class LocalidadDao
    {
        public static List<Localidad> ObtenerLocalidad(int id_provincia)
        {
            List<Localidad> listLocalidad = new List<Localidad>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_localidad
                                      ,nombre                                     
                                FROM Localidad
                                where id_provincia=@id_provincia";
            cmm.Parameters.AddWithValue("@id_provincia ", id_provincia);
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Localidad b = new Localidad();
                b.id_localidad = int.Parse(dr["id_localidad"].ToString());
                b.nombre = dr["nombre"].ToString();

                listLocalidad.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listLocalidad;
        }
    }
}
