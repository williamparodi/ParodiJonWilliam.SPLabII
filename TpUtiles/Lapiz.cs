using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpUtiles
{
    public class Lapiz : Util
    {
        private EColor color;
        private ETipoLapiz tipoDeLapiz;

        public Lapiz() : base()
        {
            this.color = EColor.Negro;
            this.tipoDeLapiz = ETipoLapiz.Normal;
        }

        public Lapiz(double precio,string marca,EColor color,ETipoLapiz tipoDelapiz) :base(precio,marca)
        {
            this.color = color;
            this.tipoDeLapiz = tipoDelapiz;
        }

        public EColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public ETipoLapiz TipoDeLapiz
        {
            get { return this.tipoDeLapiz; }
            set { this.tipoDeLapiz = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Precio :{this.precio},Marca : {this.marca},Color : {this.color},Tipo de Lapiz: {this.tipoDeLapiz}");
            return sb.ToString();
        }

    }
}
