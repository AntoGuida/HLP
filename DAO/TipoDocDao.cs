using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TipoDocDao
    {
        public static List<TipoDocumento> ObtenerTipoDocumento()
        {
            List<TipoDocumento> listTipoDocumento = new List<TipoDocumento>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_tipo_doc
                                      ,nombre
                                     
                                FROM TipoDoc";
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                TipoDocumento b = new TipoDocumento();
                b.id_tipo_doc = int.Parse(dr["id_tipo_doc"].ToString());
                b.nombre = dr["nombre"].ToString();

                listTipoDocumento.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listTipoDocumento;
        }
    }
}
