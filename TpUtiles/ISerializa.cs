using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TpUtiles;

namespace Entidades
{
    public interface ISerializa
    {
        void SerializaLapizJson(Lapiz lapiz);

        void SerializaLapizXml(string nombreArchivo, Lapiz lapiz);
    }  
}
