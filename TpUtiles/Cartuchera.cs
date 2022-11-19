using System.Collections.Generic;

namespace TpUtiles
{
    public class Cartuchera<T> where T : Util
    {
        private int capacidad;
        private List<T> listaUtiles;

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
                if (cartuchera.Capacidad < 50)
                {
                    cartuchera.listaUtiles.Add(util);
                    retorno = true;
                }
            }

            return retorno;
        }

        public double AcumulaPrecio(List<T> listaUtiles)
        {
            double precioTotal = 0;

            foreach (T item in listaUtiles)
            {
                precioTotal += item.Precio;
            }

            return precioTotal;
        }


    }

}


