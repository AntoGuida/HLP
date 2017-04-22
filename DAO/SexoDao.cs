using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SexoDao
    {
        public static List<Sexo> ObtenerSexo()
        {
            List<Sexo> listSexo = new List<Sexo>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_sexo
                                      ,nombre
                                     
                                FROM Sexo";
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Sexo b = new Sexo();
                b.id_sexo = int.Parse(dr["id_sexo"].ToString());
                b.nombre = dr["nombre"].ToString();

                listSexo.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listSexo;
        }
    }
}
