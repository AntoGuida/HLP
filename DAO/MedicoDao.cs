﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
   public class MedicoDao
    {
        public static List<String> VectorMedico(String letra)
        {

            List<String> listMedico = new List<string>();
            //1. Abrir la conexion
            Conexion c = new Conexion();
            SqlConnection cnn = c.abrirConexion();

            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmm = new SqlCommand();
            cmm.Connection = cnn;

            cmm.CommandText = @"SELECT id_medico
                                      ,apellido, nombre                                   
                                FROM Practica
                                     WHERE nombre like @letra ";
            cmm.Parameters.AddWithValue("@letra", "%" + letra + "%");
            SqlDataReader dr = cmm.ExecuteReader();
            
            while (dr.Read())
            {
                listMedico.Add(dr["apellido"].ToString());

            }
            dr.Close();
            //3.Cerrar conexion y retornar datareader
            c.cerrarConexion();
            return listMedico;

        }
    }
}
