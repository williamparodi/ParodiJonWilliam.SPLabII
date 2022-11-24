using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using TpUtiles;

namespace Entidades
{
    public static class UtilDAO
    {
        static SqlConnection conexion;
        static SqlCommand command;
        static SqlDataReader reader;
        static string conexionString;
        static UtilDAO()
        {
            conexionString = "Server=.;Database=UTILES_DB;Trusted_Connection=True;";
            command = new SqlCommand();
            conexion = new SqlConnection(conexionString);
            command.Connection = conexion;
            command.CommandType = System.Data.CommandType.Text;
        }

        public static List<Util> LeerDatos()
        {
            List<Util> listaUtiles = new List<Util>();

            try
            {
                conexion.Open();
                command.CommandText = "SELECT * FROM UTILES";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string descripcion = reader["DESCRIPCION"].ToString();
                    switch (descripcion)
                    {
                        case "Lapiz":
                            Lapiz lapiz = new Lapiz();
                            lapiz.Color = (EColor)reader["COLOR"];
                            lapiz.TipoDeLapiz = (ETipoLapiz)reader["TIPO"];
                            lapiz.Precio = (double)reader["PRECIO"];
                            lapiz.Marca = reader["MARCA"].ToString();
                            listaUtiles.Add(lapiz);
                            break;
                        case "Sacapuntas":
                            Sacapunta sacapunta = new Sacapunta();
                            sacapunta.TipoSacapuntas = (ETipoSacapuntas)reader["TIPO"];
                            sacapunta.Marca = reader["MARCA"].ToString();
                            sacapunta.Precio = (double)reader["PRECIO"];
                            listaUtiles.Add(sacapunta);
                            break;
                        case "Goma":
                            Goma goma = new Goma();
                            goma.TipoGoma = (ETipoGoma)reader["TIPO"];
                            goma.Tamanio = (ETamanio)reader["TAMANIO"];
                            goma.Precio = (double)reader["PRECIO"];
                            goma.Marca = reader["MARCA"].ToString();
                            listaUtiles.Add(goma);
                            break;
                        default:
                            break;
                    }
                }

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

            return listaUtiles;

        }

        public static void GuardaLapiz(Lapiz lapiz)
        {
            command.Parameters.Clear();
            conexion.Open();

            try
            {
                command.CommandText = "INSERT INTO UTILES" + "VALUES @descripcion,@precio,@marca,@color,@tipo";
                if (lapiz is not null)
                {
                    command.Parameters.AddWithValue("@descricion", "Lapiz");
                    command.Parameters.AddWithValue("@precio", lapiz.Precio);
                    command.Parameters.AddWithValue("@marca", lapiz.Marca);
                    command.Parameters.AddWithValue("@color", lapiz.Color);
                    command.Parameters.AddWithValue("@tipo", lapiz.TipoDeLapiz);

                    if(command.ExecuteNonQuery() == 0)
                    {
                        throw new ExepcionesDatos("No se agrego Util");
                    }
                }
                
            }
            catch(Exception) 
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

        public static void GuardaGoma(Goma goma)
        {
            command.Parameters.Clear();
            conexion.Open();

            try
            {
                command.CommandText = "INSERT INTO UTILES" + "VALUES @descripcion,@precio,@marca,@tipo,@tamanio";
                if (goma is not null)
                {
                    command.Parameters.AddWithValue("@descricion", "Goma");
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

        public static void GuardaSacapuntas(Sacapunta sacapuntas)
        {
            command.Parameters.Clear();
            conexion.Open();

            try
            {
                command.CommandText = "INSERT INTO UTILES" + "VALUES @descripcion,@precio,@marca,@tipo";
                if (sacapuntas is not null)
                {
                    command.Parameters.AddWithValue("@descricion", "Sacapuntas");
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
            if (listaUtiles is not null && listaUtiles.Any())
            {
                foreach(var item in listaUtiles)
                {
                    if(item is Lapiz)
                    {
                        GuardaLapiz((Lapiz)item);
                    }
                    else if(item is Goma) 
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





    }
}
