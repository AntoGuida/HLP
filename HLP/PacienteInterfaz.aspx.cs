using DAO;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HLP
{
    public partial class PacienteInterfaz : System.Web.UI.Page
    {
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarProvincias();
                cargarTipoDocumentos();
                cargarSexos();
             
            }



        }

        public void Limpiar()
        {
            ddlTipoDoc.SelectedIndex = -1;
            txtNroDoc.Text = "";
            lblExiste.Visible = false;
            lblGuardar.Visible = false;
            txtApellido.Text = "";
            txtNombre.Text = "";
            ddlSexo.SelectedIndex = -1;
            ddlProvincia.SelectedIndex = -1;
            ddlLocalidad.SelectedIndex = -1;
            ddlBarrio.SelectedIndex = -1;
            txtCity.Text = "";
            txtFechaNacimiento.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNroObraSocial.Text = "";
            txtDomicilio.Text = "";

        }

        public void Limpiar2()
        {
          
            lblExiste.Visible = false;
            txtApellido.Text = "";
            txtNombre.Text = "";
            ddlSexo.SelectedIndex = -1;
            ddlProvincia.SelectedIndex = -1;
            ddlLocalidad.SelectedIndex = -1;
            ddlBarrio.SelectedIndex = -1;
            txtCity.Text="";
            txtFechaNacimiento.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNroObraSocial.Text = "";
            txtDomicilio.Text = "";

        }

      

        protected void butGrabar_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                if (PacienteDao.ExistePaciente(int.Parse(ddlTipoDoc.SelectedValue), int.Parse(txtNroDoc.Text)))
                {
                    lblExiste.Text = "Paciente ya registrado";
                }

                else
                { 
                Paciente emp = new Paciente();

                if (txtApellido.Text != String.Empty)
                { emp.apellido = txtApellido.Text; }
                if (txtNombre.Text != String.Empty)
                { emp.nombre = txtNombre.Text; }
                if (txtDomicilio.Text != String.Empty)
                { emp.domicilio = txtDomicilio.Text; }
                if (txtTelefono.Text != String.Empty)
                { emp.telefono = int.Parse(txtTelefono.Text); }
                if (txtFechaNacimiento.Text != String.Empty)
                {
                    DateTime fecha;
                    if (DateTime.TryParse(txtFechaNacimiento.Text, out fecha))
                        emp.fecha_nacimiento = fecha;
                }

              
                if(ddlBarrio.SelectedValue != "")
                {

                    emp.id_barrio = int.Parse(ddlBarrio.SelectedValue);
                }
               
                emp.id_sexo = int.Parse(ddlSexo.SelectedValue);

                emp.id_tipo_doc = int.Parse(ddlTipoDoc.SelectedValue);

                if (txtNroDoc.Text != String.Empty)
                { emp.num_documento = int.Parse(txtNroDoc.Text); }

                int id = ObraSocialDao.ObtenerIDObraSocial(txtCity.Text);
                emp.id_obra_social = id;

                if (txtEmail.Text != String.Empty)
                { emp.email = txtEmail.Text; }

                if (txtNroObraSocial.Text != String.Empty)
                { emp.nro_obra_social = txtNroObraSocial.Text; }

                    //s.id_sexo = radSexo.SelectedIndex + 1;


                    lblGuardar.Text = PacienteDao.Insertar(emp);
                lblGuardar.Visible = true;

                Response.Redirect("ConsultaPacientesInterfaz.aspx");
                    //btnEliminar.CssClass = "btn btn-warning";
                    //btnEliminar.Enabled = true;
                    //CargarGrillaEmpresas();
                    //Limpiar();

                }
            }
            
        }

        protected void cargarProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            provincias = ProvinciaDao.ObtenerProvincias();
            ddlProvincia.DataSource = provincias;
            ddlProvincia.DataTextField = "nombre";
            ddlProvincia.DataValueField = "id_provincia";
            ddlProvincia.DataBind();
        }

        protected void cargarLocalidads()
        {
            List<Localidad> Localidads = new List<Localidad>();
            Localidads = LocalidadDao.ObtenerLocalidad(int.Parse(ddlProvincia.SelectedValue));
            ddlLocalidad.DataSource = Localidads;
            ddlLocalidad.DataTextField = "nombre";
            ddlLocalidad.DataValueField = "id_Localidad";
            ddlLocalidad.DataBind();
        }
        protected void cargarBarrios()
        {
            List<Barrio> Barrios = new List<Barrio>();
            Barrios = BarrioDao.ObtenerBarrios(int.Parse(ddlLocalidad.SelectedValue));
            ddlBarrio.DataSource = Barrios;
            ddlBarrio.DataTextField = "nombre";
            ddlBarrio.DataValueField = "id_Barrio";
            ddlBarrio.DataBind();
        }

        protected void cargarSexos()
        {
            List<Sexo> Sexos = new List<Sexo>();
            Sexos = SexoDao.ObtenerSexo();
            ddlSexo.DataSource = Sexos;
            ddlSexo.DataTextField = "nombre";
            ddlSexo.DataValueField = "id_sexo";
            ddlSexo.DataBind();
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
            

        
        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarLocalidads();
        }

        protected void ddlLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarBarrios();
        }

        protected void butConsultaPaciente_Click(object sender, EventArgs e)
        {
            ValidarPaciente();
        }

        public void ValidarPaciente()
        {
            Paciente p = new Paciente();
            p = PacienteDao.ObtenerPorDNI(int.Parse(ddlTipoDoc.SelectedValue), int.Parse(txtNroDoc.Text));

            if (p == null)
            {
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente no encontrado!";
                Limpiar2();

            }
            else
            {
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente encontrado!";
                if (p.apellido != null)
                { txtApellido.Text = p.apellido; }
                if (p.nombre != null)
                { txtNombre.Text = p.nombre; }

                ddlSexo.SelectedValue = p.id_sexo.ToString();
                txtFechaNacimiento.Text = p.fecha_nacimiento.ToShortDateString();

                if (p.domicilio != null)
                { txtDomicilio.Text = p.domicilio; }

                cargarProvincias();
                ddlProvincia.SelectedValue = p.id_provincia.ToString();
                cargarLocalidads();
                ddlLocalidad.SelectedValue = p.id_localidad.ToString();
                cargarBarrios();
                ddlBarrio.SelectedValue = p.id_barrio.ToString();

                txtTelefono.Text = p.telefono.ToString();
                if (txtEmail.Text != null)
                { txtEmail.Text = p.email; }
                if (txtNroObraSocial.Text != null)
                //string nroOS = p.nro_obra_social.ToString();
                { txtNroObraSocial.Text = p.nro_obra_social.ToString(); }
                txtCity.Text = p.nombre_obra_social.ToString();

            }
        }




        //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        //public static string[] GetCompletionList(String prefixText, int count)
        //{
        //    String[] lista;
        //    return lista = ObraSocialDao.VectorObraSocial(prefixText, count);
        //}


        [WebMethod]
        public static List<string> GetCities(string cityname)
        {

            List<String> lista = new List <String> ();
             lista = ObraSocialDao.VectorObraSocial(cityname);
            return lista;
        }

        protected void ddlTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void butEliminarCofirmar_Click(object sender, EventArgs e)
        {
            
            Paciente p = new Paciente();
            p = PacienteDao.ObtenerPorDNI(int.Parse(ddlTipoDoc.SelectedValue), int.Parse(txtNroDoc.Text));
            Response.Redirect("AntecedentesInterfaz.aspx?id_pac=" + p.id_paciente);

        }

        
        protected void btnConsultar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaPacientesInterfaz.aspx");
        }

        protected void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            ValidarPaciente();
        }
    }
}
