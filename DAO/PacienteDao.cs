﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using System.Data.SqlClient;

namespace DAO
{
 public   class PacienteDao
    {
        public static List<Paciente> ObtenerTodos() //NO HACE FALTA POR AHORA PORQUE ES PARA CARGAR LA GRILLA
        {
            List<Paciente> listPaciente = new List<Paciente>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cmm.CommandText = @"SELECT *
                                      FROM Paciente  e INNER JOIN Barrio b ON e.id_barrio = b.id_barrio INNER JOIN SEXO S ON S.ID_SEXO=E.ID_SEXO INNER JOIN OBRASOCIAL OS ON E.ID_OBRA_SOCIAL=OS.ID_OBRA_SOCIAL
                                        INNER JOIN TIPODOC TD ON E.ID_TIPO_DOC=TD.ID_TIPO_DOC";
            SqlDataReader dr = cmm.ExecuteReader();

            while (dr.Read())
            {
                Paciente p = new Paciente();

                //if (dr["id_paciente"] != DBNull.Value)
                //    p.id_paciente = int.Parse(dr["id_paciente"].ToString());
                //p.apellido= dr["apellido"].ToString();
                //p.nombre = dr["nombre"].ToString();
                //p.domicilio = dr["domicilio"].ToString();
                //p.telefono = int.Parse(dr["telefono"].ToString());
                //p.id_barrio = int.Parse(dr["id_barrio"].ToString());
                //p.id_sexo = int.Parse(dr["id_sexo"].ToString());
                //p.id_tipo_doc = int.Parse(dr["id_tipo_doc"].ToString());
                //p.num_documento =int.Parse(dr["num_doc"].ToString());
                //p.fecha_nacimiento= DateTime.Parse(dr["fecha_nacimiento"].ToString());
                //p.antecedentes= dr["antecedentes"].ToString();
                //p.id_obrasocial = int.Parse(dr["id_obra_social"].ToString());
                //p.email = dr["email"].ToString();
                //p.nro_obra_social = dr["nro_obra_social"].ToString();

                listPaciente.Add(p);
                p = null;
            }

            dr.Close();
            cnn.Close();
            //3.Cerrar conexion y retornar lista
            //c.cerrarConexion();
            return listPaciente;
        }


        public static string Insertar(Paciente e1)
        {
            string script = @"<script type='text/javascript'>
                            alert('El componente se cargó con Exito!!');
                            </script>";
            try
            {
                //1. Abrir la conexion
                Conexion c = new Conexion();
                SqlConnection cn = c.abrirConexion();

                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"insert into Paciente 
                                values(@apellido,@nombre,@domicilio,@telefono,@id_barrio,@id_sexo,@id_tipo_doc,@num_doc,@fecha_nacimiento
                                        ,@antecedentes,@id_obra_social,@email,@nro_obra_social)";


                cmd.Parameters.AddWithValue("@apellido", e1.apellido);
                cmd.Parameters.AddWithValue("@nombre", e1.nombre);
                cmd.Parameters.AddWithValue("@domicilio", e1.domicilio);
                cmd.Parameters.AddWithValue("@telefono", e1.telefono);
                cmd.Parameters.AddWithValue("@id_barrio", e1.id_barrio);//VEEEER-- Es porque en paciente se llama id_barrio el objeto BARRIO
                cmd.Parameters.AddWithValue("@id_sexo", e1.id_sexo);
                cmd.Parameters.AddWithValue("@id_tipo_doc", e1.id_tipo_doc);
                cmd.Parameters.AddWithValue("@num_doc", e1.num_documento);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", e1.fecha_nacimiento);
                cmd.Parameters.AddWithValue("@antecedentes", e1.antecedentes);
                cmd.Parameters.AddWithValue("@id_obra_social", e1.id_obra_social);
                cmd.Parameters.AddWithValue("@email", e1.email);
                cmd.Parameters.AddWithValue("@nro_obra_social", e1.nro_obra_social);


                //Cerrar siempre la conexion
                cmd.ExecuteNonQuery();
                c.cerrarConexion();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        script = @"<script type='text/javascript'>
                            alert('No se puede ingresar el paciente en la base de datos.');
                            </script>";

                        break;
                    default:
                        script = @"<script type='text/javascript'>
                            alert('Error al ingresar el nuevo paciente');
                            </script>";
                        break;
                }
            }

            return script;
        }

        public static Paciente ObtenerPorDNI(int id_tipo_doc, int num_doc)
        {
             Paciente p = null;
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;
            cmm.CommandText = @"SELECT *
                                FROM PACIENTE Pac
                                INNER JOIN TipoDoc TD ON Pac.ID_TIPO_DOC=TD.ID_TIPO_DOC
                                INNER JOIN BARRIO b ON Pac.id_barrio = b.id_barrio
                                INNER JOIN LOCALIDAD L ON b.ID_LOCALIDAD=L.ID_LOCALIDAD
                                INNER JOIN PROVINCIA P ON L.ID_PROVINCIA=P.ID_PROVINCIA
                                INNER JOIN SEXO S ON Pac.ID_SEXO=S.ID_SEXO
                                where Pac.id_tipo_doc = @id_tipo_doc and Pac.num_doc=@num_doc";
            cmm.Parameters.AddWithValue("@id_tipo_doc", id_tipo_doc);
            cmm.Parameters.AddWithValue("@num_doc", num_doc);
            SqlDataReader dr = cmm.ExecuteReader();
            if (dr.Read())
            {

                p = new Paciente();

                p.apellido = dr["apellido"].ToString();
                p.nombre = dr["nombre"].ToString();
                p.domicilio = dr["domicilio"].ToString();
                p.telefono = int.Parse(dr["telefono"].ToString());
                p.id_barrio = int.Parse(dr["id_barrio"].ToString()); //es que es de tipo barrio :/
                p.id_sexo = int.Parse(dr["id_sexo"].ToString());
                p.id_tipo_doc = int.Parse(dr["id_tipo_doc"].ToString());
                p.num_documento = int.Parse(dr["num_doc"].ToString());
                p.fecha_nacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
                p.antecedentes = dr["antecedentes"].ToString();
                p.id_obra_social = int.Parse(dr["id_obra_social"].ToString());
                p.email = dr["email"].ToString();
                p.nro_obra_social = dr["nro_obra_social"].ToString();
                p.id_provincia = int.Parse(dr["id_provincia"].ToString());
                p.id_localidad = int.Parse(dr["id_localidad"].ToString());


            }
            dr.Close();
            c.cerrarConexion();
            return p;
        }

    }
}