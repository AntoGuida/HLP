using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLPDatos
{
    public class BaseDeDatos
    {
        static string cadena = ConfigurationManager.ConnectionStrings["HLP"].ConnectionString;

        public static SqlConnection OpenCN(string Cadena = cadena)
        {
            SqlConnection cn = new SqlConnection(cadena);

            try
            {

                cn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al acceder a la base de datos");
            }
            return cn;

        }


        public static DataTable ExecuteTable1(string sql, List<SqlParameter> parametros)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=maquis;Initial Catalog=Pymes3;User ID=avisuales2;Password=avisuales2");
            DataTable dt = new DataTable();
            try
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                //loguear error y luego desencadena un con los datos minimos para el usuario
                //throw new Exception("Error al acceder a la base de datos");
                throw new Exception("Error al crear la tabla");
            }
            finally
            {
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
            return dt;
        }

        public static DataTable ExecuteTable2(string sql, List<SqlParameter> parametros)
        {
            DataTable dt = new DataTable();
            ExecuteReader(sql, parametros,
                delegate (System.Data.IDataReader dr)
                {
                    dt.Load(dr);
                }
            );
            return dt;
        }

        public static void ExecuteReader(string sql, List<SqlParameter> parametros, Action<IDataReader> MetodoLectura)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=maquis;Initial Catalog=Pymes3;User ID=avisuales2;Password=avisuales2");
            SqlDataReader dr = null;
            SqlCommand cmd = new SqlCommand(sql, cn);
            try
            {
                if (sql.IndexOf(" ") == -1)
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (parametros.Count > 0)
                    cmd.Parameters.AddRange(parametros.ToArray());
                cn.Open();
                dr = cmd.ExecuteReader();
                MetodoLectura(dr);
                dr.Close();
            }
            catch (Exception ex)
            {
                //loguear error y luego desencadena un con los datos minimos para el usuario
                //throw new Exception("Error al acceder a la base de datos");
                throw;
            }
            finally
            {
                if (dr != null)
                    dr.Close();
                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
        }

        public static int ExecuteNonQuery(string sql, List<SqlParameter> parametros)
        {
            return 0;
        }

        public static object ExecuteScalar(string sql, List<SqlParameter> parametros)
        {
            return null;
        }

    }
}

