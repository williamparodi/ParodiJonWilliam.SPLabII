using Entidades;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace TpUtiles
{
    public delegate void DelegadoPrecio(string mensaje);
    public class Cartuchera<T> where T : Util
    {
        private int capacidad;
        private List<T> listaUtiles;
        
        public static event DelegadoPrecio EventoPrecio;//lo hice estatic por que lo utilizo en el operador static

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
            get
            {
                return AcumulaPrecio(this.listaUtiles);
            }
        }

        public static bool operator +(Cartuchera<T> cartuchera, T util)
        {
            bool retorno = false;
            
            if (cartuchera is not null && util is not null)
            {
                if (cartuchera.Capacidad < 10)
                {
                    cartuchera.listaUtiles.Add(util);
                    if(cartuchera.PrecioTotal > 500)
                    {
                        EventoPrecio($"Se supero el precio total de $500! Total :$ {cartuchera.PrecioTotal}");
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


