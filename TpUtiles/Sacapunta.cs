using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TpUtiles
{
    public class Sacapunta : Util
    {
        private ETipoSacapuntas tipoSacapuntas;

        public Sacapunta() : base()
        {
            this.tipoSacapuntas = ETipoSacapuntas.SinTipo;
        }

        public Sacapunta(double precio,string marca,ETipoSacapuntas tipoSacapuntas): base(precio,marca)
        {
            this.tipoSacapuntas = tipoSacapuntas;
        }

        public ETipoSacapuntas TipoSacapuntas
        {
            get { return this.tipoSacapuntas; }
            set { this.tipoSacapuntas = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Precio : {this.precio} , Marca : {this.marca} , Tipo de sacapuntas : {this.TipoSacapuntas}");
            return sb.ToString();
        }

        public ETipoSacapuntas CargaTipoSacapuntas(string tipo)
        {
            ETipoSacapuntas auxSacapuntas = new ETipoSacapuntas();

            switch(tipo)
            {
                case "Electrico":
                    auxSacapuntas = ETipoSacapuntas.Electrico;
                    break;
                case "Portatil":
                    auxSacapuntas = ETipoSacapuntas.Portatil;
                    break;
                default:
                    break;
            }

            return auxSacapuntas;
        }

        public Sacapunta CargaDatosSacapuntas(string precio,string marca,string tipo)
        {
            Sacapunta auxSacapuntas = new Sacapunta();

            double precioASumar;

            precioASumar = double.Parse(precio);
            auxSacapuntas.precio = precioASumar;
            auxSacapuntas.marca = marca;
            auxSacapuntas.tipoSacapuntas = auxSacapuntas.CargaTipoSacapuntas(tipo);

            return auxSacapuntas;
        }
    }
}
