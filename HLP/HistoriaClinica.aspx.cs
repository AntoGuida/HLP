using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using ENTIDADES;
using System.Web.Services;

namespace HLP
{
    public partial class HistoriaClinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if(!IsPostBack)
            {
                cargarTipoDocumentos();
                
            }
        }

        
        protected void butConsultaPaciente_Click(object sender, EventArgs e)
        {
            List<AntXPac> lista= new List<AntXPac>();
            lista = PacienteDao.ObtenerPacConAntecedentes(int.Parse(ddlTipoDoc.SelectedValue), int.Parse(txtNroDoc.Text));

            if (lista == null)
            {
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente no encontrado!";

            }
            else
            {
                string ant = "";
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente encontrado!";
                for (int i = 0; i < lista.Count ; i++)
                {
                    AntXPac paciente = new AntXPac();
                    paciente = lista[i];
                    txtNombrePac.Text = paciente.nombrePaciente;                    
                    ant += paciente.nombreAnte + "-" + "\n";
                }

                txtAntecedentes.Text = ant;
                
            }

        }

        protected void btnAgregarDHC_Click(object sender, EventArgs e)
        {
            pnNuevoDetalle.Visible = true;
        }

        protected void ddlTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void cargarTipoDocumentos()
        {
            List<TipoDocumento> TipoDocumentos = new List<TipoDocumento>();
            TipoDocumentos = TipoDocDao.ObtenerTipoDocumento();
            ddlTipoDoc.DataSource = TipoDocumentos;
            ddlTipoDoc.DataTextField = "nombre";
            ddlTipoDoc.DataValueField = "id_tipo_doc";
            ddlTipoDoc.DataBind();
        }


        [WebMethod]
        public static List<string> GetEsp(string cityname)
        {

            List<String> lista = new List<String>();
            lista = EspecialidadDao.VectorEspecialidad(cityname);
            return lista;
        }

        [WebMethod]
        public static List<string> GetPrac(string cityname)
        {

            List<String> lista = new List<String>();
            lista = PracticaDao.VectorPrac(cityname);
            return lista;
        }

        [WebMethod]
        public static List<string> GetMed(string cityname)
        {

            List<String> lista = new List<String>();
            lista = MedicoDao.VectorMedico(cityname);
            return lista;
        }
    }
}