using Entidades;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;

namespace TpUtiles
{
    public delegate void DelegadoPrecio(string mensaje);
    public class Cartuchera<T> where T : Util
    {
        private int capacidad;
        private List<T> listaUtiles;
        
        public  event DelegadoPrecio EventoPrecio;
        public Cartuchera()
        {
            this.capacidad = 0;
            this.listaUtiles = new List<T>();
        }

        public Cartuchera(int capacidad, List<T> listaUtiles) : this()
        {
            this.capacidad = capacidad;
            this.listaUtiles = listaUtiles;
        }

        public int Capacidad
        {
            get { return capacidad; }
            set { capacidad = value; }
        }

        public List<T> ListaUtiles
        {
            get { return listaUtiles; }
            set { listaUtiles = value; }
        }

        public double PrecioTotal
        {
            get { return AcumulaPrecio(this.ListaUtiles); }
            set
            {
                if(EventoPrecio is not null && AcumulaPrecio(this.ListaUtiles) >500)
                {
                    EventoPrecio("Se supero");
                }
            }
        }

        public static bool operator +(Cartuchera<T> cartuchera, T util)
        {
            bool retorno = false;
            string tickets = "";
            
            if (cartuchera is not null && util is not null)
            {
                if (cartuchera.Capacidad < 10)
                {
                    cartuchera.listaUtiles.Add(util);

                    if(cartuchera.PrecioTotal > 500)
                    {
                        tickets = cartuchera.listaUtiles.ToString();
                    }

                    retorno = true;
                }
                else
                {
                    throw new CartucheraLLenaException("La cartuchera esta llena");
                }
            }

            return retorno;
        }

        public double AcumulaPrecio(List<T> listaUtiles)
        {
            double precioTotal = 0;

            if (listaUtiles is not null)
            {
                foreach (T item in listaUtiles)
                {
                    precioTotal += item.Precio;
                }
            }

            return precioTotal;
        }
        



    }

}


