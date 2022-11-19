using System;

namespace TpUtiles
{
    public abstract class Util
    {
        protected double precio;
        protected string marca;
        public Util()
        {
            this.precio = 0;
            this.marca = "";
        }

        public Util(double precio, string marca)
        {
            this.precio = precio;
            this.marca = marca; 
        }

        public double Precio
        {
            get { return this.precio; }
            set
            {
                this.precio = value;
            }
        }

        public string Marca 
        {
            get { return this.marca; }
            set
            {
                this.marca = value;
            }
        }

        public static bool operator == (Util util1, Util util2)
        {
            return util1.Marca == util2.Marca;
        }

        public static bool operator !=(Util util1, Util util2)
        {
            return !(util1.Marca == util2.Marca);
        }
    }
}
