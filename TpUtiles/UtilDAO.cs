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
                command.Parameters.AddWithValue("@color", (int)lapiz.Color);
                command.Parameters.AddWithValue("@tipo", (int)lapiz.TipoDeLapiz);
                
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

        public static void GuardaDatos(List<Util> listaUtiles)
        {
            try
            {
                command.Parameters.Clear();
                conexion.Open();

                if (listaUtiles is not null && listaUtiles.Any())
                {
                    foreach (var item in listaUtiles)
                    {
                        if (item is Lapiz)
                        {
                            GuardaLapiz((Lapiz)item);
                        }
                        else if (item is Goma)
                        {
                            GuardaGoma((Goma)item);
                        }
                        else
                        {
                            GuardaSacapuntas((Sacapunta)item);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new ExceptionArchivo("Error al guardar la lista de utiles en la base");
            }

        }






    }
}
