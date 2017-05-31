using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;


namespace DAO
{
   public class Antecedente
    {


        public static List<Antecedentes> ObtenerAntecedentes()
        {
            List<Antecedentes> listAnt = new List<Antecedentes>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_antecedente
                                      ,nombre
                                     
                                FROM Antecedente";
            SqlDataReader dr = cmm.ExecuteReader();
            while (dr.Read())
            {
                Antecedentes b = new Antecedentes();
                b.id_antecedente = int.Parse(dr["id_antecedente"].ToString());
                b.nombre = dr["nombre"].ToString();

                listAnt.Add(b);

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listAnt;
        }

        public static List<int> obtenerValues(int id_paciente)
        {
            List<int> listAnt = new List<int>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_antecedente, id_paciente FROM AntecXPac WHERE id_paciente=@id_paciente";
            cmm.Parameters.AddWithValue("@id_paciente", id_paciente);
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                      

                listAnt.Add(int.Parse(dr["id_antecedente"].ToString()));

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listAnt;
        }

    }
}
