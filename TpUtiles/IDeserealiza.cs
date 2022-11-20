using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpUtiles;

namespace Entidades
{
    public interface IDeserealiza
    {
        Lapiz DeseralizaJsonLapiz(string str);

        Lapiz DeserealizaLapizXml(string nombreDelArchivo);
    }
}

