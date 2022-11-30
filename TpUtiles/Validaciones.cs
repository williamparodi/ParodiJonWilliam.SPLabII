using System;

namespace Entidades
{
    public static class Validaciones
    {
        static Validaciones()
        {

        }

        public static bool ValidarString(string str)
        {
            bool validar = false;

            if (!string.IsNullOrEmpty(str))
            {
                validar = true;
            }

            return validar;
        }

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
