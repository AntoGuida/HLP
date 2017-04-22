using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;

namespace DAO
{
    class Conexion
    {
        private SqlConnection con { get; set; }

        private string cadenaConexion()
        {
            
            return @"Data Source=DESKTOP-CN55RJ1\SQLSERVER;Initial Catalog=OscorPav2;Integrated Security=True";
        }

        //metodo para obtener conexion
        public SqlConnection abrirConexion()
        {
            try
            {
                con = new SqlConnection(cadenaConexion());
                this.con.Open();
                return this.con;
            }
            catch (Exception) 
            {
                return null;
            }

        }

        //metodo para cerrar conexion
        public void cerrarConexion()
        {
            if (this.con!=null)
            this.con.Close();
        }

    }
}
