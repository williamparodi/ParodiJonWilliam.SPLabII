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


    }
}
