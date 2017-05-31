using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTIDADES;
using System.Data.SqlClient;
using DAO;
using System.Data;

namespace HLP
{
    public partial class ConsultaPacientesInterfaz : System.Web.UI.Page
    {

        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarGrilla();
        }


        public void cargarGrilla()
        {

            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            SqlCommand cm = new SqlCommand(string.Format("SELECT  p.apellido as 'Apellido', p.nombre as 'Nombre', td.nombre as 'Tipo Documento', p.num_doc as 'Número', (CAST(DATEDIFF(DD, p.fecha_nacimiento, GETDATE())/365.25 as int)) as 'Edad', p.fecha_alta as 'Fecha Alta' FROM Paciente p INNER JOIN TipoDoc td on p.id_tipo_doc = td.id_tipo_doc"));
            cm.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            dt = new DataTable();
            da.Fill(dt);



            dgvPaciente.DataSource = dt;

            dgvPaciente.DataBind();

        }


        protected void ordenar(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = dgvPaciente.DataSource as DataTable;

            if (dt != null)
            {
                DataView dv = new DataView(dt);
                dt.DefaultView.Sort = e.SortExpression + " ASC";
                dgvPaciente.DataSource = dv;
                dgvPaciente.DataBind();

            }
        }

        public DataTable tabla()
        {


            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            SqlCommand cm = new SqlCommand(string.Format("SELECT * FROM Paciente  e INNER JOIN Barrio b ON e.id_barrio = b.id_barrio INNER JOIN SEXO S ON S.ID_SEXO = E.ID_SEXO INNER JOIN OBRASOCIAL OS ON E.ID_OBRA_SOCIAL = OS.ID_OBRA_SOCIAL INNER JOIN TIPODOC TD ON E.ID_TIPO_DOC = TD.ID_TIPO_DOC"));
            cm.Connection = cnn;
            SqlDataAdapter da = new SqlDataAdapter(cm);
            dt = new DataTable();

            return dt;
        }
    }


}