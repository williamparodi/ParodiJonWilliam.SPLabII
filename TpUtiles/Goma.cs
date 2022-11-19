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
        private int tamanio;

        public Goma() : base()
        {
            this.tipoGoma = ETipoGoma.SinTipo;
            this.tamanio = 0;
        }

        public Goma(double precio,string marca,ETipoGoma tipoGoma,int tamanio) : base(precio,marca)
        {
            this.tipoGoma = tipoGoma;
            this.tamanio = tamanio;
        }

        public ETipoGoma TipoGoma
        {
            get { return this.tipoGoma; }
            set { this.tipoGoma = value; }
        }

        public int Tamanio
        {
            get { return this.tamanio; }
            set { this.tamanio = value; }
        }


    }
}
