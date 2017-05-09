using DAO;
using ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HLP
{
    public partial class PacienteInterfaz : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarProvincias();
                cargarObraSocial();
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
            ddlObraSocial.SelectedIndex = -1;
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
            ddlObraSocial.SelectedIndex = -1;
            txtFechaNacimiento.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNroObraSocial.Text = "";
            txtDomicilio.Text = "";

        }


        protected void butGrabar_Click(object sender, EventArgs e)
        {
            Paciente emp = new Paciente();
            emp.apellido = txtApellido.Text;
            emp.nombre =txtNombre.Text;
            emp.domicilio = txtDomicilio.Text;
            emp.telefono = int.Parse(txtTelefono.Text);
            DateTime fecha;
            if (DateTime.TryParse(txtFechaNacimiento.Text, out fecha))
                emp.fecha_nacimiento = fecha;
            emp.id_barrio = int.Parse(ddlBarrio.SelectedValue);
            emp.id_sexo = int.Parse(ddlSexo.SelectedValue);
            emp.id_tipo_doc = int.Parse(ddlTipoDoc.SelectedValue);
            emp.num_documento = int.Parse(txtNroDoc.Text);
            emp.id_obra_social = int.Parse(ddlObraSocial.SelectedValue);
            emp.email = txtEmail.Text;
            emp.nro_obra_social = txtNroObraSocial.Text;

               
           
            //s.id_sexo = radSexo.SelectedIndex + 1 ;
           
           lblGuardar.Text = PacienteDao.Insertar(emp);
            lblGuardar.Visible = true;
            //btnEliminar.CssClass = "btn btn-warning";
            //btnEliminar.Enabled = true;
            //CargarGrillaEmpresas();
            Limpiar();
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

        protected void cargarObraSocial()
        {
            List<ObraSocial> ObraSocials = new List<ObraSocial>();
            ObraSocials = ObraSocialDao.ObtenerObraSocial();
            ddlObraSocial.DataSource = ObraSocials;
            ddlObraSocial.DataTextField = "nombre";
            ddlObraSocial.DataValueField = "id_obra_social";
            ddlObraSocial.DataBind();
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

            Paciente p = new Paciente();
            p  = PacienteDao.ObtenerPorDNI(int.Parse(ddlTipoDoc.SelectedValue), int.Parse(txtNroDoc.Text));

            if(p == null)
            {
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente no encontrado!";
                Limpiar2();

            }
            else
            {
                lblExiste.Visible = true;
                lblExiste.Text = "Paciente encontrado!";
                txtApellido.Text = p.apellido;
                txtNombre.Text = p.nombre;
                ddlSexo.SelectedValue = p.id_sexo.ToString();
                txtFechaNacimiento.Text = p.fecha_nacimiento.ToString();
                txtDomicilio.Text = p.domicilio;
                ddlProvincia.SelectedValue= p.id_provincia.ToString();
                ddlLocalidad.SelectedValue = p.id_localidad.ToString();
                ddlBarrio.SelectedValue = p.id_barrio.ToString();
                txtTelefono.Text = p.telefono.ToString();
                txtEmail.Text = p.email;
                ddlObraSocial.SelectedValue = p.id_obra_social.ToString();
                txtNroObraSocial.Text = p.nro_obra_social.ToString();

            }

        }

        protected void ddlTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void butEliminarCofirmar_Click(object sender, EventArgs e)
        {

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
             lista = ObraSocialDao.VectorObraSocial();
            return lista;
        }


    }
}