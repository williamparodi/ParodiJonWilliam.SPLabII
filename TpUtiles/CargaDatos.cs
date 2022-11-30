using System.Collections.Generic;

namespace Entidades
{
    public static class CargaDatos 
    {
        public static List<string> CargaTipo(string texto)
        {
            List<string> listaTipo = new List<string>();
            if (!string.IsNullOrEmpty(texto))
            {
                if (texto == "Lapiz")
                {
                    listaTipo.Add("Normal");
                    listaTipo.Add("Grafito");
                }
                else if (texto == "Goma")
                {
                    listaTipo.Add("ParaLapiz");
                    listaTipo.Add("ParaTinta");
                }
                else if (texto == "Sacapunta")
                {
                    listaTipo.Add("Portatil");
                    listaTipo.Add("Electrico");
                }
            }
            else
            {
                throw new ExepcionesDatos("Datos mal ingresados");
            }

            return listaTipo;
        }

        public static List<string> CargaColor(string texto)
        {
            List<string> listaColor = new List<string>();
            if (!string.IsNullOrEmpty(texto))
            {
                if (texto == "Lapiz")
                {
                    listaColor.Add("Amarillo");
                    listaColor.Add("Negro");
                    listaColor.Add("Azul");
                    listaColor.Add("Rojo");
                }
            }
            else
            {
                throw new ExepcionesDatos("Dato mal ingresado");
            }

            return listaColor;
        }

        public static List<string> CargaTamanio(string texto)
        {
            List<string> listaTamanio = new List<string>();
            if (!string.IsNullOrEmpty(texto))
            {
                if (texto == "Goma")
                {
                    listaTamanio.Add("Numero1");
                    listaTamanio.Add("Numero2");
                    listaTamanio.Add("Numero3");
                }
            }
            else
            {
                throw new ExepcionesDatos("Dato mal ingresado");
            }

            return listaTamanio;
        }
        
    }
}
