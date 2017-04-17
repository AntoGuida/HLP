using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLPNegocio
{
    public class Paciente
    {
        public static int ultimoId = 0;
        public static int ultimoIdMasUno = 0;

        public static List<Afiliado> ObtenerTodos()
        {
            List<Afiliado> listAfiliados = new List<Afiliado>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT a.numero_afiliado,a.apellido, a.nombre,a.telefono, a.afiliado_adicional FROM Afiliado";

                SqlDataReader dr = cmd.ExecuteReader();
                //Recorro cada uno de los registros del servidor de bd
                while (dr.Read())
                {
                    //Creo una entidad para guardar lo que viene de la bd
                    Afiliado a = new Afiliado();
                    a.nroAfiliado = int.Parse(dr["numero_afiliado"].ToString());
                    a.nombre = dr["nombre"].ToString();
                    a.apellido = dr["apellido"].ToString();
                    a.telefono = dr["telefono"].ToString();
                    Boolean afiliado = Convert.ToBoolean(dr["afiliado_adicional"].ToString());
                    if (afiliado) a.tipoAfiliado = "ADICIONAL"; // recupero el boolean del tipo de afiliado de la base y lo guardo en el afiliado como string para despues mostrarlo en la grilla
                    else a.tipoAfiliado = "TITULAR";

                    // Agrego la provincia a la lista
                    listAfiliados.Add(a);
                }

            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al obtener todos los afiliados");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
            return listAfiliados;
        }

        public static void Insertar(Afiliado a)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                //agregue id_localidad AGREGARLO EN LA BD TAMBIEN!!!!!!!!

                cmd.CommandText = @" INSERT INTO Afiliado (apellido, nombre, calle, numero, id_barrio,id_localidad, telefono, fecha_nacimiento ,sexo, monto, afiliado_adicional, tipo_doc, documento) VALUES (@apellido, @nombre, @calle, @numero,  @id_barrio, @telefono, @fecha_nacimiento, @sexo, @monto, @afiliado_adicional, @tipo_doc, @documento, @id_localidad)";

                cmd.Parameters.AddWithValue("@apellido", a.apellido);
                cmd.Parameters.AddWithValue("@nombre", a.nombre);
                cmd.Parameters.AddWithValue("@tipo_doc", a.tipo_doc);
                cmd.Parameters.AddWithValue("@documento", a.documento);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", a.fechaNacimiento);
                cmd.Parameters.AddWithValue("@calle", a.calle);
                cmd.Parameters.AddWithValue("@sexo", a.sexo);
                cmd.Parameters.AddWithValue("@monto", a.montoInscripcion);
                cmd.Parameters.AddWithValue("@afiliado_adicional", a.afiliadoAdicional);
                cmd.Parameters.AddWithValue("@id_localidad", a.id_localidad);

                if (a.nro.HasValue)
                    cmd.Parameters.AddWithValue("@numero", a.nro);
                else
                    cmd.Parameters.AddWithValue("@numero", DBNull.Value);

                if (a.id_barrio != null)
                    cmd.Parameters.AddWithValue("@id_barrio", a.id_barrio);
                else
                    cmd.Parameters.AddWithValue("@id_barrio", DBNull.Value);

                if (a.telefono != null)
                    cmd.Parameters.AddWithValue("@telefono", a.telefono);
                else
                    cmd.Parameters.AddWithValue("@telefono", DBNull.Value);

                cmd.ExecuteNonQuery();

            }


            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al insertar el afiliado");

            }

            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
        }

        public static void Eliminar(Afiliado a)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();

            try
            {
                cn.Open();


                if (a == null)
                    throw new ApplicationException("Parámetros incorrectos para la eliminacion del afiliado");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                //TODO 4 Definir el comando UPDATE de la propiedad CommandText y el parámetro
                cmd.CommandText = "DELETE FROM Afiliado WHERE nro_afiliado = @nro_afiliado";
                cmd.Parameters.AddWithValue("@nro_afiliado", a.nroAfiliado);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al eliminar el afiliado ");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }

        }

        public static int obtnerUltimoId()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.CommandText = @"select max(nro_afiliado) as Id from afiliado";
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ultimoId = int.Parse(dr["Id"].ToString());
                }

                ultimoIdMasUno = ultimoId + 1;

            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al eliminar el afiliado ");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }

            return ultimoIdMasUno;

        }


        public static void Actualizar(Afiliado a)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();
            try
            {
                cn.Open();
                // Verificar si cli.cod_cliente tiene un valor distinto de nulo, si es nulo disparar una excepcion
                if (a == null)
                    throw new ApplicationException("Parámetros incorrectos para la actualización de afiliado");

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                //TODO 4 Definir el comando UPDATE de la propiedad CommandText y el parámetro
                cmd.CommandText = @"UPDATE Afiliado
                                    SET nombre =@nombre, 
                                        apellido =@apellido, 
                                        tipo_doc=@tipo_doc,
                                        documento=@documento,
                                        telefono =@telefono, 
                                       monto=@monto,
                                    fecha_nacimiento =@fecha_nacimiento, 
                                        calle =@calle, 
                                        numero =@nro, 
                                         afiliado_adicional=@afiliado_adicional,
                                        sexo=@sexo,
                                        id_barrio = @id_barrio,
                                         id_localidad= @id_localidad,
                                     WHERE nro_afiliado=@nro_afiliado";


                cmd.Parameters.AddWithValue("@apellido", a.apellido);
                cmd.Parameters.AddWithValue("@nombre", a.nombre);
                cmd.Parameters.AddWithValue("@tipo_doc", a.tipo_doc);
                cmd.Parameters.AddWithValue("@documento", a.documento);
                cmd.Parameters.AddWithValue("@fecha_nacimiento", a.fechaNacimiento);
                cmd.Parameters.AddWithValue("@calle", a.calle);
                cmd.Parameters.AddWithValue("@sexo", a.sexo);
                cmd.Parameters.AddWithValue("@monto", a.montoInscripcion);
                cmd.Parameters.AddWithValue("@afiliado_adicional", a.afiliadoAdicional);
                cmd.Parameters.AddWithValue("@id_localidad", a.id_localidad);

                if (a.nro.HasValue)
                    cmd.Parameters.AddWithValue("@numero", a.nro);
                else
                    cmd.Parameters.AddWithValue("@numero", DBNull.Value);

                if (a.id_barrio != null)
                    cmd.Parameters.AddWithValue("@id_barrio", a.id_barrio);
                else
                    cmd.Parameters.AddWithValue("@id_barrio", DBNull.Value);

                if (a.telefono != null)
                    cmd.Parameters.AddWithValue("@telefono", a.telefono);
                else
                    cmd.Parameters.AddWithValue("@telefono", DBNull.Value);



                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al actualizar el afiliado ");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
        }

        //ESTE METODO ES PARA VER SI ES UNO NUEVO O NO !!!!!!
        public static Boolean VerificarSiExiste(int nroAfiliado)
        {
            Boolean bandera = true;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT * FROM Afiliado WHERE nro_afiliado=@nroAfiliado";
                cmd.Parameters.AddWithValue("@nroAfiliado", nroAfiliado);
                SqlDataReader dr = cmd.ExecuteReader();
                //Recorro cada uno de los registros del servidor de bd
                if (dr.Read())
                {
                    bandera = false;

                }
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al obtener AFILIADO.");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }

            return bandera;

        }



        public static Afiliado BuscarXMatr(int nroAfiliado)
        {
            Afiliado a = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT a.nro_afiliado, a.fecha_nacimiento, a.apellido, a.nombre, a.calle, a.numero, a.sexo, a.telefono, a.id_barrio,a.id_localidad, a.afiliado_adicional, a.monto, a.tipo_doc, a.documento , b.nombre as NombBarrio, l.nombre as NomLoc, t.descripcion
                                  FROM  (Afiliado a
                                  INNER JOIN Barrio b ON a.id_barrio=b.id_barrio INNER JOIN Localidad l ON b.id_localidad= l.id_localidad INNER JOIN Tipo_documento t ON a.id_tipo_doc=t.id_tipo_doc) where a.nro_afiliado=@nroAfiliado";
                cmd.Parameters.AddWithValue("@nroAfiliado", nroAfiliado);
                SqlDataReader dr = cmd.ExecuteReader();
                //Recorro cada uno de los registros del servidor de bd
                if (dr.Read())
                {
                    a = new Afiliado();
                    a.nroAfiliado = int.Parse(dr["nro_afiliado"].ToString());
                    a.tipo_doc = int.Parse(dr["tipo_doc"].ToString());
                    a.documento = int.Parse(dr["documento"].ToString());
                    a.montoInscripcion = decimal.Parse(dr["monto"].ToString());
                    a.nombre = dr["nombre"].ToString();
                    a.apellido = dr["apellido"].ToString();
                    a.sexo = Boolean.Parse(dr["sexo"].ToString());
                    a.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());
                    a.nombreBarrio = dr["NombBarrio"].ToString();
                    a.nombreLocalidad = dr["NombLoc"].ToString();
                    a.descripcionTipoDoc = dr["descripcion"].ToString();

                    if (dr["telefono"] != DBNull.Value)
                        a.telefono = dr["telefono"].ToString();
                    else
                        a.telefono = null;

                    if (dr["id_barrio"] != DBNull.Value)
                        a.id_barrio = int.Parse(dr["id_barrio"].ToString());
                    else
                        a.id_barrio = 0;

                    a.afiliadoAdicional = Boolean.Parse(dr["afiliado_adicional"].ToString());
                    a.calle = dr["calle"].ToString();

                    if (dr["numero"] != DBNull.Value)
                        a.nro = Convert.ToInt32(dr["numero"].ToString());
                    else
                        a.nro = null;




                }
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al obtener todos los afiliados.");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
            return a;

        }

        public static Afiliado Buscar(string apellido)
        {
            Afiliado a = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = BaseDeDatos.cadena();

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT a.nro_afiliado,a.id_barrio, a.nombre, a.apellido, a.telefono, a.calle, a.numero, a.monto, a.afiliado_adicional, a.fecha_nacimiento, a.sexo, a.tipo_doc, a.documento
                                  FROM Afiliado a INNER JOIN Barrio b ON a.id_barrio=b.id_barrio where a.apellido like @apellido";
                cmd.Parameters.AddWithValue("@apellido", apellido + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                //Recorro cada uno de los registros del servidor de bd
                if (dr.Read())
                {
                    a = new Afiliado();
                    a.nroAfiliado = int.Parse(dr["nro_afiliado"].ToString());
                    a.tipo_doc = int.Parse(dr["tipo_doc"].ToString());
                    a.documento = int.Parse(dr["documento"].ToString());
                    a.montoInscripcion = decimal.Parse(dr["monto"].ToString());
                    a.nombre = dr["nombre"].ToString();
                    a.apellido = dr["apellido"].ToString();
                    a.sexo = Boolean.Parse(dr["sexo"].ToString());
                    a.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());

                    if (dr["telefono"] != DBNull.Value)
                        a.telefono = dr["telefono"].ToString();
                    else
                        a.telefono = null;

                    if (dr["id_barrio"] != DBNull.Value)
                        a.id_barrio = int.Parse(dr["id_barrio"].ToString());
                    else
                        a.id_barrio = 0;

                    a.afiliadoAdicional = Boolean.Parse(dr["afiliado_adicional"].ToString());
                    a.calle = dr["calle"].ToString();

                    if (dr["numero"] != DBNull.Value)
                        a.nro = Convert.ToInt32(dr["numero"].ToString());
                    else
                        a.nro = null;




                }
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al obtener el afiliado por apellido. ");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
            return a;

        }

        //ESTE NOSE CUANDO SE USARIA !!!!
        public static Afiliado BuscarNombre(string nombre)
        {
            Afiliado a = null;
            SqlConnection cn = new SqlConnection();

            try
            {
                BaseDeDatos.conectar();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = @"SELECT a.nro_afiliado, a.nombre, a.apellido, a.telefono, a.calle, a.numero, a.id_barrio, a.monto, a.afiliado_adicional, a.fecha_nacimiento, a.sexo, a.tipo_doc, a.documento
                                  FROM Afiliado a INNER JOIN Barrio b ON a.id_barrio=b.id_barrio where a.nombre like @nombre";
                cmd.Parameters.AddWithValue("@nombre", nombre + "%");
                SqlDataReader dr = cmd.ExecuteReader();
                //Recorro cada uno de los registros del servidor de bd
                if (dr.Read())
                {
                    a = new Afiliado();
                    a.nroAfiliado = int.Parse(dr["nro_afiliado"].ToString());
                    a.tipo_doc = int.Parse(dr["tipo_doc"].ToString());
                    a.documento = int.Parse(dr["documento"].ToString());
                    a.montoInscripcion = decimal.Parse(dr["monto"].ToString());
                    a.nombre = dr["nombre"].ToString();
                    a.apellido = dr["apellido"].ToString();
                    a.sexo = Boolean.Parse(dr["sexo"].ToString());
                    a.fechaNacimiento = DateTime.Parse(dr["fecha_nacimiento"].ToString());

                    if (dr["telefono"] != DBNull.Value)
                        a.telefono = dr["telefono"].ToString();
                    else
                        a.telefono = null;

                    if (dr["id_barrio"] != DBNull.Value)
                        a.id_barrio = int.Parse(dr["id_barrio"].ToString());
                    else
                        a.id_barrio = 0;

                    a.afiliadoAdicional = Boolean.Parse(dr["afiliado_adicional"].ToString());
                    a.calle = dr["calle"].ToString();

                    if (dr["numero"] != DBNull.Value)
                        a.nro = Convert.ToInt32(dr["numero"].ToString());
                    else
                        a.nro = null;



                }
            }
            catch (SqlException ex)
            {
                // Guardar en un registro de errores para posterior depuracion
                throw new ApplicationException("Error al obtener todos los afiliados.");
            }
            finally
            {
                //Verifico si la conexión fue abierta
                BaseDeDatos.cerrar();
            }
            return a;

        }
    }
}

