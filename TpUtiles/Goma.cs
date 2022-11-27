using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpUtiles
{
    public class Goma : Util
    {
        private ETipoGoma tipoGoma;
        private ETamanio tamanio;
       
        public Goma() : base()
        {
            this.tipoGoma = ETipoGoma.SinTipo;
            this.tamanio = 0;
        }

        public Goma(double precio,string marca,ETipoGoma tipoGoma,ETamanio tamanio) : base(precio,marca)
        {
            this.tipoGoma = tipoGoma;
            this.tamanio = tamanio;
        }
  
        public ETipoGoma TipoGoma
        {
            get { return this.tipoGoma; }
            set { this.tipoGoma = value; }
        }

        public ETamanio Tamanio
        {
            get { return this.tamanio; }
            set { this.tamanio = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Precio : {this.precio}, Marca : {this.marca}, Tipo de goma : {this.tipoGoma}, Tamaño : {this.tamanio}");
            return sb.ToString();
        }

        public  Goma CargaDatosGoma(string precio,string marca,string tipo,string tamanio)
        {
            Goma auxGoma = new Goma();
            double precioASumar;

            precioASumar = double.Parse(precio);
            auxGoma.precio = precioASumar;
            auxGoma.marca = marca;
            auxGoma.tipoGoma = auxGoma.CargaTipoGoma(tipo);
            auxGoma.tamanio = auxGoma.CargaTamanio(tamanio);
          
            return auxGoma;   
        }

        public ETipoGoma CargaTipoGoma(string tipo)
        {
            ETipoGoma auxGoma = new ETipoGoma();

            switch (tipo)
            {
                case "ParaTinta":
                    auxGoma = ETipoGoma.ParaTinta;
                    break;
                case "ParaLapiz":
                    auxGoma = ETipoGoma.ParaLapiz;
                    break;
                default:
                    break;
            }

            return auxGoma;
        }

        public ETamanio CargaTamanio(string tamanio) 
        {
            ETamanio auxGoma = new ETamanio();

            switch(tamanio) 
            {
                case "1":
                    auxGoma = ETamanio.Numero1;
                    break;
                case "2":
                    auxGoma = ETamanio.Numero2;
                    break;
                case "3":
                    auxGoma = ETamanio.Numero3;
                    break;
                default:
                    break;
            }

            return auxGoma;
        }


    }
}
