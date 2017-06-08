using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using ENTIDADES;

namespace HLP
{
    public partial class AntecedentesInterfaz : System.Web.UI.Page
    {
        Paciente p = new Paciente();

        AntXPacDao apd = new AntXPacDao();

        List<int> lista = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(Request.QueryString["id_pac"] != "")
            //{
            int id_pac = int.Parse(Request.QueryString["id_pac"]);

            p = PacienteDao.ObtenerPorID(id_pac);
            lblApellido.Text = p.apellido;
            lblNombre.Text = p.nombre;
            lblGuardar.Visible = false;

            //}
            if (!IsPostBack)
            { cargarAntecedentes(); }

        }


        protected void cargarAntecedentes()
        {
            List<Antecedentes> ant = new List<Antecedentes>();
            ant = Antecedente.ObtenerAntecedentes();
            chkAnt1.DataSource = ant;
            chkAnt1.DataTextField = "nombre";
            chkAnt1.DataValueField = "id_antecedente";
            chkAnt1.DataBind();

            List<int> listaValues = Antecedente.obtenerValues(p.id_paciente);

            for (int i = 0; i < chkAnt1.Items.Count; i++)
            {
                for (int j = 0; j < listaValues.Count; j++)
                {
                    if (chkAnt1.Items[i].Value == listaValues[j].ToString())
                    {
                        chkAnt1.Items[i].Selected = true;
                    }
                }

            }



        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            List<int> listaValues = Antecedente.obtenerValues(p.id_paciente);
            Boolean ban = false;


            if (listaValues.Count > 0) //tengo antecedentes guardados
            {

                for (int i = 0; i < chkAnt1.Items.Count; i++)
                {
                    if (chkAnt1.Items[i].Selected)

                    {
                        int valorSeleccionado = int.Parse(chkAnt1.Items[i].Value);

                        for (int j = 0; j < listaValues.Count; j++)
                        {
                            int valorLista = int.Parse(listaValues[j].ToString());

                            if (valorSeleccionado == valorLista)
                            {
                                ban = true;

                            }
                        }

                        if (ban == false)
                        {
                            AntXPac ap = new AntXPac();
                            ap.id_paciente = p.id_paciente;
                            ap.id_antecedente = int.Parse(chkAnt1.Items[i].Value);
                            apd.insertarAntPorPac(ap);

                        }

                    }

                    else
                    {
                        int posibleValorAEliminar = int.Parse(chkAnt1.Items[i].Value);

                        for (int j = 0; j < listaValues.Count; j++)
                        {
                            int valorLista = int.Parse(listaValues[j].ToString());

                            if (posibleValorAEliminar == valorLista)
                            {
                                AntXPac ap = new AntXPac();
                                ap.id_paciente = p.id_paciente;
                                ap.id_antecedente = int.Parse(chkAnt1.Items[i].Value);
                                apd.eliminarAntPorPac(ap);

                            }


                        }
                    }
                    ban = false;
                }
            }
            

            else
            {
                for (int i = 0; i < chkAnt1.Items.Count; i++)
                {
                    if (chkAnt1.Items[i].Selected)
                    {

                        AntXPac ap = new AntXPac();
                        ap.id_paciente = p.id_paciente;
                        ap.id_antecedente = int.Parse(chkAnt1.Items[i].Value);
                        apd.insertarAntPorPac(ap);

                    }


                }

            }

            lblGuardar.Visible = true;

        }

    }
}