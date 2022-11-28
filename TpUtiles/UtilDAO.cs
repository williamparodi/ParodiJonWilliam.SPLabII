using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TpUtiles;

namespace Entidades
{
    public static class UtilDAO
    {
        static SqlConnection conexion;
        static SqlCommand command;
        static string conexionString;
        static UtilDAO()
        {
            conexionString = "Server=.;Database=UTILES_DB;Trusted_Connection=True;";
            command = new SqlCommand();
            conexion = new SqlConnection(conexionString);
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.Text;
        }

        public static List<Lapiz> LeerDatosLapiz()
        {
            List<Lapiz> listaLapiz = new List<Lapiz>();

            try
            {
                conexion.Open();
                command.CommandText = "SELECT * FROM LAPICES";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Lapiz lapiz = new Lapiz();
                    string color = reader["COLOR"].ToString();
                    string tipo = reader["TIPO"].ToString();
                    lapiz.Color = (EColor)Enum.Parse(typeof(EColor), color);
                    lapiz.TipoDeLapiz = (ETipoLapiz)Enum.Parse(typeof(ETipoLapiz), tipo);
                    lapiz.Precio = (double)reader["PRECIO"];
                    lapiz.Marca = reader["MARCA"].ToString();
                    lapiz.Id = (int)reader["ID_LAPIZ"];
                    listaLapiz.Add(lapiz);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al leer la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return listaLapiz;
        }

        public static void GuardaLapiz(Lapiz lapiz)
        {
            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.CommandText = "INSERT INTO LAPICES VALUES (@precio,@marca,@color,@tipo)";

                command.Parameters.AddWithValue("@precio", lapiz.Precio);
                command.Parameters.AddWithValue("@marca", lapiz.Marca);
                command.Parameters.AddWithValue("@color", lapiz.Color);
                command.Parameters.AddWithValue("@tipo", lapiz.TipoDeLapiz);
                
                if (command.ExecuteNonQuery() == 0)
                {
                    throw new ExepcionesDatos("No se agrego Util");
                }

            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al cargar el util a la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public static void BorraDatos(Util util)
        {
            try
            {
                command.Parameters.Clear();
                conexion.Open();
                switch (util)
                {
                    case Lapiz:
                        command.CommandText = $"DELETE FROM LAPICES WHERE ID_LAPIZ = {util.Id}";
                        command.ExecuteNonQuery();
                        break;
                    case Goma:
                        command.CommandText = $"DELETE FROM GOMAS WHERE ID_GOMA = {util.Id}";
                        command.ExecuteNonQuery();
                        break;
                    case Sacapunta:
                        command.CommandText = $"DELETE FROM SACAPUNTAS WHERE ID_SACAPUNTA = {util.Id}";
                        command.ExecuteNonQuery();
                        break;
                    default:
                        throw new ExceptionArchivo("No se pudo borrar");
                        
                }
            }
            catch(Exception)
            {
                throw new ExceptionArchivo("Error al borrar la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            
            
        }

        public static List<Goma> LeerDatosGoma()
        {
            List<Goma> listaGoma = new List<Goma>();

            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.CommandText = "SELECT * FROM GOMAS";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Goma goma = new Goma();
                    string tamanio = reader["TAMANIO"].ToString();
                    string tipo = reader["TIPO"].ToString();
                    goma.Tamanio = (ETamanio)Enum.Parse(typeof(ETamanio), tamanio);
                    goma.TipoGoma = (ETipoGoma)Enum.Parse(typeof(ETipoGoma), tipo);
                    goma.Precio = (double)reader["PRECIO"];
                    goma.Marca = reader["MARCA"].ToString();
                    goma.Id = (int)reader["ID_GOMA"];
                    listaGoma.Add(goma);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al leer la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return listaGoma;
        }

        public static void GuardaGoma(Goma goma)
        {
            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.CommandText = "INSERT INTO GOMAS" + "VALUES @precio,@marca,@tipo,@tamanio";
                if (goma is not null)
                {
                    command.Parameters.AddWithValue("@precio", goma.Precio);
                    command.Parameters.AddWithValue("@marca", goma.Marca);
                    command.Parameters.AddWithValue("@tipo", goma.TipoGoma);
                    command.Parameters.AddWithValue("@tamanio", goma.Tamanio);

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new ExepcionesDatos("No se agrego Util");
                    }
                }

            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al cargar el util a la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public static List<Sacapunta> LeerDatosSacapuntas()
        {
            List<Sacapunta> listaSacapuntas = new List<Sacapunta>();

            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.CommandText = "SELECT * FROM SACAPUNTAS";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Sacapunta sacapunta = new Sacapunta();
                    string tipo = reader["TIPO"].ToString();
                    sacapunta.TipoSacapuntas = (ETipoSacapuntas)Enum.Parse(typeof(ETipoSacapuntas),tipo);
                    sacapunta.Marca = reader["MARCA"].ToString();
                    sacapunta.Precio = (double)reader["PRECIO"];
                    sacapunta.Id = (int)reader["ID_SACAPUNTAS"];
                    listaSacapuntas.Add(sacapunta);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al leer la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return listaSacapuntas;
        }

        public static void GuardaSacapuntas(Sacapunta sacapuntas)
        {
            try
            {
                command.Parameters.Clear();
                conexion.Open();
                command.CommandText = "INSERT INTO SACAPUNTAS" + "VALUES @descripcion,@precio,@marca,@tipo";
                if (sacapuntas is not null)
                {
                    command.Parameters.AddWithValue("@descricion", "Lapiz");
                    command.Parameters.AddWithValue("@precio", sacapuntas.Precio);
                    command.Parameters.AddWithValue("@marca", sacapuntas.Marca);
                    command.Parameters.AddWithValue("@tipo", sacapuntas.TipoSacapuntas);

                    if (command.ExecuteNonQuery() == 0)
                    {
                        throw new ExepcionesDatos("No se agrego Util");
                    }
                }

            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al cargar el util a la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }

        public static void GuardaDatos(Util util)
        {
            try
            {
                if (util is not null)
                {
                    switch (util)
                    {
                        case Lapiz:
                        GuardaLapiz((Lapiz)util);
                        break;  
                        case Goma:
                        GuardaGoma((Goma)util);
                        break;
                        case Sacapunta:
                        GuardaSacapuntas((Sacapunta)util);
                        break;
                        default:
                            throw new ExceptionArchivo("No se pudo guardar en la base");
                    }
                }
            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al guardar el util en la base");
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }


        





    }
}
