﻿using System;

namespace Entidades
{
    public static class Validaciones
    {
        static Validaciones()
        {

        }

        /// <summary>
        /// Devuelve true si el string pasado por parametro no es nulo o vacio 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ValidarString(string str)
        {
            bool validar = false;

            if (!string.IsNullOrEmpty(str))
            {
                validar = true;
            }

            return validar;
        }

        /// <summary>
        /// Valida que el string pasado por parametro no sea nulo, vacio y que se pueda pasear a double
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>        
        public static bool ValidarNumero(string numero)
        {
            bool validar = false;
            double numeroValidado = 0;
            if (!string.IsNullOrEmpty(numero) && double.TryParse(numero, out numeroValidado))
            {
                validar = true;
            }

            return validar;
        }

        /// <summary>
        /// Valida dos string uqe no sean vacios y lanza las excepciones correspondientes 
        /// </summary>
        /// <param name="precio"></param>
        /// <param name="marca"></param>
        /// <exception cref="ExepcionesDatos"></exception>
        public static void ValidarDatosIngresados(string precio, string marca)
        {
            try
            {
                if (precio == string.Empty)
                {
                    throw new ExepcionesDatos("Precio no ingresado");
                }
                else if (marca == string.Empty)
                {
                    throw new ExepcionesDatos("Marca no ingresado");
                }
                double.Parse(precio);
            }
            catch (FormatException ex)
            {
                throw new ExepcionesDatos("Dato no valido", ex);
            }
            catch (Exception ex)
            {
                throw new ExepcionesDatos(ex.Message);
            }
        }

    }
}
