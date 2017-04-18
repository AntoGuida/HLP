using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalParense
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // posibilita que el control ddlProvincias se cargue solo una vez
            {
                ddlProvincias.DataTextField = "Nombre";
                ddlProvincias.DataValueField = "IdProvincia";
                ddlProvincias.DataSource = GestorProvincias.ObtenerTodas1();
                ddlProvincias.DataBind();
                ddlProvincias.Items.Insert(0, new ListItem("Seleccione una provincia", ""));
                ddlProvincias.SelectedIndex = 0;  // opcion insertada en la primera posicion

                CargarGrillaClientes();
            }

            lblMensaje.Text = "";
        }



        private void CargarGrillaClientes()
        {
            //TODO ADO01) Implementar ObtenerTodos
            List<Cliente> Clientes = GestorClientes.ObtenerTodos();
            gvDatos.DataSource = Clientes;  // ver tema de propiedad de la grilla datakeynames
            gvDatos.DataBind();

        }
        protected void butAgregar_Click(object sender, EventArgs e)
        {
            pnlEdicion.Visible = true;
            pnlConsulta.Visible = false;
            lblAccion.Text = "Agregando...";
            butGrabar.Visible = true;  // visible en alta y en modificacion
            butEliminarConfirmar.Visible = false;

            LimpiarControles();

        }

        private void LimpiarControles()
        {
            // inicializar valores de los controles
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            radSexo.SelectedIndex = -1;   // ningun item seleccionado
            txtFechaNacimiento.Text = "";
            txtCuit.Text = "";
            chkTieneCasaPropia.Checked = false;
            txtCreditoMaximo.Text = "";
            ddlProvincias.SelectedValue = ""; // item Selecione una provincia
        }

        protected void butConsultar_Click(object sender, EventArgs e)
        {
            if (gvDatos.SelectedValue == null)
            {
                lblMensaje.Text = "Seleccione un Cliente para Consultar...";
                return;
            }
            pnlEdicion.Visible = true;
            pnlConsulta.Visible = false;
            lblAccion.Text = "Consultando...";
            butGrabar.Visible = false;  // visible en alta y en modificaciones

            BuscaryCargarControles();
        }

        protected void butGrabar_Click(object sender, EventArgs e)
        {
            Cliente c = null;
            if (txtIdCliente.Text == "")  // alta
            {
                c = new Cliente(); // idCliente = 0
            }
            else
            {
                int IdCliente = int.Parse(txtIdCliente.Text);  // se toma para modificaciones, en alta queda cero
                c = GestorClientes.BuscarPorId(IdCliente);
            }

            c.Nombre = txtNombre.Text;

            if (radSexo.SelectedValue != "")  //verificar si hay seleccion
                c.Sexo = radSexo.SelectedValue;
            else
                c.Sexo = "";

            c.TieneCasa = chkTieneCasaPropia.Checked;

            if (ddlProvincias.SelectedValue != "")  //verificar si hay seleccion
                c.IdProvincia = int.Parse(ddlProvincias.SelectedValue);
            else
                c.IdProvincia = null;

            if (txtFechaNacimiento.Text == "")
                c.FechaNacimiento = null;
            else
            {
                try
                {
                    c.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                }
                catch (Exception)
                {
                    lblMensaje.Text = "Ingrese la fecha con formato dd/mm/yyyy";
                    return;
                }

            }

            try
            {
                c.Cuit = long.Parse(txtCuit.Text);
            }
            catch (Exception)
            {
                lblMensaje.Text = "Ingrese Cuit solo con numeros...";
                return;
            }

            try
            {
                c.CreditoMaximo = decimal.Parse(txtCreditoMaximo.Text);
            }
            catch (Exception)
            {
                lblMensaje.Text = "Ingrese CreditoMaximo solo con numeros...";
                return;
            }


            try
            {
                GestorClientes.Grabar(c);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                return;
            }

            CargarGrillaClientes();
            pnlEdicion.Visible = false;
            pnlConsulta.Visible = true;
        }

        protected void butCancelar_Click(object sender, EventArgs e)
        {
            pnlEdicion.Visible = false;
            pnlConsulta.Visible = true;
        }

        protected void butEditar_Click(object sender, EventArgs e)
        {
            if (gvDatos.SelectedValue == null)
            {
                lblMensaje.Text = "Seleccione un Cliente para Editar...";
                return;
            }

            pnlEdicion.Visible = true;
            pnlConsulta.Visible = false;
            lblAccion.Text = "Editando...";
            butGrabar.Visible = true;
            butEliminarConfirmar.Visible = false;
            BuscaryCargarControles();
        }

        protected void butEliminar_Click(object sender, EventArgs e)
        {
            if (gvDatos.SelectedValue == null)
            {
                lblMensaje.Text = "Seleccione un Cliente para Eliminar...";
                return;
            }
            pnlEdicion.Visible = true;
            pnlConsulta.Visible = false;
            lblAccion.Text = "Eliminando...";
            butEliminarConfirmar.Visible = true;
            butGrabar.Visible = false;
            BuscaryCargarControles();
        }
        protected void butEliminarConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                GestorClientes.Eliminar(int.Parse(txtIdCliente.Text));
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.Message;
                return;
            }
            CargarGrillaClientes();
            pnlEdicion.Visible = false;
            pnlConsulta.Visible = true;
        }

        private void BuscaryCargarControles()
        {
            // buscar cliente seleccionado en la lista
            int IdCliente = (int)gvDatos.SelectedValue;

            //TODO ADO02) Implementar BuscarPorId que devuelva la entidad correspondiente al IdCliente solicitado
            Cliente c = GestorClientes.BuscarPorId(IdCliente);

            // mostrar en los controles los datos del cliente seleccionado
            txtIdCliente.Text = c.IdCliente.ToString();
            txtNombre.Text = c.Nombre.Trim();  //definir los campos como varchar para evitar sarle los espacios fijo del tipo char
            if (c.Sexo == "")
                radSexo.SelectedIndex = -1;  // sin seleccion
            else
                radSexo.SelectedValue = c.Sexo;

            if (c.IdProvincia == null)
                ddlProvincias.SelectedValue = "";  // corresponde a la opcion "seleccione una provincia"
            else
                ddlProvincias.SelectedValue = c.IdProvincia.ToString();

            if (c.FechaNacimiento == null)
                txtFechaNacimiento.Text = "";
            else
                txtFechaNacimiento.Text = c.FechaNacimiento.ToString();

            if (c.Cuit == null)
                txtCuit.Text = "";
            else
                txtCuit.Text = c.Cuit.ToString();

            if (c.CreditoMaximo == null)
                txtCreditoMaximo.Text = "";
            else
                txtCreditoMaximo.Text = c.CreditoMaximo.ToString();

        }
        protected void butBuscar_Click(object sender, EventArgs e)
        {
            //TODO ADO05) Implementar mentodo GestorClientes.ObtenerSegunFiltros(string nombre) devolviendo solo los datos necesarios => List<DtoClienteListado>
            // reemplazarlo dentro del metodo CargarGrillaClientes() e invocarlo desde aqui.
            lblMensaje.Text = "Funcionalidad no implementada aun...";
        }
    }
}